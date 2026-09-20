using System.Collections.Generic;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL
{
    public class AuthorBLL : ICrud
    {
        private readonly AuthorDAL dal = new AuthorDAL();
        public Author CurrentAuthor { get; set; }

        public void Add() => dal.Add(CurrentAuthor);
        public void Update() => dal.Update(CurrentAuthor);
        public void Delete() => dal.Delete(CurrentAuthor.AuthorID);

        public List<Author> GetAll() => dal.GetAll();
    }
}
