using Library_Management_System.Data;
using Library_Management_System.Report_Viewer.Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Library_Management_System.Report_Viewer.Forms
{
    public partial class BookListReportForm : Form
    {
        public BookListReportForm()
        {
            InitializeComponent();
        }

        private void BookListReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBookReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookReport()
        {
            try
            {
                List<BookListReport> bookLists = new List<BookListReport>();

                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    string query = "SELECT b.BookID, b.ISBN, b.Title, a.AuthorName, c.CategoryName, b.Quantity " +
                                   "FROM Books b " +
                                   "JOIN Authors a ON b.AuthorID = a.AuthorID " +
                                   "JOIN Categories c ON b.CategoryID = c.CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookLists.Add(new BookListReport
                                {
                                    BookID = reader.GetInt32(0),
                                    ISBN = reader.GetString(1),
                                    Title = reader.GetString(2),
                                    AuthorName = reader.GetString(3),
                                    CategoryName = reader.GetString(4),
                                    Quantity = reader.GetInt32(5)
                                });
                            }
                        }
                    }
                }
                string reportPath = Path.Combine(Application.StartupPath, "Report Viewer", "Wizards", "BookListWizard.rdlc");
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet1", bookLists);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading book report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}