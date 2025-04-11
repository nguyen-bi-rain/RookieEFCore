using EFCore.Models.Entities;

namespace EFCore.Models.Data;

public static class DataSeeder
{
    public static void SeedDepartment(IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); 
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Departments("Software Development"),
                new Departments("Finance"),
                new Departments("Accountant"),
                new Departments("HR")
            );
            context.SaveChanges();
        }
    }
}
