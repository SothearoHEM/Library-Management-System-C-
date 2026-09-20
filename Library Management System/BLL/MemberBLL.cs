using System.Collections.Generic;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.BLL
{
    public class MemberBLL : ICrud
    {
        private readonly MemberDAL dal = new MemberDAL();
        public Member CurrentMember { get; set; }

        public void Add() => dal.AddMember(CurrentMember);
        public void Update() => dal.UpdateMember(CurrentMember);
        public void Delete() => dal.DeleteMember(CurrentMember.MemberID);

        public List<Member> GetAll() => dal.GetAllMembers();
        public List<Member> Search(string keyword) => dal.SearchMembers(keyword);
    }
}
