using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsMustHaveServer.Models;

[Table("Students")]
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Username { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    
    public ICollection<Homework> Homeworks { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Skill> Skills { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Student other)
        {
            return this.Id == other.Id &&
                this.Username == other.Username &&
                this.Password == other.Password;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Username, Password);
    }

}