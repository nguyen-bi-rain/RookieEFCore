using EFCore.Models.Entities;
using EFCore.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<Salaries> Salaries { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new SalaryConfiguration());

        modelBuilder.Entity<Project_Employee>()
            .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });
    }
}
