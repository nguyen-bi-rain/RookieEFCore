using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.EntityConfiguration
{
    public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.ToTable("Project_Employees");
            builder.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });
            builder.HasOne(pe => pe.Project)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(pe => pe.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(pe => pe.Employee)
                    .WithMany(e => e.Projects)
                    .HasForeignKey(pe => pe.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getutcdate()");
            builder.Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getutcdate()");
            builder.Property(p => p.ProjectId).IsRequired();
            builder.Property(p => p.EmployeeId).IsRequired();
            builder.Property(p => p.Enable).IsRequired().HasDefaultValue(true);
        }
    }
}
