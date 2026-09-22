using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Report_Viewer.Classes
{
    /// <summary>
    /// BorrowingReport - Report 2: Borrowing Report
    /// Contains: Borrow ID | Member | Book | Borrow Date | Due Date | Status
    /// </summary>
    public class BorrowingReport
    {
        public int BorrowID { get; set; }
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
