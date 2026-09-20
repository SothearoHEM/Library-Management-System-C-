namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// User (Staff) : Person -> Inheritance
    /// តំណាងឱ្យបុគ្គលិកដែលចូលប្រើប្រព័ន្ធ (Login)
    /// </summary>
    public class User : Person
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }     // Admin / Staff
        public bool IsActive { get; set; }
    }
}
