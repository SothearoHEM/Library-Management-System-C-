using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Report_Viewer.Classes
{
    /// <summary>
    /// MemberListReport - Report 4: Member Report
    /// Contains: Member ID | Member Code | Name | Phone | Email
    /// </summary>
    public class MemberListReport
    {
        public int MemberID { get; set; }
        public string MemberCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
