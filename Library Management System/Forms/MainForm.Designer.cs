namespace Library_Management_System.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportControl1 = new Library_Management_System.Controls.ReportControl();
            this.returnControl1 = new Library_Management_System.Controls.ReturnControl();
            this.borrowControl1 = new Library_Management_System.Controls.BorrowControl();
            this.memberControl1 = new Library_Management_System.Controls.MemberControl();
            this.authorControl1 = new Library_Management_System.Controls.AuthorControl();
            this.categoryControl1 = new Library_Management_System.Controls.CategoryControl();
            this.bookControl1 = new Library_Management_System.Controls.BookControl();
            this.dashboardControl1 = new Library_Management_System.Controls.DashboardControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.btnBorrow);
            this.panel1.Controls.Add(this.btnMembers);
            this.panel1.Controls.Add(this.btnAuthors);
            this.panel1.Controls.Add(this.btnCategories);
            this.panel1.Controls.Add(this.btnBook);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 661);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.BurlyWood;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogout.Location = new System.Drawing.Point(10, 602);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(137, 37);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout ";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Linen;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReports.Location = new System.Drawing.Point(9, 463);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(137, 37);
            this.btnReports.TabIndex = 10;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Linen;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReturn.Location = new System.Drawing.Point(9, 406);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(137, 37);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.Linen;
            this.btnBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBorrow.Location = new System.Drawing.Point(9, 353);
            this.btnBorrow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(137, 37);
            this.btnBorrow.TabIndex = 8;
            this.btnBorrow.Text = "Borrow ";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.BackColor = System.Drawing.Color.Linen;
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMembers.Location = new System.Drawing.Point(9, 297);
            this.btnMembers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(137, 37);
            this.btnMembers.TabIndex = 7;
            this.btnMembers.Text = "Members";
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.BackColor = System.Drawing.Color.Linen;
            this.btnAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthors.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAuthors.Location = new System.Drawing.Point(10, 243);
            this.btnAuthors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(137, 37);
            this.btnAuthors.TabIndex = 6;
            this.btnAuthors.Text = "Authors  ";
            this.btnAuthors.UseVisualStyleBackColor = false;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.Linen;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCategories.Location = new System.Drawing.Point(10, 193);
            this.btnCategories.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(137, 37);
            this.btnCategories.TabIndex = 5;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.Linen;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBook.Location = new System.Drawing.Point(9, 136);
            this.btnBook.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(137, 37);
            this.btnBook.TabIndex = 4;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Linen;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDashboard.Location = new System.Drawing.Point(10, 76);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(137, 37);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1125, 45);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Library Management System";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1090, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // reportControl1
            // 
            this.reportControl1.Location = new System.Drawing.Point(163, 49);
            this.reportControl1.Name = "reportControl1";
            this.reportControl1.Size = new System.Drawing.Size(961, 611);
            this.reportControl1.TabIndex = 2;
            // 
            // returnControl1
            // 
            this.returnControl1.Location = new System.Drawing.Point(162, 49);
            this.returnControl1.Name = "returnControl1";
            this.returnControl1.Size = new System.Drawing.Size(961, 611);
            this.returnControl1.TabIndex = 3;
            // 
            // borrowControl1
            // 
            this.borrowControl1.Location = new System.Drawing.Point(163, 49);
            this.borrowControl1.Name = "borrowControl1";
            this.borrowControl1.Size = new System.Drawing.Size(960, 611);
            this.borrowControl1.TabIndex = 4;
            // 
            // memberControl1
            // 
            this.memberControl1.Location = new System.Drawing.Point(163, 49);
            this.memberControl1.Name = "memberControl1";
            this.memberControl1.Size = new System.Drawing.Size(960, 611);
            this.memberControl1.TabIndex = 5;
            // 
            // authorControl1
            // 
            this.authorControl1.Location = new System.Drawing.Point(162, 49);
            this.authorControl1.Name = "authorControl1";
            this.authorControl1.Size = new System.Drawing.Size(961, 611);
            this.authorControl1.TabIndex = 6;
            // 
            // categoryControl1
            // 
            this.categoryControl1.Location = new System.Drawing.Point(162, 49);
            this.categoryControl1.Name = "categoryControl1";
            this.categoryControl1.Size = new System.Drawing.Size(961, 611);
            this.categoryControl1.TabIndex = 7;
            // 
            // bookControl1
            // 
            this.bookControl1.Location = new System.Drawing.Point(162, 49);
            this.bookControl1.Margin = new System.Windows.Forms.Padding(2);
            this.bookControl1.Name = "bookControl1";
            this.bookControl1.Size = new System.Drawing.Size(961, 611);
            this.bookControl1.TabIndex = 8;
            // 
            // dashboardControl1
            // 
            this.dashboardControl1.Location = new System.Drawing.Point(162, 48);
            this.dashboardControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dashboardControl1.Name = "dashboardControl1";
            this.dashboardControl1.Size = new System.Drawing.Size(961, 612);
            this.dashboardControl1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 661);
            this.Controls.Add(this.dashboardControl1);
            this.Controls.Add(this.bookControl1);
            this.Controls.Add(this.categoryControl1);
            this.Controls.Add(this.authorControl1);
            this.Controls.Add(this.memberControl1);
            this.Controls.Add(this.borrowControl1);
            this.Controls.Add(this.returnControl1);
            this.Controls.Add(this.reportControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnDashboard;
        private Controls.ReportControl reportControl1;
        private Controls.ReturnControl returnControl1;
        private Controls.BorrowControl borrowControl1;
        private Controls.MemberControl memberControl1;
        private Controls.AuthorControl authorControl1;
        private Controls.CategoryControl categoryControl1;
        private Controls.BookControl bookControl1;
        private Controls.DashboardControl dashboardControl1;
    }
}