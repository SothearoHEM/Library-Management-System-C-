namespace Library_Management_System.Report_Viewer.Forms
{
    partial class BorrowingReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.borrowingReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.borrowingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.borrowingReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.borrowingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Library_Management_System.Report Viewer.WiZards.BorrowingWizard.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1463, 779);
            this.reportViewer1.TabIndex = 0;
            // 
            // borrowingReportBindingSource
            // 
            this.borrowingReportBindingSource.DataSource = typeof(Library_Management_System.Report_Viewer.Classes.BorrowingReport);
            // 
            // borrowingBindingSource
            // 
            this.borrowingBindingSource.DataSource = typeof(LibraryManagementSystem.Models.Borrowing);
            // 
            // BorrowingReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 779);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BorrowingReportForm";
            this.Text = "BorrowingReportForm";
            this.Load += new System.EventHandler(this.BorrowingReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.borrowingReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource borrowingReportBindingSource;
        private System.Windows.Forms.BindingSource borrowingBindingSource;
    }
}