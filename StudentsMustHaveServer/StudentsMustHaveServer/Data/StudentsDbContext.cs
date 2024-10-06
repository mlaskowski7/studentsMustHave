namespace StudentsMustHaveServer.Data;

using Microsoft.EntityFrameworkCore;
using StudentsMustHaveServer.Models;

public class StudentsDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Tech> Techs { get; set; }
    public DbSet<ProjectTech> ProjectTechs { get; set; }

    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectTech>()
            .HasKey(pt => new { pt.ProjectId, pt.TechId });

        modelBuilder.Entity<ProjectTech>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.ProjectTechs)
            .HasForeignKey(pt => pt.ProjectId);

        modelBuilder.Entity<ProjectTech>()
            .HasOne(pt => pt.Tech)
            .WithMany(t => t.ProjectTechs)
            .HasForeignKey(pt => pt.TechId);
        
    }
}