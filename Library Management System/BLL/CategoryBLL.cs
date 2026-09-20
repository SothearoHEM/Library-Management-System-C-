using System.Collections.Generic;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL
{
    /// <summary>
    /// CategoryBLL - អនុវត្ត ICrud (Abstraction)
    /// </summary>
    public class CategoryBLL : ICrud
    {
        private readonly CategoryDAL dal = new CategoryDAL();
        public Category CurrentCategory { get; set; }

        public void Add() => dal.Add(CurrentCategory);
        public void Update() => dal.Update(CurrentCategory);
        public void Delete() => dal.Delete(CurrentCategory.CategoryID);

        public List<Category> GetAll() => dal.GetAll();
    }
}
