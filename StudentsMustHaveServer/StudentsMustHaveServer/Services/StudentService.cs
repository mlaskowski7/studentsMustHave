using StudentsMustHaveServer.Data;
using StudentsMustHaveServer.Models;
using StudentsMustHaveServer.Repositories;
using StudentsMustHaveServer.Services.Interfaces;

namespace StudentsMustHaveServer.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository studentRepository;

        public StudentService(StudentsDbContext context)
        {
            this.studentRepository = new StudentRepository(context);
        }

        public Task<bool> DeleteAccountAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginStudentAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterNewStudentAsync(string username, string password)
        {
            //if (await studentRepository.get)
            return false;
        }
    }
}
