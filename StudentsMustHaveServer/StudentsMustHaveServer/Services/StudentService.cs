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

        public async Task<bool> DeleteAccountAsync(string username, string password)
        {
            Student? student = await studentRepository.GetByUsernameAsync(username);
            if (student == null) throw new ArgumentException("student with this username doesnt exist in db");
            if (!BCrypt.Net.BCrypt.Verify(password, student.Password)) return false;
            await studentRepository.DeleteAsync(student);
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await studentRepository.GetAllAsync();
        }

        public async Task<bool> LoginStudentAsync(string username, string password)
        {
            Student? student = await studentRepository.GetByUsernameAsync(username);

            if (student == null) throw new ArgumentException("student with this username doesnt exist in db");

            bool isValid = BCrypt.Net.BCrypt.Verify(password, student.Password);
            return isValid;
        }

        public async Task<bool> RegisterNewStudentAsync(string username, string password)
        {
            if ((await studentRepository.GetByUsernameAsync(username)) != null)
            {
                throw new ArgumentException("username is already taken");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            Student student = new Student
            {
                Username = username,
                Password = hashedPassword
            };

            await studentRepository.AddAsync(student);
            return true;
        }
    }
}
