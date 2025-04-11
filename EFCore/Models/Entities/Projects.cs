using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.Entities;

public class Projects : BaseEntity
{
    public Projects(string name)
    {
        Name = name;
    }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public virtual ICollection<ProjectEmployee> Employees { get; set; }
}
