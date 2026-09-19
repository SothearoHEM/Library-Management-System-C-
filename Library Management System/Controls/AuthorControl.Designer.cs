namespace Library_Management_System.Controls
{
    partial class AuthorControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAuthorDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuthorEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthorPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboAuthorGender = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthorName = new System.Windows.Forms.TextBox();
            this.btnClearAuthor = new System.Windows.Forms.Button();
            this.btnDeleteAuthor = new System.Windows.Forms.Button();
            this.btnUpdateAuthor = new System.Windows.Forms.Button();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridAuthor = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAuthor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAuthorDescription);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAuthorEmail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAuthorPhone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboAuthorGender);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAuthorName);
            this.panel1.Controls.Add(this.btnClearAuthor);
            this.panel1.Controls.Add(this.btnDeleteAuthor);
            this.panel1.Controls.Add(this.btnUpdateAuthor);
            this.panel1.Controls.Add(this.btnAddAuthor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 228);
            this.panel1.TabIndex = 10;
            // 
            // txtAuthorDescription
            // 
            this.txtAuthorDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthorDescription.Location = new System.Drawing.Point(571, 104);
            this.txtAuthorDescription.Multiline = true;
            this.txtAuthorDescription.Name = "txtAuthorDescription";
            this.txtAuthorDescription.Size = new System.Drawing.Size(353, 64);
            this.txtAuthorDescription.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(469, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = " Description:";
            // 
            // txtAuthorEmail
            // 
            this.txtAuthorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthorEmail.Location = new System.Drawing.Point(128, 139);
            this.txtAuthorEmail.Name = "txtAuthorEmail";
            this.txtAuthorEmail.Size = new System.Drawing.Size(320, 26);
            this.txtAuthorEmail.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Email:";
            // 
            // txtAuthorPhone
            // 
            this.txtAuthorPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthorPhone.Location = new System.Drawing.Point(128, 98);
            this.txtAuthorPhone.Name = "txtAuthorPhone";
            this.txtAuthorPhone.Size = new System.Drawing.Size(320, 26);
            this.txtAuthorPhone.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Phone:";
            // 
            // comboAuthorGender
            // 
            this.comboAuthorGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAuthorGender.FormattingEnabled = true;
            this.comboAuthorGender.Location = new System.Drawing.Point(571, 53);
            this.comboAuthorGender.Name = "comboAuthorGender";
            this.comboAuthorGender.Size = new System.Drawing.Size(353, 28);
            this.comboAuthorGender.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(499, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Gender:";
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthorName.Location = new System.Drawing.Point(128, 55);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new System.Drawing.Size(320, 26);
            this.txtAuthorName.TabIndex = 30;
            // 
            // btnClearAuthor
            // 
            this.btnClearAuthor.BackColor = System.Drawing.Color.BurlyWood;
            this.btnClearAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAuthor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearAuthor.Location = new System.Drawing.Point(729, 185);
            this.btnClearAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearAuthor.Name = "btnClearAuthor";
            this.btnClearAuthor.Size = new System.Drawing.Size(195, 30);
            this.btnClearAuthor.TabIndex = 29;
            this.btnClearAuthor.Text = "Clear";
            this.btnClearAuthor.UseVisualStyleBackColor = false;
            // 
            // btnDeleteAuthor
            // 
            this.btnDeleteAuthor.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAuthor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteAuthor.Location = new System.Drawing.Point(490, 185);
            this.btnDeleteAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteAuthor.Name = "btnDeleteAuthor";
            this.btnDeleteAuthor.Size = new System.Drawing.Size(195, 30);
            this.btnDeleteAuthor.TabIndex = 28;
            this.btnDeleteAuthor.Text = "Delete";
            this.btnDeleteAuthor.UseVisualStyleBackColor = false;
            // 
            // btnUpdateAuthor
            // 
            this.btnUpdateAuthor.BackColor = System.Drawing.Color.BurlyWood;
            this.btnUpdateAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAuthor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateAuthor.Location = new System.Drawing.Point(253, 185);
            this.btnUpdateAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateAuthor.Name = "btnUpdateAuthor";
            this.btnUpdateAuthor.Size = new System.Drawing.Size(195, 30);
            this.btnUpdateAuthor.TabIndex = 27;
            this.btnUpdateAuthor.Text = "Update";
            this.btnUpdateAuthor.UseVisualStyleBackColor = false;
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.BackColor = System.Drawing.Color.BurlyWood;
            this.btnAddAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAuthor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddAuthor.Location = new System.Drawing.Point(20, 185);
            this.btnAddAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(195, 30);
            this.btnAddAuthor.TabIndex = 26;
            this.btnAddAuthor.Text = "Add";
            this.btnAddAuthor.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "AUTHOR MANAGEMENT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Author Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridAuthor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 233);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 347);
            this.panel2.TabIndex = 11;
            // 
            // dataGridAuthor
            // 
            this.dataGridAuthor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAuthor.Location = new System.Drawing.Point(2, 2);
            this.dataGridAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridAuthor.Name = "dataGridAuthor";
            this.dataGridAuthor.RowHeadersWidth = 51;
            this.dataGridAuthor.RowTemplate.Height = 24;
            this.dataGridAuthor.Size = new System.Drawing.Size(949, 345);
            this.dataGridAuthor.TabIndex = 0;
            // 
            // AuthorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AuthorControl";
            this.Size = new System.Drawing.Size(953, 580);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAuthor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAuthorName;
        private System.Windows.Forms.Button btnClearAuthor;
        private System.Windows.Forms.Button btnDeleteAuthor;
        private System.Windows.Forms.Button btnUpdateAuthor;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridAuthor;
        private System.Windows.Forms.TextBox txtAuthorEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthorPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboAuthorGender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthorDescription;
        private System.Windows.Forms.Label label5;
    }
}
