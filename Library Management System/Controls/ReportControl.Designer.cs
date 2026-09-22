namespace Library_Management_System.Controls
{
    partial class ReportControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMemberListReport = new System.Windows.Forms.Button();
            this.btnOverdueBookReport = new System.Windows.Forms.Button();
            this.btnBorrowReport = new System.Windows.Forms.Button();
            this.btnBookListReport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMemberListReport
            // 
            this.btnMemberListReport.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMemberListReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberListReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMemberListReport.Location = new System.Drawing.Point(375, 417);
            this.btnMemberListReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMemberListReport.Name = "btnMemberListReport";
            this.btnMemberListReport.Size = new System.Drawing.Size(519, 62);
            this.btnMemberListReport.TabIndex = 33;
            this.btnMemberListReport.Text = "MEMBER LIST";
            this.btnMemberListReport.UseVisualStyleBackColor = false;
            this.btnMemberListReport.Click += new System.EventHandler(this.btnMemberListReport_Click);
            // 
            // btnOverdueBookReport
            // 
            this.btnOverdueBookReport.BackColor = System.Drawing.Color.BurlyWood;
            this.btnOverdueBookReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOverdueBookReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOverdueBookReport.Location = new System.Drawing.Point(375, 326);
            this.btnOverdueBookReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOverdueBookReport.Name = "btnOverdueBookReport";
            this.btnOverdueBookReport.Size = new System.Drawing.Size(519, 62);
            this.btnOverdueBookReport.TabIndex = 32;
            this.btnOverdueBookReport.Text = "OVERDUE BOOK REPORT";
            this.btnOverdueBookReport.UseVisualStyleBackColor = false;
            this.btnOverdueBookReport.Click += new System.EventHandler(this.btnOverdueBookReport_Click);
            // 
            // btnBorrowReport
            // 
            this.btnBorrowReport.BackColor = System.Drawing.Color.BurlyWood;
            this.btnBorrowReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBorrowReport.Location = new System.Drawing.Point(375, 238);
            this.btnBorrowReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrowReport.Name = "btnBorrowReport";
            this.btnBorrowReport.Size = new System.Drawing.Size(519, 62);
            this.btnBorrowReport.TabIndex = 31;
            this.btnBorrowReport.Text = "BORROWING REPORT";
            this.btnBorrowReport.UseVisualStyleBackColor = false;
            this.btnBorrowReport.Click += new System.EventHandler(this.btnBorrowReport_Click);
            // 
            // btnBookListReport
            // 
            this.btnBookListReport.BackColor = System.Drawing.Color.BurlyWood;
            this.btnBookListReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookListReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBookListReport.Location = new System.Drawing.Point(375, 144);
            this.btnBookListReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBookListReport.Name = "btnBookListReport";
            this.btnBookListReport.Size = new System.Drawing.Size(519, 62);
            this.btnBookListReport.TabIndex = 30;
            this.btnBookListReport.Text = "BOOK LIST REPORT";
            this.btnBookListReport.UseVisualStyleBackColor = false;
            this.btnBookListReport.Click += new System.EventHandler(this.btnBookListReport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(587, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 32);
            this.label7.TabIndex = 34;
            this.label7.Text = "Report";
            // 
            // ReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMemberListReport);
            this.Controls.Add(this.btnOverdueBookReport);
            this.Controls.Add(this.btnBorrowReport);
            this.Controls.Add(this.btnBookListReport);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReportControl";
            this.Size = new System.Drawing.Size(1271, 714);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMemberListReport;
        private System.Windows.Forms.Button btnOverdueBookReport;
        private System.Windows.Forms.Button btnBorrowReport;
        private System.Windows.Forms.Button btnBookListReport;
        private System.Windows.Forms.Label label7;
    }
}
