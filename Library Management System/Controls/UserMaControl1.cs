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
    public partial class UserMaControl1 : UserControl
    {
        private readonly LibraryManagementSystem.BLL.UserBLL userBLL = new LibraryManagementSystem.BLL.UserBLL();
        private int selectedUserId = 0;

        public UserMaControl1()
        {
            InitializeComponent();
            this.Load += UserMaControl1_Load;
            this.dataGridUser.CellClick += DataGridUser_CellClick;
        }

        private void UserMaControl1_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ClearForm();
        }

        private void LoadUsers()
        {
            dataGridUser.AutoGenerateColumns = true;
            dataGridUser.DataSource = null;
            dataGridUser.DataSource = userBLL.GetAll();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string validationError = ValidateUserForm();
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = new LibraryManagementSystem.Models.User
                {
                    Username = txtUserUsername.Text.Trim(),
                    Password = txtUserPassword.Text.Trim(),
                    FullName = txtUserFullName.Text.Trim(),
                    Email = txtUserEmail.Text.Trim(),
                    Phone = txtUserPhone.Text.Trim(),
                    Role = comboUserRole.SelectedItem?.ToString() ?? "",
                    IsActive = comboUserStatus.SelectedItem?.ToString() == "Active",
                };
                userBLL.CurrentUser = user;
                userBLL.Add();
                MessageBox.Show("User added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Please select a user to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string validationError = ValidateUserForm();
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = new LibraryManagementSystem.Models.User
                {
                    UserID = selectedUserId,
                    Username = txtUserUsername.Text.Trim(),
                    Password = txtUserPassword.Text.Trim(),
                    FullName = txtUserFullName.Text.Trim(),
                    Email = txtUserEmail.Text.Trim(),
                    Phone = txtUserPhone.Text.Trim(),
                    Role = comboUserRole.SelectedItem?.ToString() ?? "",
                    IsActive = comboUserStatus.SelectedItem?.ToString() == "Active",
                };
                userBLL.CurrentUser = user;
                userBLL.Update();
                MessageBox.Show("User updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure to delete selected user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                userBLL.CurrentUser = new LibraryManagementSystem.Models.User { UserID = selectedUserId };
                userBLL.Delete();
                MessageBox.Show("User deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedUserId = 0;
            txtUserID.Clear();
            txtUserUsername.Clear();
            txtUserPassword.Clear();
            txtUserFullName.Clear();
            txtUserEmail.Clear();
            txtUserPhone.Clear();
            if (comboUserRole.Items.Count > 0) comboUserRole.SelectedIndex = 0;
            if (comboUserStatus.Items.Count > 0) comboUserStatus.SelectedIndex = 0;
        }

        private string ValidateUserForm()
        {
            if (string.IsNullOrWhiteSpace(txtUserUsername.Text))
                return "Username is required.";
            if (string.IsNullOrWhiteSpace(txtUserPassword.Text))
                return "Password is required.";
            if (string.IsNullOrWhiteSpace(txtUserFullName.Text))
                return "Full Name is required.";
            if (comboUserRole.SelectedItem == null)
                return "Role is required.";
            if (comboUserStatus.SelectedItem == null)
                return "Status is required.";
            return null;
        }

        private void DataGridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridUser.Rows[e.RowIndex];
            if (row.DataBoundItem is LibraryManagementSystem.Models.User user)
            {
                selectedUserId = user.UserID;
                txtUserID.Text = user.UserID.ToString();
                txtUserUsername.Text = user.Username ?? string.Empty;
                txtUserPassword.Text = user.Password ?? string.Empty;
                txtUserFullName.Text = user.FullName ?? string.Empty;
                txtUserEmail.Text = user.Email ?? string.Empty;
                txtUserPhone.Text = user.Phone ?? string.Empty;
                try { comboUserRole.SelectedItem = user.Role; } catch { }
                try { comboUserStatus.SelectedItem = user.IsActive ? "Active" : "Inactive"; }
                catch
                {
                }
            }
        }
    }
}