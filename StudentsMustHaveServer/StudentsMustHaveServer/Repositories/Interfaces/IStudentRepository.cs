using StudentsMustHaveServer.Models;

namespace StudentsMustHaveServer.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student?> GetByUsernameAsync(string username);
    }
}
