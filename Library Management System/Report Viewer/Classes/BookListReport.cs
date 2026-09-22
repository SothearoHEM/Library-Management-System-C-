using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Report_Viewer.Classes
{
    /// <summary>
    /// BookListReport - Report 1: Book List
    /// Contains: Book ID | ISBN | Title | Author | Category | Quantity
    /// </summary>
    public class BookListReport
    {
        public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
    }
}
