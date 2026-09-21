using System.Collections.Generic;
using System.Data.SqlClient;
using Library_Management_System.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL
{
    public class UserDAL
    {
        public User Login(string username, string password)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = "SELECT * FROM Users WHERE Username=@u AND Password=@p AND IsActive=1";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) return MapReaderToUser(reader);
                    }
                }
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            var list = new List<User>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM Users WHERE IsDeleted = 0", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapReaderToUser(reader));
                    }
                }
            }
            return list;
        }

        public bool AddUser(User u)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = @"INSERT INTO Users (FullName, Username, Password, Role, Phone, Email, IsActive, IsDeleted)
                               VALUES (@FullName, @Username, @Password, @Role, @Phone, @Email, @IsActive, 0)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, u);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateUser(User u)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = @"UPDATE Users SET FullName=@FullName, Username=@Username, Password=@Password,
                               Role=@Role, Phone=@Phone, Email=@Email, IsActive=@IsActive WHERE UserID=@UserID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, u);
                    cmd.Parameters.AddWithValue("@UserID", u.UserID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("UPDATE Users SET IsDeleted = 1 WHERE UserID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private void AddParams(SqlCommand cmd, User u)
        {
            cmd.Parameters.AddWithValue("@FullName", u.FullName);
            cmd.Parameters.AddWithValue("@Username", u.Username);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            cmd.Parameters.AddWithValue("@Role", u.Role);
            cmd.Parameters.AddWithValue("@Phone", (object)u.Phone ?? "");
            cmd.Parameters.AddWithValue("@Email", (object)u.Email ?? "");
            cmd.Parameters.AddWithValue("@IsActive", u.IsActive);
        }

        private User MapReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                UserID = (int)reader["UserID"],
                FullName = reader["FullName"].ToString(),
                Username = reader["Username"].ToString(),
                Password = reader["Password"].ToString(),
                Role = reader["Role"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString(),
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
