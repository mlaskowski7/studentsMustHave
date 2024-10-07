using Microsoft.EntityFrameworkCore;
using StudentsMustHaveServer.Data;
using StudentsMustHaveServer.Models;
using StudentsMustHaveServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMustHaveServer.Tests.Repositories
{
    [TestFixture]
    public class StudentRepositoryTests
    {
        private StudentsDbContext context;
        private StudentRepository studentRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<StudentsDbContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            context = new StudentsDbContext(options);
            studentRepository = new StudentRepository(context);

            // insert some example data
            context.Students.AddRange(new List<Student>
            {
                new Student { Id = 1, Username = "user1", Password = "pswd1"},
                new Student { Id = 2, Username = "user2", Password = "pswd2"},
                new Student { Id = 3, Username = "user3", Password = "pswd3"},
                new Student { Id = 4, Username = "user4", Password = "pswd4"}
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
        public async Task GetByIdAsyncValidReturnsStudent()
        {
            var result = await studentRepository.GetByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(new Student { Id = 1, Username = "user1", Password = "pswd1" }));
        }

        [Test]
        public void GetByIdAsyncInvalidThrowsException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => studentRepository.GetByIdAsync(5));
        }

        [Test]
        public async Task GetByUsernameAsyncValidReturnsStudent()
        {
            var result = await studentRepository.GetByUsernameAsync("user1");

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(new Student { Id = 1, Username = "user1", Password = "pswd1" }));
        }

        [Test]
        public async Task GetByUsernameAsyncInvalidReturnsNull()
        {
            var result = await studentRepository.GetByUsernameAsync("user12132132");

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetAllAsyncReturnsAllStudents()
        {
            var result = await studentRepository.GetAllAsync();

            Assert.That(result.Count(), Is.EqualTo(4));
            Assert.That(result.ElementAt(0), Is.EqualTo(new Student { Id = 1, Username = "user1", Password = "pswd1" }));
            Assert.That(result.ElementAt(1), Is.EqualTo(new Student { Id = 2, Username = "user2", Password = "pswd2" }));
            Assert.That(result.ElementAt(2), Is.EqualTo(new Student { Id = 3, Username = "user3", Password = "pswd3" }));
            Assert.That(result.ElementAt(3), Is.EqualTo(new Student { Id = 4, Username = "user4", Password = "pswd4" }));
        }

        [Test]
        public async Task AddAsyncAddsStudent()
        {
            await studentRepository.AddAsync(new Student { Id = 5, Username = "user5", Password = "pswd5" });

            var result = await studentRepository.GetByIdAsync(5);
            Assert.That(result, Is.EqualTo(new Student { Id = 5, Username = "user5", Password = "pswd5" }));
        }

        [Test]
        public async Task UpdateChangesStudent()
        {
            var student = await studentRepository.GetByIdAsync(4);
            student.Username = "user5";
            student.Password = "pswd5";

            await studentRepository.UpdateAsync(student);
            var result = await studentRepository.GetByIdAsync(4);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(new Student { Id = 4, Username = "user5", Password = "pswd5" }));
        }

        [Test]
        public async Task DeleteRemovesStudent()
        {
            var student = await studentRepository.GetByIdAsync(4);

            await studentRepository.DeleteAsync(student);

            Assert.ThrowsAsync<ArgumentException>(() => studentRepository.GetByIdAsync(5));
        }
    }
}
