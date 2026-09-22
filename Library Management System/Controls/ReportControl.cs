using Library_Management_System.Report_Viewer.Forms;
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
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
        }

        private void btnBookListReport_Click(object sender, EventArgs e)
        {
            BookListReportForm bookListReportForm = new BookListReportForm();
            bookListReportForm.ShowDialog();
        }

        private void btnBorrowReport_Click(object sender, EventArgs e)
        {
            BorrowingReportForm borrowingReportForm = new BorrowingReportForm();
            borrowingReportForm.ShowDialog();
        }

        private void btnOverdueBookReport_Click(object sender, EventArgs e)
        {
            OverDueReportForm overdueReportForm = new OverDueReportForm();
            overdueReportForm.ShowDialog();
        }

        private void btnMemberListReport_Click(object sender, EventArgs e)
        {
            MemberListReportForm memberListReportForm = new MemberListReportForm();
            memberListReportForm.ShowDialog();
        }
    }
}
