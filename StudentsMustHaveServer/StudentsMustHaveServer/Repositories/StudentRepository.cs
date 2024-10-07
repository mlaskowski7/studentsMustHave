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
    }
}
