using System.Collections.Generic;
using System.Data.SqlClient;
using Library_Management_System.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL
{
    public class AuthorDAL
    {
        public List<Author> GetAll()
        {
            var list = new List<Author>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                var cmd = new SqlCommand("SELECT * FROM Authors", conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Author
                    {
                        AuthorID = (int)reader["AuthorID"],
                        AuthorName = reader["AuthorName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Description = reader["Description"].ToString()
                    });
            }
            return list;
        }

        public bool Add(Author a)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = "INSERT INTO Authors (AuthorName, Gender, Phone, Email, Description) VALUES (@n,@g,@p,@e,@d)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, a);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Author a)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = "UPDATE Authors SET AuthorName=@n, Gender=@g, Phone=@p, Email=@e, Description=@d WHERE AuthorID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, a);
                    cmd.Parameters.AddWithValue("@id", a.AuthorID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("DELETE FROM Authors WHERE AuthorID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private void AddParams(SqlCommand cmd, Author a)
        {
            cmd.Parameters.AddWithValue("@n", a.AuthorName);
            cmd.Parameters.AddWithValue("@g", (object)a.Gender ?? "");
            cmd.Parameters.AddWithValue("@p", (object)a.Phone ?? "");
            cmd.Parameters.AddWithValue("@e", (object)a.Email ?? "");
            cmd.Parameters.AddWithValue("@d", (object)a.Description ?? "");
        }
    }
}
