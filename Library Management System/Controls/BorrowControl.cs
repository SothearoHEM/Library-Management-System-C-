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
    public partial class BorrowControl : UserControl
    {
        private readonly BorrowBLL borrowBLL = new BorrowBLL();
        private readonly MemberBLL memberBLL = new MemberBLL();
        private readonly BookBLL bookBLL = new BookBLL();
        private List<BorrowingDetail> borrowingDetails = new List<BorrowingDetail>();

        public BorrowControl()
        {
            InitializeComponent();
            // Wire events
            this.Load += BorrowControl_Load;
            this.btnAddBookBorrow.Click += btnAddBookBorrow_Click;
            this.btnBorrowBook.Click += btnBorrowBook_Click;
            this.btnRemoveBorrow.Click += btnRemoveBorrow_Click;
        }

        private void BorrowControl_Load(object sender, EventArgs e)
        {
            LoadMembers();
            LoadBooks();
            LoadBorrowings();
            ClearForm();
        }

        private void LoadMembers()
        {
            try
            {
                var members = memberBLL.GetAll().Where(m => m.IsActive).ToList();
                comboBorrowMenber.DisplayMember = "FullName";
                comboBorrowMenber.ValueMember = "MemberID";
                comboBorrowMenber.DataSource = members;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var books = bookBLL.GetAll().Where(b => b.AvailableQuantity > 0).ToList();
                comboBox2.DisplayMember = "Title";
                comboBox2.ValueMember = "BookID";
                comboBox2.DataSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBorrowings()
        {
            try
            {
                var borrowings = borrowBLL.GetAllBorrowings();
                dataBorrowBook.AutoGenerateColumns = true;
                dataBorrowBook.DataSource = borrowings;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrowings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBookBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (comboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Please select a book to borrow.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quantity;
                if (!int.TryParse(txtBorrowQty.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int bookId = (int)comboBox2.SelectedValue;
                string bookTitle = comboBox2.Text;

                // Get selected book to check availability
                var allBooks = bookBLL.GetAll();
                var selectedBook = allBooks.FirstOrDefault(b => b.BookID == bookId);

                if (selectedBook == null)
                {
                    MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if quantity is available
                if (quantity > selectedBook.AvailableQuantity)
                {
                    MessageBox.Show($"Only {selectedBook.AvailableQuantity} copies available.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if book is already in list
                if (borrowingDetails.Any(d => d.BookID == bookId))
                {
                    MessageBox.Show("This book is already in the borrow list.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add to borrowing details list
                var detail = new BorrowingDetail
                {
                    BookID = bookId,
                    BookTitle = bookTitle,
                    Quantity = quantity
                };

                borrowingDetails.Add(detail);

                // Refresh the borrow details grid
                dataBorrowBook.AutoGenerateColumns = true;
                dataBorrowBook.DataSource = null;
                dataBorrowBook.DataSource = borrowingDetails.ToList();

                MessageBox.Show("Book added to borrow list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBorrowQty.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (comboBorrowMenber.SelectedValue == null)
                {
                    MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (borrowingDetails.Count == 0)
                {
                    MessageBox.Show("Please add at least one book to borrow.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime borrowDate = dateBorrowBorrowDate.Value;
                DateTime dueDate = dateBorrowDueDate.Value;

                if (dueDate <= borrowDate)
                {
                    MessageBox.Show("Due date must be after borrow date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create borrowing transaction
                var borrowing = new Borrowing
                {
                    MemberID = (int)comboBorrowMenber.SelectedValue,
                    UserID = 1, // Current logged-in user (hardcoded for now, should be from session)
                    BorrowDate = borrowDate,
                    DueDate = dueDate,
                    Note = "",
                    Details = borrowingDetails
                };

                if (borrowBLL.BorrowBooks(borrowing))
                {
                    MessageBox.Show("Books borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBorrowings();
                    LoadBooks(); // Refresh available books
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to borrow books.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataBorrowBook.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedRowIndex = dataBorrowBook.SelectedRows[0].Index;
                borrowingDetails.RemoveAt(selectedRowIndex);

                // Refresh the grid
                dataBorrowBook.AutoGenerateColumns = true;
                dataBorrowBook.DataSource = null;
                dataBorrowBook.DataSource = borrowingDetails.ToList();

                MessageBox.Show("Book removed from borrow list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            borrowingDetails.Clear();
            dataBorrowBook.DataSource = null;
            txtBorrowQty.Clear();
            dateBorrowBorrowDate.Value = DateTime.Now;
            dateBorrowDueDate.Value = DateTime.Now.AddDays(14); // Default 14 days
            if (comboBorrowMenber.Items.Count > 0)
                comboBorrowMenber.SelectedIndex = 0;
        }
    }
}
