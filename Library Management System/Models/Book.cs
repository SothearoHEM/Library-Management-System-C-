namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// Book - Encapsulation
    /// ទិន្នន័យត្រូវបានការពារ ហើយបង្ហាញតាមរយៈ Properties (get; set;)
    /// </summary>
    public class Book
    {
        public int BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }      // សម្រាប់បង្ហាញលទ្ធផល Join
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }    // សម្រាប់បង្ហាញលទ្ធផល Join
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string ShelfLocation { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
