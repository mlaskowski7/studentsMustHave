using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsMustHaveServer.Models;

[Table("Projects")]
public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    
    public DateTime Deadline { get; set; }
    
    [Column("Student_ID")]
    public int StudentId { get; set; }
    
    [ForeignKey("Student_ID")]
    public Student Student { get; set; }
    
    public ICollection<ProjectTech> ProjectTechs { get; set; }
    
    
}