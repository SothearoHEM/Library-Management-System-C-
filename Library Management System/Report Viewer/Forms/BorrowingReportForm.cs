using Library_Management_System.Data;
using Library_Management_System.Report_Viewer.Classes;
using LibraryManagementSystem.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System.Report_Viewer.Forms
{
    public partial class BorrowingReportForm : Form
    {

        public BorrowingReportForm()
        {
            InitializeComponent();
        }

        private void BorrowingReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBorrowingReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowing report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LoadBorrowingReport()
        {
            try
            {
                List<BorrowingReport> borrowingReports = new List<BorrowingReport>();
                // Replace line 45:
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    string query = "SELECT b.BorrowID, m.FullName AS MemberName, bk.Title AS BookTitle, b.BorrowDate, b.DueDate, b.Status " +
                                   "FROM Borrowings b " +
                                   "JOIN Members m ON b.MemberID = m.MemberID " +
                                   "JOIN BorrowingDetails bd ON b.BorrowID = bd.BorrowID " +
                                   "JOIN Books bk ON bd.BookID = bk.BookID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                borrowingReports.Add(new BorrowingReport
                                {
                                    BorrowID = reader.GetInt32(0),
                                    MemberName = reader.GetString(1),
                                    BookTitle = reader.GetString(2),
                                    BorrowDate = reader.GetDateTime(3),
                                    DueDate = reader.GetDateTime(4),
                                    Status = reader.GetString(5)
                                });
                            }
                        }
                    }
                }

                // Replace line 71:
                string reportPath = Path.Combine(Application.StartupPath, "Report Viewer", "Wizards", "BorrowingWizard.rdlc");
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet1", borrowingReports);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowing report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
