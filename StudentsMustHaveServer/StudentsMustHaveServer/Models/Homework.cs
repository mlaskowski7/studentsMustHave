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
    public int Student_Id { get; set; }
    
    [ForeignKey("Student_ID")]
    public Student Student { get; set; }
    
    [Column("Subject_ID")]
    public int Subject_Id { get; set; }
    
    [ForeignKey("Subject_ID")]
    public Subject Subject { get; set; }
}