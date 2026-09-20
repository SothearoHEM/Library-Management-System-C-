using System;

namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// Return - កំណត់ត្រាការសងសៀវភៅ (1-to-1 ជាមួយ Borrowing)
    /// </summary>
    public class Return
    {
        public int ReturnID { get; set; }
        public int BorrowID { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal Fine { get; set; }
        public string Note { get; set; }
    }
}
