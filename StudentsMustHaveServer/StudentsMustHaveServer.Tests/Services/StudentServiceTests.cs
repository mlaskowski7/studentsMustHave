using Microsoft.EntityFrameworkCore;
using StudentsMustHaveServer.Data;
using StudentsMustHaveServer.Models;
using StudentsMustHaveServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMustHaveServer.Tests.Services
{
    [TestFixture]
    public class StudentServiceTests
    {
        private StudentsDbContext context;
        private StudentService studentService;


        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudentsDbContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            context = new StudentsDbContext(options);
            studentService = new StudentService(context);

            // insert some example data
            context.Students.AddRange(new List<Student>
            {
                new Student { Id = 1, Username = "user1", Password = BCrypt.Net.BCrypt.HashPassword("pswd1") },
                new Student { Id = 2, Username = "user2", Password = BCrypt.Net.BCrypt.HashPassword("pswd2") },
                new Student { Id = 3, Username = "user3", Password = BCrypt.Net.BCrypt.HashPassword("pswd3") },
                new Student { Id = 4, Username = "user4", Password = BCrypt.Net.BCrypt.HashPassword("pswd4") }
            });
            context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task LoginStudentAsyncValidReturnsTrue()
        {
            bool result = await studentService.LoginStudentAsync("user1", "pswd1");
            Assert.IsTrue(result);
        }

        [Test]
        public async Task LoginStudentAsyncInvalidReturnsFalse()
        {
            bool result = await studentService.LoginStudentAsync("user1", "pswd4");
            Assert.IsFalse(result);
        }

        [Test]
        public void LoginStudentAsyncWrongUserThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => studentService.LoginStudentAsync("user9021312", "pswd4"));
        }

        [Test]
        public async Task RegisterStudentAsyncValidReturnsTrue()
        {
            bool result = await studentService.RegisterNewStudentAsync("user10", "pswd10");
            Assert.IsTrue(result);
        }

        [Test]
        public void RegisterStudentAsyncTakenUsernameThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => studentService.RegisterNewStudentAsync("user1", "pswd4"));
        }

        [Test]
        public async Task DeleteAccountValidReturnsTrue()
        {
            var result = await studentService.DeleteAccountAsync("user3", "pswd3");
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteAccountInvalidUserThrowsArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => studentService.DeleteAccountAsync("user9", "pswd4"));
        }

        [Test]
        public async Task DeleteAccountInvalidPswdReturnsFalse()
        {
            var result = await studentService.DeleteAccountAsync("user3", "pswd4");
            Assert.IsFalse(result);
        }
    }
}
