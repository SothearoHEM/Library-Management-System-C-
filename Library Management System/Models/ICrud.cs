namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// ICrud - Abstraction
    /// កំណត់ contract ដែល BLL classes ត្រូវអនុវត្ត (Add, Update, Delete)
    /// </summary>
    public interface ICrud
    {
        void Add();
        void Update();
        void Delete();
    }
}
