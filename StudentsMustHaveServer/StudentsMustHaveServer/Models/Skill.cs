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
    public int Tech_Id { get; set; }
    
    [ForeignKey("Tech_ID")]
    public Tech Tech { get; set; }
    
    [Column("Student_ID")]
    public int Student_Id { get; set; }
    
    [ForeignKey("Student_ID")]
    public Student Student { get; set; }
}