using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StudentsMustHaveServer.Models;

public class Tech
{
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    public ICollection<Skill> Skills { get; set; }
    public ICollection<ProjectTech> ProjectTechs { get; set; }
}