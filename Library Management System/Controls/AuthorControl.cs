using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System.Controls
{
    public partial class AuthorControl : UserControl
    {
        private readonly LibraryManagementSystem.BLL.AuthorBLL authorBLL = new LibraryManagementSystem.BLL.AuthorBLL();
        private int selectedAuthorId = 0;

        public AuthorControl()
        {
            InitializeComponent();
            this.Load += AuthorControl_Load;
            this.dataGridAuthor.CellClick += DataGridAuthor_CellClick;
            this.btnAddAuthor.Click += BtnAddAuthor_Click;
            this.btnUpdateAuthor.Click += BtnUpdateAuthor_Click;
            this.btnDeleteAuthor.Click += BtnDeleteAuthor_Click;
            this.btnClearAuthor.Click += BtnClearAuthor_Click;
        }

        private void AuthorControl_Load(object sender, EventArgs e)
        {
            LoadAuthors();
            ClearForm();
        }

        private void LoadAuthors()
        {
            dataGridAuthor.AutoGenerateColumns = true;
            dataGridAuthor.DataSource = null;
            dataGridAuthor.DataSource = authorBLL.GetAll();
        }

        private void BtnAddAuthor_Click(object sender, EventArgs e)
        {
            string validationError = ValidateAuthorForm();
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var a = new LibraryManagementSystem.Models.Author
                {
                    AuthorName = txtAuthorName.Text.Trim(),
                    Gender = comboAuthorGender.SelectedItem?.ToString() ?? "",
                    Phone = txtAuthorPhone.Text.Trim(),
                    Email = txtAuthorEmail.Text.Trim(),
                    Description = txtAuthorDescription.Text.Trim()
                };
                authorBLL.CurrentAuthor = a;
                authorBLL.Add();
                MessageBox.Show("Author added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAuthors();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateAuthor_Click(object sender, EventArgs e)
        {
            if (selectedAuthorId == 0)
            {
                MessageBox.Show("Please select an author to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string validationError = ValidateAuthorForm();
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var a = new LibraryManagementSystem.Models.Author
                {
                    AuthorID = selectedAuthorId,
                    AuthorName = txtAuthorName.Text.Trim(),
                    Gender = comboAuthorGender.SelectedItem?.ToString() ?? "",
                    Phone = txtAuthorPhone.Text.Trim(),
                    Email = txtAuthorEmail.Text.Trim(),
                    Description = txtAuthorDescription.Text.Trim()
                };
                authorBLL.CurrentAuthor = a;
                authorBLL.Update();
                MessageBox.Show("Author updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAuthors();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (selectedAuthorId == 0)
            {
                MessageBox.Show("Please select an author to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure to delete selected author?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                authorBLL.CurrentAuthor = new LibraryManagementSystem.Models.Author { AuthorID = selectedAuthorId };
                authorBLL.Delete();
                MessageBox.Show("Author deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAuthors();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearAuthor_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedAuthorId = 0;
            txtAuthorName.Clear();
            txtAuthorPhone.Clear();
            txtAuthorEmail.Clear();
            txtAuthorDescription.Clear();
            if (comboAuthorGender.Items.Count > 0) comboAuthorGender.SelectedIndex = 0;
        }

        private string ValidateAuthorForm()
        {
            if (string.IsNullOrWhiteSpace(txtAuthorName.Text))
                return "Author Name is required.";
            if (comboAuthorGender.SelectedItem == null)
                return "Gender is required.";
            return null;
        }

        private void DataGridAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridAuthor.Rows[e.RowIndex];
            if (row.DataBoundItem is LibraryManagementSystem.Models.Author a)
            {
                selectedAuthorId = a.AuthorID;
                txtAuthorName.Text = a.AuthorName ?? string.Empty;
                txtAuthorPhone.Text = a.Phone ?? string.Empty;
                txtAuthorEmail.Text = a.Email ?? string.Empty;
                txtAuthorDescription.Text = a.Description ?? string.Empty;
                try { comboAuthorGender.SelectedItem = a.Gender; } catch { }
            }
        }
    }
}