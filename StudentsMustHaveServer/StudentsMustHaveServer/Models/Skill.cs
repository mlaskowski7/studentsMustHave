using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsMustHaveServer.Models;

[Table("Skills")]
public class Skill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Level { get; set; }
    
    [Column("Tech_ID")]
    public int TechId { get; set; }
    
    [ForeignKey(nameof(TechId))]
    public Tech Tech { get; set; }
    
    [Column("Student_ID")]
    public int StudentId { get; set; }
    
    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; }
}