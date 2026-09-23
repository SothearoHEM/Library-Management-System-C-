using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = true;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = true;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = true;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = true;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = true;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = true;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = true;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = false;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = false;
            reportControl1.Visible = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }  
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            dashboardControl1.Visible = false;
            bookControl1.Visible = false;
            memberControl1.Visible = false;
            categoryControl1.Visible = false;
            borrowControl1.Visible = false;
            returnControl1.Visible = false;
            authorControl1.Visible = false;
            userMaControl11.Visible = true;
            reportControl1.Visible = false;
        }
    }
}
