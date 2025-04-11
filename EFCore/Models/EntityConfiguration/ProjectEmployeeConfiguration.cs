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
