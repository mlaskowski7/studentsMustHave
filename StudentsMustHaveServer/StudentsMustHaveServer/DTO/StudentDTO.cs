using System.ComponentModel.DataAnnotations;

namespace StudentsMustHaveServer.DTO
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
