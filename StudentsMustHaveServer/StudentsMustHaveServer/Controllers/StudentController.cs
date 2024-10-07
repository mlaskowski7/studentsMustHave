using Microsoft.AspNetCore.Mvc;
using StudentsMustHaveServer.Data;
using StudentsMustHaveServer.DTO;
using StudentsMustHaveServer.Models;
using StudentsMustHaveServer.Services;
using StudentsMustHaveServer.Services.Interfaces;

namespace StudentsMustHaveServer.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(StudentsDbContext context)
        {
            this.studentService = new StudentService(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                IEnumerable<Student> students = await studentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Register([FromBody] StudentDTO body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                bool result = await studentService.RegisterNewStudentAsync(body.Username, body.Password);
                return Ok(result);
            }
            catch (ArgumentException argEx)
            {
                return StatusCode(404, argEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/login")]
        public async Task<ActionResult<bool>> Login([FromBody] StudentDTO body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                bool result = await studentService.LoginStudentAsync(body.Username, body.Password);
                return Ok(result);
            }
            catch (ArgumentException argEx)
            {
                return StatusCode(404, argEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
