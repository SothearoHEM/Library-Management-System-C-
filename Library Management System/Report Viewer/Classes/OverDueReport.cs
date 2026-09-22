using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Report_Viewer.Classes
{
    /// <summary>
    /// OverDueReport - Report 3: Overdue Report
    /// Contains: Member | Book | Due Date | Days Late | Fine
    /// </summary>
    public class OverDueReport
    {
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public DateTime DueDate { get; set; }
        public int DaysLate { get; set; }
        public decimal Fine { get; set; }
    }
}
