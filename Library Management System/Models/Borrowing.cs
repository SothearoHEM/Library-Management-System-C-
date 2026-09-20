using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// Borrowing - កំណត់ត្រាការខ្ចីមួយដង (អាចមានសៀវភៅច្រើនក្នុងការខ្ចីមួយដង តាមរយៈ BorrowingDetail)
    /// </summary>
    public class Borrowing
    {
        public int BorrowID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }   // សម្រាប់បង្ហាញលទ្ធផល Join
        public int UserID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }       // Borrowed / Returned
        public string Note { get; set; }

        public List<BorrowingDetail> Details { get; set; } = new List<BorrowingDetail>();
    }
}
