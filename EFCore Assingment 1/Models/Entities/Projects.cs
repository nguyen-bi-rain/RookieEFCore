using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.Entities;

public class Projects : Entity
{
    public Projects(string name)
    {
        Name = name;
    }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public virtual ICollection<Project_Employee> Employees { get; set; }
}
