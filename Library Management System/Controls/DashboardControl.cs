using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.Models;

namespace Library_Management_System.Controls
{
    public partial class DashboardControl : UserControl
    {
        private readonly BookBLL bookBLL = new BookBLL();
        private readonly MemberBLL memberBLL = new MemberBLL();
        private readonly BorrowBLL borrowBLL = new BorrowBLL();

        public DashboardControl()
        {
            InitializeComponent();
            this.Load += DashboardControl_Load;
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        /// <summary>
        /// Refresh all dashboard data - stats cards and grid
        /// </summary>
        private void RefreshDashboard()
        {
            try
            {
                UpdateStatCards();
                LoadStatisticsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update the top stat cards with key metrics
        /// </summary>
        private void UpdateStatCards()
        {
            try
            {
                // Total Books (excluding deleted)
                var allBooks = bookBLL.GetAll();
                int totalBooks = allBooks.Count;
                totalBookView.Text = totalBooks.ToString();

                // Total Members (active only)
                var allMembers = memberBLL.GetAll();
                int activeMembers = allMembers.Count(m => m.IsActive);
                membersView.Text = activeMembers.ToString();

                // Total Borrowed Books (count active borrowings)
                var allBorrowings = borrowBLL.GetAllBorrowings();
                int borrowedBooks = allBorrowings.Count(b => b.Status == "Borrowed");
                borrowedBookView.Text = borrowedBooks.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stat cards: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load statistics grid with borrowing data
        /// </summary>
        private void LoadStatisticsData()
        {
            try
            {
                // Get all active borrowings with member info
                var borrowings = borrowBLL.GetAllBorrowings();

                // Create data source for grid
                var statisticsData = new List<BorrowingStatistic>();

                // Add borrowing details to statistics
                foreach (var borrowing in borrowings.Where(b => b.Status == "Borrowed"))
                {
                    var details = borrowBLL.GetDetails(borrowing.BorrowID);

                    foreach (var detail in details)
                    {
                        // Calculate if overdue
                        bool isOverdue = DateTime.Now.Date > borrowing.DueDate.Date;
                        int lateDays = Math.Max(0, (DateTime.Now.Date - borrowing.DueDate.Date).Days);
                        decimal fine = lateDays * 0.50m;

                        statisticsData.Add(new BorrowingStatistic
                        {
                            BorrowID = borrowing.BorrowID,
                            MemberName = borrowing.MemberName,
                            BookTitle = detail.BookTitle,
                            Quantity = detail.Quantity,
                            BorrowDate = borrowing.BorrowDate,
                            DueDate = borrowing.DueDate,
                            Status = borrowing.Status,
                            IsOverdue = isOverdue,
                            LateDays = lateDays,
                            Fine = fine
                        });
                    }
                }

                // Bind to grid
                libraryStatisticData.AutoGenerateColumns = true;
                libraryStatisticData.DataSource = null;
                libraryStatisticData.DataSource = statisticsData;

                // Format grid columns
                FormatStatisticsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format the statistics grid columns
        /// </summary>
        private void FormatStatisticsGrid()
        {
            try
            {
                if (libraryStatisticData.Columns.Count > 0)
                {
                    // Set column headers and widths
                    libraryStatisticData.Columns["BorrowID"].HeaderText = "Borrow ID";
                    libraryStatisticData.Columns["MemberName"].HeaderText = "Member";
                    libraryStatisticData.Columns["BookTitle"].HeaderText = "Book Title";
                    libraryStatisticData.Columns["Quantity"].HeaderText = "Qty";
                    libraryStatisticData.Columns["BorrowDate"].HeaderText = "Borrow Date";
                    libraryStatisticData.Columns["DueDate"].HeaderText = "Due Date";
                    libraryStatisticData.Columns["Status"].HeaderText = "Status";
                    libraryStatisticData.Columns["IsOverdue"].HeaderText = "Overdue";
                    libraryStatisticData.Columns["LateDays"].HeaderText = "Late Days";
                    libraryStatisticData.Columns["Fine"].HeaderText = "Fine ($)";

                    // Format date columns
                    if (libraryStatisticData.Columns["BorrowDate"] is DataGridViewColumn col1)
                        col1.DefaultCellStyle.Format = "M/d/yyyy";

                    if (libraryStatisticData.Columns["DueDate"] is DataGridViewColumn col2)
                        col2.DefaultCellStyle.Format = "M/d/yyyy";

                    // Format fine column
                    if (libraryStatisticData.Columns["Fine"] is DataGridViewColumn col3)
                        col3.DefaultCellStyle.Format = "F2";

                    // Set width mode
                    libraryStatisticData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error formatting statistics grid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }

    /// <summary>
    /// Helper class for displaying borrowing statistics in grid
    /// </summary>
    public class BorrowingStatistic
    {
        public int BorrowID { get; set; }
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public bool IsOverdue { get; set; }
        public int LateDays { get; set; }
        public decimal Fine { get; set; }
    }
}
