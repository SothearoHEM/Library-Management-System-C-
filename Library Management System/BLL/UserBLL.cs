using System.Collections.Generic;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL
{
    public class UserBLL : ICrud
    {
        private readonly UserDAL dal = new UserDAL();
        public User CurrentUser { get; set; }

        public void Add() => dal.AddUser(CurrentUser);
        public void Update() => dal.UpdateUser(CurrentUser);
        public void Delete() => dal.DeleteUser(CurrentUser.UserID);

        public List<User> GetAll() => dal.GetAllUsers();

        public User Login(string username, string password) => dal.Login(username, password);
    }
}
