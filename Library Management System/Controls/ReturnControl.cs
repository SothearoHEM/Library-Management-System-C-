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
    public partial class ReturnControl : UserControl
    {
        private readonly BorrowBLL borrowBLL = new BorrowBLL();
        private Borrowing selectedBorrowing = null;

        public ReturnControl()
        {
            InitializeComponent();
            // Wire events
            this.Load += ReturnControl_Load;
            this.btnReturnSearchBorrowID.Click += btnReturnSearchBorrowID_Click;
            this.btnReturn.Click += btnReturn_Click;
        }

        private void ReturnControl_Load(object sender, EventArgs e)
        {
            ClearForm();
            txtReturnReturnDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnReturnSearchBorrowID_Click(object sender, EventArgs e)
        {
            try
            {
                int borrowId;
                if (!int.TryParse(txtReturnSearchBorrowID.Text.Trim(), out borrowId))
                {
                    MessageBox.Show("Please enter a valid Borrow ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedBorrowing = borrowBLL.GetBorrowById(borrowId);

                if (selectedBorrowing == null || selectedBorrowing.Status != "Borrowed")
                {
                    MessageBox.Show("No active borrowing found with this ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearForm();
                    return;
                }

                // Display borrow details
                DisplayBorrowDetails(borrowId);

                // Calculate and display fine
                CalculateAndDisplayFine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBorrowDetails(int borrowId)
        {
            try
            {
                // Get and display only the books borrowed (BorrowingDetails), not all borrowings
                var borrowedBooks = borrowBLL.GetDetails(borrowId);
                dataGridReturBook.AutoGenerateColumns = true;
                dataGridReturBook.DataSource = borrowedBooks;

                // Display borrow info in textboxes (readonly)
                txtReturnMember.Text = selectedBorrowing.MemberName;
                txtReturnBorroeDate.Text = selectedBorrowing.BorrowDate.ToShortDateString();
                txtReturnDueDate.Text = selectedBorrowing.DueDate.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrow details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateAndDisplayFine()
        {
            try
            {
                DateTime returnDate = DateTime.ParseExact(txtReturnReturnDate.Text, "M/d/yyyy", null);
                int lateDays = Math.Max(0, (returnDate.Date - selectedBorrowing.DueDate.Date).Days);
                decimal fine = lateDays * 0.50m;

                txtReturnLateDays.Text = lateDays.ToString();
                txtReturnFine.Text = "$" + fine.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating fine: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (selectedBorrowing == null)
                {
                    MessageBox.Show("Please search and select a borrowing first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime returnDate;
                if (!DateTime.TryParse(txtReturnReturnDate.Text, out returnDate))
                {
                    MessageBox.Show("Please enter a valid return date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (returnDate < selectedBorrowing.BorrowDate)
                {
                    MessageBox.Show("Return date cannot be before borrow date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Process return
                decimal fine = borrowBLL.ReturnBooks(selectedBorrowing.BorrowID, selectedBorrowing.DueDate, returnDate, "");

                string message = $"Books returned successfully!\n\nBorrow ID: {selectedBorrowing.BorrowID}\nMember: {selectedBorrowing.MemberName}\n";

                int lateDays = Math.Max(0, (returnDate.Date - selectedBorrowing.DueDate.Date).Days);
                if (lateDays > 0)
                {
                    message += $"Late Days: {lateDays}\n";
                    message += $"Fine: ${fine:F2} ({lateDays} days × $0.50)";
                }
                else
                {
                    message += "No fine - returned on time!";
                }

                MessageBox.Show(message, "Return Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            selectedBorrowing = null;
            txtReturnSearchBorrowID.Clear();
            dataGridReturBook.DataSource = null;
            txtReturnMember.Text = "";
            txtReturnBorroeDate.Text = "";
            txtReturnDueDate.Text = "";
            txtReturnLateDays.Text = "";
            txtReturnFine.Text = "$0.00";
            txtReturnReturnDate.Text = DateTime.Now.ToShortDateString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
