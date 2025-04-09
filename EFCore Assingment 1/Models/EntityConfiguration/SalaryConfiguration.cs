using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.EntityConfiguration
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salaries>
    {
        public void Configure(EntityTypeBuilder<Salaries> builder)
        {
            // Define table name
            builder.ToTable("Salary");
            // Define primary key

            // Define properties
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");
            builder.Property(s => s.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(s => s.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();
        }
    }
}
