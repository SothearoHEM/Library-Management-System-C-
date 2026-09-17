using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_Management_System.Data
{
    public class DatabaseConnection
    {
        private string connectionString =
            @"Server=DESKTOP-HU3F7EL\MSSQLSERVER2022;
              Database=LibraryManagementDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
