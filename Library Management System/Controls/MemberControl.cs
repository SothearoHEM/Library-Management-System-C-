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
    public partial class MemberControl : UserControl
    {
        private readonly LibraryManagementSystem.BLL.MemberBLL memberBLL = new LibraryManagementSystem.BLL.MemberBLL();
        private int selectedMemberId = 0;

        public MemberControl()
        {
            InitializeComponent();
            this.Load += MemberControl_Load;
            this.dataGridMember.CellClick += DataGridMember_CellClick;
            this.btnAddMember.Click += BtnAddMember_Click;
            this.btnUpdateMember.Click += BtnUpdateMember_Click;
            this.btnDeleteMember.Click += BtnDeleteMember_Click;
            this.btnClearMember.Click += BtnClearMember_Click;
            this.btnSearchMember.Click += BtnSearchMember_Click;
        }

        private void MemberControl_Load(object sender, EventArgs e)
        {
            LoadMembers();
            ClearForm();
        }

        private void LoadMembers()
        {
            dataGridMember.AutoGenerateColumns = true;
            dataGridMember.DataSource = null;
            dataGridMember.DataSource = memberBLL.GetAll();
        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                var m = new LibraryManagementSystem.Models.Member
                {
                    MemberCode = txtMemberCode.Text.Trim(),
                    FullName = txtMemberFullName.Text.Trim(),
                    Gender = comboMemberGender.SelectedItem?.ToString() ?? "",
                    DateOfBirth = dateMemberDOB.Value,
                    Phone = txtMemberPhone.Text.Trim(),
                    Email = txtMemberEmail.Text.Trim(),
                    Address = txtMemberAddress.Text.Trim(),
                    IsActive = true
                };
                memberBLL.CurrentMember = m;
                memberBLL.Add();
                MessageBox.Show("Member added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateMember_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Please select a member to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var m = new LibraryManagementSystem.Models.Member
                {
                    MemberID = selectedMemberId,
                    MemberCode = txtMemberCode.Text.Trim(),
                    FullName = txtMemberFullName.Text.Trim(),
                    Gender = comboMemberGender.SelectedItem?.ToString() ?? "",
                    DateOfBirth = dateMemberDOB.Value,
                    Phone = txtMemberPhone.Text.Trim(),
                    Email = txtMemberEmail.Text.Trim(),
                    Address = txtMemberAddress.Text.Trim(),
                    IsActive = true
                };
                memberBLL.CurrentMember = m;
                memberBLL.Update();
                MessageBox.Show("Member updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteMember_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Please select a member to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure to delete selected member?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                memberBLL.CurrentMember = new LibraryManagementSystem.Models.Member { MemberID = selectedMemberId };
                memberBLL.Delete();
                MessageBox.Show("Member deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearMember_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            string kw = txtSearchMember.Text.Trim();
            if (string.IsNullOrEmpty(kw)) LoadMembers();
            else dataGridMember.DataSource = memberBLL.Search(kw);
        }

        private void ClearForm()
        {
            selectedMemberId = 0;
            txtMemberCode.Clear();
            txtMemberFullName.Clear();
            txtMemberPhone.Clear();
            txtMemberEmail.Clear();
            txtMemberAddress.Clear();
            dateMemberDOB.Value = DateTime.Now;
            txtSearchMember.Clear();
            if (comboMemberGender.Items.Count > 0) comboMemberGender.SelectedIndex = 0;
        }

        private void DataGridMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridMember.Rows[e.RowIndex];
            if (row.DataBoundItem is LibraryManagementSystem.Models.Member m)
            {
                selectedMemberId = m.MemberID;
                txtMemberCode.Text = m.MemberCode ?? string.Empty;
                txtMemberFullName.Text = m.FullName ?? string.Empty;
                txtMemberPhone.Text = m.Phone ?? string.Empty;
                txtMemberEmail.Text = m.Email ?? string.Empty;
                txtMemberAddress.Text = m.Address ?? string.Empty;
                dateMemberDOB.Value = m.DateOfBirth ?? DateTime.Now;
                try { comboMemberGender.SelectedItem = m.Gender; } catch { }
            }
        }
    }
}
