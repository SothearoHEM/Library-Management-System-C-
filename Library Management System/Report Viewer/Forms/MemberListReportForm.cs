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
    public partial class MemberListReportForm : Form
    {
        public MemberListReportForm()
        {
            InitializeComponent();
        }

        private void MemberListReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMemberReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LoadMemberReport()
        {
            try
            {
                List<MemberListReport> memberLists = new List<MemberListReport>();
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    string query = "SELECT MemberID, MemberCode, FullName, Phone, Email FROM Members";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                memberLists.Add(new MemberListReport
                                {
                                    MemberID = reader.GetInt32(0),
                                    MemberCode = reader.GetString(1),
                                    FullName = reader.GetString(2),
                                    Phone = reader.GetString(3),
                                    Email = reader.GetString(4)
                                });
                            }
                        }
                    }

                    // Bind to RDLC Report Viewer
                    string reportPath = Path.Combine(Application.StartupPath, "Report Viewer", "Wizards", "MemberListWizard.rdlc");
                    this.reportViewer1.LocalReport.ReportPath = reportPath;

                    ReportDataSource rds = new ReportDataSource("DataSet1", memberLists);
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(rds);

                    this.reportViewer1.RefreshReport();
                }
                // Set the data source for the report viewer
                this.memberListReportBindingSource.DataSource = memberLists;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
