using StudentsMustHaveServer.Models;

namespace StudentsMustHaveServer.Services.Interfaces
{
    public interface IStudentService
    {
        Task<bool> RegisterNewStudentAsync(string username, string password);
        Task<bool> LoginStudentAsync(string username, string password);
        Task<bool> DeleteAccountAsync(string username, string password);
        Task<IEnumerable<Student>> GetAllStudentsAsync();

    }
}
