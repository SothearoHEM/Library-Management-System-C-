using System.Collections.Generic;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL
{
    /// <summary>
    /// BookBLL - អនុវត្ត ICrud (Abstraction) + Business Rules
    /// </summary>
    public class BookBLL : ICrud
    {
        private readonly BookDAL dal = new BookDAL();
        public Book CurrentBook { get; set; }

        public void Add()
        {
            if (string.IsNullOrWhiteSpace(CurrentBook.Title))
                throw new System.Exception("ចំណងជើងសៀវភៅមិនអាចទទេបានទេ!");
            CurrentBook.AvailableQuantity = CurrentBook.Quantity; // សៀវភៅថ្មី = នៅសល់ស្មើនឹងសរុប
            dal.AddBook(CurrentBook);
        }

        public void Update() => dal.UpdateBook(CurrentBook);
        public void Delete() => dal.DeleteBook(CurrentBook.BookID);

        public List<Book> GetAll() => dal.GetAllBooks();

        // Polymorphism (Method Overloading)
        public List<Book> Search(string title) => dal.Search(title);
        public List<Book> Search(string title, int categoryId) => dal.Search(title, categoryId);
    }
}
