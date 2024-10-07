using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsMustHaveServer.Models;

public class Homework
{
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    public DateTime Deadline { get; set; }
    
    [MaxLength(255)]
    public string Description { get; set; }
    
    [Column("Student_ID")]
    public int StudentId { get; set; }
    
    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; }
    
    [Column("Subject_ID")]
    public int SubjectId { get; set; }
    
    [ForeignKey(nameof(SubjectId))]
    public Subject Subject { get; set; }
}