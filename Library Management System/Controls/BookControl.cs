using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.Models;

namespace Library_Management_System.Controls
{
    public partial class BookControl : UserControl
    {
        private readonly BookBLL bookBLL = new BookBLL();
        private readonly AuthorBLL authorBLL = new AuthorBLL();
        private readonly CategoryBLL categoryBLL = new CategoryBLL();
        private int selectedBookId = 0;

        public BookControl()
        {
            InitializeComponent();
            // wire events
            this.Load += BookControl_Load;
            this.dataGridBook.CellClick += DataGridBook_CellClick;
            this.btnAddBook.Click += btnAddBook_Click;
            this.btnUpdateBook.Click += btnUpdateBook_Click;
            this.btnDeleteBook.Click += btnDeleteBook_Click;
            this.btnClearBook.Click += btnClearBook_Click;
            this.btnSearchBook.Click += btnSearchBook_Click;
        }

        // Designer references this legacy handler; forward to delete handler
        private void button2_Click(object sender, EventArgs e)
        {
            btnDeleteBook_Click(sender, e);
        }

        private void BookControl_Load(object sender, EventArgs e)
        {
            LoadAuthors();
            LoadCategories();
            LoadBooks();
            ClearForm();
        }

        private void LoadAuthors()
        {
            var authors = authorBLL.GetAll();
            comboBookAuthor.DisplayMember = "AuthorName";
            comboBookAuthor.ValueMember = "AuthorID";
            comboBookAuthor.DataSource = authors;
        }

        private void LoadCategories()
        {
            var cats = categoryBLL.GetAll();
            comboBookCategory.DisplayMember = "CategoryName";
            comboBookCategory.ValueMember = "CategoryID";
            comboBookCategory.DataSource = cats;
        }

        private void LoadBooks()
        {
            dataGridBook.AutoGenerateColumns = true;
            dataGridBook.DataSource = null;
            dataGridBook.DataSource = bookBLL.GetAll();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            string kw = txtSearchBook.Text.Trim();
            if (string.IsNullOrEmpty(kw))
                LoadBooks();
            else
                dataGridBook.DataSource = bookBLL.Search(kw);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                var b = ReadBookFromForm();
                bookBLL.CurrentBook = b;
                bookBLL.Add();
                MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Please select a book to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var b = ReadBookFromForm();
                b.BookID = selectedBookId;
                // set AvailableQuantity to Quantity if not set; business rule can be adjusted
                b.AvailableQuantity = b.Quantity;
                bookBLL.CurrentBook = b;
                bookBLL.Update();
                MessageBox.Show("Book updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Please select a book to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the selected book?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bookBLL.CurrentBook = new Book { BookID = selectedBookId };
                bookBLL.Delete();
                MessageBox.Show("Book deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearBook_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private Book ReadBookFromForm()
        {
            int authorId = comboBookAuthor.SelectedValue != null ? Convert.ToInt32(comboBookAuthor.SelectedValue) : 0;
            int categoryId = comboBookCategory.SelectedValue != null ? Convert.ToInt32(comboBookCategory.SelectedValue) : 0;
            int publishYear = 0;
            int qty = 0;
            int.TryParse(txtBookPublishYear.Text.Trim(), out publishYear);
            int.TryParse(txtBookQty.Text.Trim(), out qty);

            return new Book
            {
                ISBN = txtBookISBN.Text.Trim(),
                Title = txtBookTitle.Text.Trim(),
                AuthorID = authorId,
                CategoryID = categoryId,
                Publisher = txtBookPublisher.Text.Trim(),
                PublishYear = publishYear,
                Quantity = qty,
                ShelfLocation = txtBookShelf.Text.Trim(),
                Description = txtBookDescription.Text.Trim()
            };
        }

        private void ClearForm()
        {
            selectedBookId = 0;
            txtBookISBN.Clear();
            txtBookTitle.Clear();
            txtBookPublisher.Clear();
            txtBookPublishYear.Clear();
            txtBookQty.Clear();
            txtBookShelf.Clear();
            txtBookDescription.Clear();
            txtSearchBook.Clear();
            if (comboBookAuthor.Items.Count > 0) comboBookAuthor.SelectedIndex = 0;
            if (comboBookCategory.Items.Count > 0) comboBookCategory.SelectedIndex = 0;
        }

        private void DataGridBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridBook.Rows[e.RowIndex];
            if (row.DataBoundItem is Book b)
            {
                selectedBookId = b.BookID;
                txtBookISBN.Text = b.ISBN ?? string.Empty;
                txtBookTitle.Text = b.Title ?? string.Empty;
                txtBookPublisher.Text = b.Publisher ?? string.Empty;
                txtBookPublishYear.Text = b.PublishYear > 0 ? b.PublishYear.ToString() : string.Empty;
                txtBookQty.Text = b.Quantity.ToString();
                txtBookShelf.Text = b.ShelfLocation ?? string.Empty;
                txtBookDescription.Text = b.Description ?? string.Empty;
                // select author/category if present in combos
                try
                {
                    if (b.AuthorID > 0)
                        comboBookAuthor.SelectedValue = b.AuthorID;
                }
                catch { }

                try
                {
                    if (b.CategoryID > 0)
                        comboBookCategory.SelectedValue = b.CategoryID;
                }
                catch { }
            }
            else
            {
                // fallback if DataGrid is not bound to Book objects
                try
                {
                    selectedBookId = Convert.ToInt32(row.Cells["BookID"].Value);
                }
                catch { selectedBookId = 0; }
            }
        }
    }
}
