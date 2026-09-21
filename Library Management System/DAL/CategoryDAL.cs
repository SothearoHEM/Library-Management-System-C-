using System.Collections.Generic;
using System.Data.SqlClient;
using Library_Management_System.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL
{
    public class CategoryDAL
    {
        public List<Category> GetAll()
        {
            var list = new List<Category>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM Categories WHERE IsDeleted = 0", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            list.Add(new Category
                            {
                                CategoryID = (int)reader["CategoryID"],
                                CategoryName = reader["CategoryName"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                    }
                }
            }
            return list;
        }

        public bool Add(Category c)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("INSERT INTO Categories (CategoryName, Description, IsDeleted) VALUES (@n, @d, 0)", conn))
                {
                    cmd.Parameters.AddWithValue("@n", c.CategoryName);
                    cmd.Parameters.AddWithValue("@d", (object)c.Description ?? "");
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Category c)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("UPDATE Categories SET CategoryName=@n, Description=@d WHERE CategoryID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@n", c.CategoryName);
                    cmd.Parameters.AddWithValue("@d", (object)c.Description ?? "");
                    cmd.Parameters.AddWithValue("@id", c.CategoryID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("UPDATE Categories SET IsDeleted = 1 WHERE CategoryID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
