using Microsoft.EntityFrameworkCore;
using StudentsMustHaveServer.Data;
using StudentsMustHaveServer.Models;
using StudentsMustHaveServer.Repositories.Interfaces;

namespace StudentsMustHaveServer.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentsDbContext context) : base(context)
        {

        }

        public async Task<Student?> GetByUsernameAsync(string username)
        {
            return await context.Set<Student>().FirstOrDefaultAsync(s => s.Username == username);
        }
    }
}
