using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Library_Management_System.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL
{
    /// <summary>
    /// BorrowDAL - គ្រប់គ្រង Borrowings + BorrowingDetails + Returns
    /// </summary>
    public class BorrowDAL
    {
        private readonly BookDAL bookDAL = new BookDAL();

        public List<Borrowing> GetAllBorrowings()
        {
            var list = new List<Borrowing>();
            using (var conn = new DatabaseConnection().GetConnection())
            using (var cmd = new SqlCommand(
                @"SELECT br.*, m.FullName AS MemberName
                  FROM Borrowings br
                  JOIN Members m ON br.MemberID = m.MemberID
                  ORDER BY br.BorrowID DESC", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Borrowing
                        {
                            BorrowID = (int)reader["BorrowID"],
                            MemberID = (int)reader["MemberID"],
                            MemberName = reader["MemberName"].ToString(),
                            UserID = (int)reader["UserID"],
                            BorrowDate = (DateTime)reader["BorrowDate"],
                            DueDate = (DateTime)reader["DueDate"],
                            Status = reader["Status"].ToString(),
                            Note = reader["Note"] == DBNull.Value ? "" : reader["Note"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public List<BorrowingDetail> GetDetails(int borrowId)
        {
            var list = new List<BorrowingDetail>();
            using (var conn = new DatabaseConnection().GetConnection())
            using (var cmd = new SqlCommand(
                @"SELECT d.*, b.Title AS BookTitle
                  FROM BorrowingDetails d
                  JOIN Books b ON d.BookID = b.BookID
                  WHERE d.BorrowID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", borrowId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BorrowingDetail
                        {
                            BorrowDetailID = (int)reader["BorrowDetailID"],
                            BorrowID = (int)reader["BorrowID"],
                            BookID = (int)reader["BookID"],
                            BookTitle = reader["BookTitle"].ToString(),
                            Quantity = (int)reader["Quantity"]
                        });
                    }
                }
            }

            return list;
        }

        // ខ្ចីសៀវភៅ (អាចខ្ចីច្រើនក្បាលក្នុងការខ្ចីមួយដង) + កាត់ AvailableQuantity
        public bool BorrowBooks(Borrowing borrowing)
        {
            if (borrowing == null) throw new ArgumentNullException(nameof(borrowing));
            if (borrowing.Details == null || borrowing.Details.Count == 0) return false;

            using (var conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int newBorrowId;
                        using (var cmd1 = new SqlCommand(
                            @"INSERT INTO Borrowings (MemberID, UserID, BorrowDate, DueDate, Status, Note)
                              OUTPUT INSERTED.BorrowID
                              VALUES (@MemberID, @UserID, @BorrowDate, @DueDate, 'Borrowed', @Note)", conn, trans))
                        {
                            cmd1.Parameters.AddWithValue("@MemberID", borrowing.MemberID);
                            cmd1.Parameters.AddWithValue("@UserID", borrowing.UserID);
                            cmd1.Parameters.AddWithValue("@BorrowDate", borrowing.BorrowDate);
                            cmd1.Parameters.AddWithValue("@DueDate", borrowing.DueDate);
                            cmd1.Parameters.AddWithValue("@Note", (object)borrowing.Note ?? "");
                            newBorrowId = (int)cmd1.ExecuteScalar();
                        }

                        foreach (var detail in borrowing.Details)
                        {
                            if (detail.Quantity <= 0) throw new InvalidOperationException("Quantity must be greater than zero.");

                            using (var cmd2 = new SqlCommand(
                                @"INSERT INTO BorrowingDetails (BorrowID, BookID, Quantity)
                                  VALUES (@BorrowID, @BookID, @Qty)", conn, trans))
                            {
                                cmd2.Parameters.AddWithValue("@BorrowID", newBorrowId);
                                cmd2.Parameters.AddWithValue("@BookID", detail.BookID);
                                cmd2.Parameters.AddWithValue("@Qty", detail.Quantity);
                                cmd2.ExecuteNonQuery();
                            }

                            bookDAL.ChangeAvailableQuantity(conn, trans, detail.BookID, -detail.Quantity);
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        // សងសៀវភៅ + គណនាប្រាក់ពិន័យ + បង្កើន AvailableQuantity វិញ
        public decimal ReturnBooks(int borrowId, DateTime dueDate, DateTime returnDate, string note = "")
        {
            int lateDays = Math.Max(0, (returnDate.Date - dueDate.Date).Days);
            decimal fine = lateDays * 0.50m;

            using (var conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd1 = new SqlCommand(
                            @"INSERT INTO Returns (BorrowID, ReturnDate, Fine, Note)
                              VALUES (@BorrowID, @ReturnDate, @Fine, @Note)", conn, trans))
                        {
                            cmd1.Parameters.AddWithValue("@BorrowID", borrowId);
                            cmd1.Parameters.AddWithValue("@ReturnDate", returnDate);
                            cmd1.Parameters.AddWithValue("@Fine", fine);
                            cmd1.Parameters.AddWithValue("@Note", note ?? "");
                            cmd1.ExecuteNonQuery();
                        }

                        // Mark borrowing as returned
                        using (var cmd2 = new SqlCommand(
                            "UPDATE Borrowings SET Status='Returned' WHERE BorrowID=@id", conn, trans))
                        {
                            cmd2.Parameters.AddWithValue("@id", borrowId);
                            cmd2.ExecuteNonQuery();
                        }

                        // Read all borrowing details first, then restore stock
                        var toRestock = new List<(int bookId, int qty)>();
                        using (var cmd3 = new SqlCommand(
                            "SELECT BookID, Quantity FROM BorrowingDetails WHERE BorrowID=@id", conn, trans))
                        {
                            cmd3.Parameters.AddWithValue("@id", borrowId);
                            using (var reader = cmd3.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    toRestock.Add(((int)reader["BookID"], (int)reader["Quantity"]));
                                }
                            }
                        }

                        foreach (var detail in toRestock)
                        {
                            bookDAL.ChangeAvailableQuantity(conn, trans, detail.bookId, detail.qty);
                        }

                        trans.Commit();
                        return fine;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public Borrowing GetBorrowById(int borrowId)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            using (var cmd = new SqlCommand(
                @"SELECT br.*, m.FullName AS MemberName
                  FROM Borrowings br
                  JOIN Members m ON br.MemberID = m.MemberID
                  WHERE br.BorrowID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", borrowId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Borrowing
                        {
                            BorrowID = (int)reader["BorrowID"],
                            MemberID = (int)reader["MemberID"],
                            MemberName = reader["MemberName"].ToString(),
                            UserID = (int)reader["UserID"],
                            BorrowDate = (DateTime)reader["BorrowDate"],
                            DueDate = (DateTime)reader["DueDate"],
                            Status = reader["Status"].ToString(),
                            Note = reader["Note"] == DBNull.Value ? "" : reader["Note"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}
