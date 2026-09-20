using System;
using System.Collections.Generic;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL
{
    /// <summary>
    /// BorrowBLL - Business Logic សម្រាប់ខ្ចី/សង សៀវភៅ និងគណនាប្រាក់ពិន័យ
    /// </summary>
    public class BorrowBLL
    {
        private readonly BorrowDAL dal = new BorrowDAL();

        public List<Borrowing> GetAllBorrowings() => dal.GetAllBorrowings();
        public List<BorrowingDetail> GetDetails(int borrowId) => dal.GetDetails(borrowId);
        public Borrowing GetBorrowById(int borrowId) => dal.GetBorrowById(borrowId);

        public bool BorrowBooks(Borrowing borrowing)
        {
            if (borrowing.Details == null || borrowing.Details.Count == 0)
                throw new Exception("សូមបន្ថែមសៀវភៅយ៉ាងតិចមួយក្បាល!");
            return dal.BorrowBooks(borrowing);
        }

        // គណនាថ្ងៃហួសកំណត់ និងប្រាក់ពិន័យ ($0.50/ថ្ងៃ)
        public decimal CalculateFine(DateTime dueDate, DateTime returnDate)
        {
            int lateDays = (returnDate - dueDate).Days;
            return lateDays > 0 ? lateDays * 0.50m : 0;
        }

        public decimal ReturnBooks(int borrowId, DateTime dueDate, DateTime returnDate, string note = "")
        {
            return dal.ReturnBooks(borrowId, dueDate, returnDate, note);
        }
    }
}
