using System.Collections.Generic;
using System.Data.SqlClient;
using Library_Management_System.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL
{
    public class BookDAL
    {
        private const string BaseSelect = @"
            SELECT b.*, a.AuthorName, c.CategoryName
            FROM Books b
            JOIN Authors a ON b.AuthorID = a.AuthorID
            JOIN Categories c ON b.CategoryID = c.CategoryID
            WHERE b.IsDeleted = 0";

        public List<Book> GetAllBooks()
        {
            var list = new List<Book>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand(BaseSelect, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapReaderToBook(reader));
                    }
                }
            }
            return list;
        }

        // Polymorphism (Method Overloading): ស្វែងរកតាមចំណងជើងតែមួយមុខ
        public List<Book> Search(string title)
        {
            var list = new List<Book>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand(BaseSelect + " AND b.Title LIKE @t", conn))
                {
                    cmd.Parameters.AddWithValue("@t", "%" + title + "%");
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapReaderToBook(reader));
                    }
                }
            }
            return list;
        }

        // Polymorphism (Method Overloading): ស្វែងរកតាមចំណងជើង + ប្រភេទសៀវភៅ
        public List<Book> Search(string title, int categoryId)
        {
            var list = new List<Book>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand(BaseSelect + " AND b.Title LIKE @t AND b.CategoryID=@c", conn))
                {
                    cmd.Parameters.AddWithValue("@t", "%" + title + "%");
                    cmd.Parameters.AddWithValue("@c", categoryId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapReaderToBook(reader));
                    }
                }
            }
            return list;
        }

        public bool AddBook(Book b)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = @"INSERT INTO Books (ISBN, Title, AuthorID, CategoryID, Publisher, PublishYear,
                               Quantity, AvailableQuantity, ShelfLocation, Description)
                               VALUES (@ISBN,@Title,@AuthorID,@CategoryID,@Publisher,@PublishYear,
                               @Quantity,@AvailableQuantity,@ShelfLocation,@Description)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, b);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateBook(Book b)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = @"UPDATE Books SET ISBN=@ISBN, Title=@Title, AuthorID=@AuthorID, CategoryID=@CategoryID,
                               Publisher=@Publisher, PublishYear=@PublishYear, Quantity=@Quantity,
                               AvailableQuantity=@AvailableQuantity, ShelfLocation=@ShelfLocation, Description=@Description
                               WHERE BookID=@BookID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, b);
                    cmd.Parameters.AddWithValue("@BookID", b.BookID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("UPDATE Books SET IsDeleted = 1 WHERE BookID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", bookId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ប្រើដោយ BorrowDAL៖ បន្ថយ/បង្កើន AvailableQuantity
        public void ChangeAvailableQuantity(SqlConnection conn, SqlTransaction trans, int bookId, int delta)
        {
            var cmd = new SqlCommand("UPDATE Books SET AvailableQuantity = AvailableQuantity + @delta WHERE BookID=@id", conn, trans);
            cmd.Parameters.AddWithValue("@delta", delta);
            cmd.Parameters.AddWithValue("@id", bookId);
            cmd.ExecuteNonQuery();
        }

        private void AddParams(SqlCommand cmd, Book b)
        {
            cmd.Parameters.AddWithValue("@ISBN", (object)b.ISBN ?? "");
            cmd.Parameters.AddWithValue("@Title", b.Title);
            cmd.Parameters.AddWithValue("@AuthorID", b.AuthorID);
            cmd.Parameters.AddWithValue("@CategoryID", b.CategoryID);
            cmd.Parameters.AddWithValue("@Publisher", (object)b.Publisher ?? "");
            cmd.Parameters.AddWithValue("@PublishYear", b.PublishYear);
            cmd.Parameters.AddWithValue("@Quantity", b.Quantity);
            cmd.Parameters.AddWithValue("@AvailableQuantity", b.AvailableQuantity);
            cmd.Parameters.AddWithValue("@ShelfLocation", (object)b.ShelfLocation ?? "");
            cmd.Parameters.AddWithValue("@Description", (object)b.Description ?? "");
            cmd.Parameters.AddWithValue("@IsDeleted", b.IsDeleted);
        }

        private Book MapReaderToBook(SqlDataReader reader)
        {
            return new Book
            {
                BookID = (int)reader["BookID"],
                ISBN = reader["ISBN"].ToString(),
                Title = reader["Title"].ToString(),
                AuthorID = (int)reader["AuthorID"],
                AuthorName = reader["AuthorName"].ToString(),
                CategoryID = (int)reader["CategoryID"],
                CategoryName = reader["CategoryName"].ToString(),
                Publisher = reader["Publisher"].ToString(),
                PublishYear = reader["PublishYear"] == System.DBNull.Value ? 0 : (int)reader["PublishYear"],
                Quantity = (int)reader["Quantity"],
                AvailableQuantity = (int)reader["AvailableQuantity"],
                ShelfLocation = reader["ShelfLocation"].ToString(),
                Description = reader["Description"].ToString()
            };
        }
    }
}
