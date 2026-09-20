namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// BorrowingDetail - ជួយឱ្យការខ្ចីមួយដងអាចមានសៀវភៅច្រើនក្បាល
    /// </summary>
    public class BorrowingDetail
    {
        public int BorrowDetailID { get; set; }
        public int BorrowID { get; set; }
        public int BookID { get; set; }
        public string BookTitle { get; set; }   // សម្រាប់បង្ហាញលទ្ធផល Join
        public int Quantity { get; set; }
    }
}
