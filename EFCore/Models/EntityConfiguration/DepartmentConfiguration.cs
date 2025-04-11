using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCore.Models.EntityConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            // Configure cascade delete behavior
            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            // Define table name
            builder.ToTable("Departments");

            builder.Property(d => d.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            // Define properties
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();
            builder.HasData(
                new Departments("Software Development "),
                new Departments("Finance"),
                new Departments("Accountant"),
                new Departments("HR")
            );

        }
    }
}
