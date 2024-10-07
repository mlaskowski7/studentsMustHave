using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsMustHaveServer.Models;

public class ProjectTech
{
    [Key, Column("Project_ID")]
    public int ProjectId { get; set; }
    
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
    
    [Key, Column("Tech_ID")]
    public int TechId { get; set; }
    
    [ForeignKey(nameof(TechId))]
    public Tech Tech { get; set; }
    
}