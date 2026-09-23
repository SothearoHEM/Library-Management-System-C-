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
    public partial class CategoryControl : UserControl
    {
        private readonly LibraryManagementSystem.BLL.CategoryBLL categoryBLL = new LibraryManagementSystem.BLL.CategoryBLL();
        private int selectedCategoryId = 0;

        public CategoryControl()
        {
            InitializeComponent();
            this.Load += CategoryControl_Load;
            this.dataGridCategory.CellClick += DataGridCategory_CellClick;
            this.btnAddCategory.Click += BtnAddCategory_Click;
            this.btnUpdateCategory.Click += BtnUpdateCategory_Click;
            this.btnDeleteCategory.Click += BtnDeleteCategory_Click;
            this.btnClearCategory.Click += BtnClearCategory_Click;
            this.btnSearchCategory.Click += BtnSearchCategory_Click;
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            LoadCategories();
            ClearForm();
        }

        private void LoadCategories()
        {
            dataGridCategory.AutoGenerateColumns = true;
            dataGridCategory.DataSource = null;
            dataGridCategory.DataSource = categoryBLL.GetAll();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string validationError = ValidateCategoryForm();
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var c = new LibraryManagementSystem.Models.Category
                {
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtCategoryDescription.Text.Trim()
                };
                categoryBLL.CurrentCategory = c;
                categoryBLL.Add();
                MessageBox.Show("Category added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string validationError = ValidateCategoryForm();
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var c = new LibraryManagementSystem.Models.Category
                {
                    CategoryID = selectedCategoryId,
                    CategoryName = txtCategoryName.Text.Trim(),
                    Description = txtCategoryDescription.Text.Trim()
                };
                categoryBLL.CurrentCategory = c;
                categoryBLL.Update();
                MessageBox.Show("Category updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure to delete selected category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                categoryBLL.CurrentCategory = new LibraryManagementSystem.Models.Category { CategoryID = selectedCategoryId };
                categoryBLL.Delete();
                MessageBox.Show("Category deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearCategory_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnSearchCategory_Click(object sender, EventArgs e)
        {
            string kw = txtSearchCategory.Text.Trim();
            if (string.IsNullOrEmpty(kw)) LoadCategories();
            else dataGridCategory.DataSource = categoryBLL.GetAll().FindAll(c => c.CategoryName.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void ClearForm()
        {
            selectedCategoryId = 0;
            txtCategoryName.Clear();
            txtCategoryDescription.Clear();
            txtSearchCategory.Clear();
        }

        private string ValidateCategoryForm()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                return "Category Name is required.";
            return null;
        }

        private void DataGridCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridCategory.Rows[e.RowIndex];
            if (row.DataBoundItem is LibraryManagementSystem.Models.Category c)
            {
                selectedCategoryId = c.CategoryID;
                txtCategoryName.Text = c.CategoryName ?? string.Empty;
                txtCategoryDescription.Text = c.Description ?? string.Empty;
            }
        }
    }
}