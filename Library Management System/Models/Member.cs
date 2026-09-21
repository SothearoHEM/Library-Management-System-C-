using System;

namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// Member : Person -> Inheritance
    /// </summary>
    public class Member : Person
    {
        public int MemberID { get; set; }
        public string MemberCode { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
