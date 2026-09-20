using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Library_Management_System.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DAL
{
    public class MemberDAL
    {
        public List<Member> GetAllMembers()
        {
            var list = new List<Member>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM Members", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapReaderToMember(reader));
                    }
                }
            }
            return list;
        }

        public List<Member> SearchMembers(string keyword)
        {
            var list = new List<Member>();
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM Members WHERE FullName LIKE @k OR MemberCode LIKE @k", conn))
                {
                    cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapReaderToMember(reader));
                    }
                }
            }
            return list;
        }

        public bool AddMember(Member m)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = @"INSERT INTO Members (MemberCode, FullName, Gender, DateOfBirth, Phone, Email, Address, RegisterDate, IsActive)
                               VALUES (@Code,@Name,@Gender,@Dob,@Phone,@Email,@Address,@RegDate,@Active)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, m);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateMember(Member m)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                string sql = @"UPDATE Members SET MemberCode=@Code, FullName=@Name, Gender=@Gender, DateOfBirth=@Dob,
                               Phone=@Phone, Email=@Email, Address=@Address, IsActive=@Active WHERE MemberID=@id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    AddParams(cmd, m);
                    cmd.Parameters.AddWithValue("@id", m.MemberID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteMember(int memberId)
        {
            using (var conn = new DatabaseConnection().GetConnection())
            {
                using (var cmd = new SqlCommand("DELETE FROM Members WHERE MemberID=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", memberId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private void AddParams(SqlCommand cmd, Member m)
        {
            cmd.Parameters.AddWithValue("@Code", m.MemberCode);
            cmd.Parameters.AddWithValue("@Name", m.FullName);
            cmd.Parameters.AddWithValue("@Gender", (object)m.Gender ?? "");
            cmd.Parameters.AddWithValue("@Dob", (object)m.DateOfBirth ?? DateTime.Now);
            cmd.Parameters.AddWithValue("@Phone", (object)m.Phone ?? "");
            cmd.Parameters.AddWithValue("@Email", (object)m.Email ?? "");
            cmd.Parameters.AddWithValue("@Address", (object)m.Address ?? "");
            cmd.Parameters.AddWithValue("@RegDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Active", m.IsActive);
        }

        private Member MapReaderToMember(SqlDataReader reader)
        {
            return new Member
            {
                MemberID = (int)reader["MemberID"],
                MemberCode = reader["MemberCode"].ToString(),
                FullName = reader["FullName"].ToString(),
                Gender = reader["Gender"].ToString(),
                DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["DateOfBirth"],
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString(),
                Address = reader["Address"].ToString(),
                RegisterDate = (DateTime)reader["RegisterDate"],
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
