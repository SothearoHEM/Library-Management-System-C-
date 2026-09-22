using Library_Management_System.Data;
using Library_Management_System.Report_Viewer.Classes;
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
    public partial class OverDueReportForm : Form
    {
        public OverDueReportForm()
        {
            InitializeComponent();
        }

        private void OverDueReportForm_Load(object sender, EventArgs e)
        {

            try
            {
                LoadOverDueReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOverDueReport()
        {
            try
            {
                List<OverDueReport> overDueReports = new List<OverDueReport>();
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                        m.FullName AS MemberName, 
                        bk.Title AS BookTitle, 
                        b.DueDate, 
                        DATEDIFF(DAY, b.DueDate, GETDATE()) AS DaysLate,
                        CAST(DATEDIFF(DAY, b.DueDate, GETDATE()) * 0.50 AS DECIMAL(10,2)) AS Fine
                     FROM Borrowings b
                     JOIN Members m ON b.MemberID = m.MemberID
                     JOIN BorrowingDetails bd ON b.BorrowID = bd.BorrowID
                     JOIN Books bk ON bd.BookID = bk.BookID
                     WHERE b.DueDate < GETDATE() AND b.Status <> 'Returned'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                overDueReports.Add(new OverDueReport
                                {
                                    MemberName = reader.GetString(0),
                                    BookTitle = reader.GetString(1),
                                    DueDate = reader.GetDateTime(2),
                                    DaysLate = reader.GetInt32(3),
                                    Fine = reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                    string reportPath = Path.Combine(Application.StartupPath, "Report Viewer", "Wizards", "OverDueWizard.rdlc");
                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Clear();

                    // Bind data to the report viewer
                    ReportDataSource rds = new ReportDataSource("DataSet1", overDueReports);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(rds);
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading overdue report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
