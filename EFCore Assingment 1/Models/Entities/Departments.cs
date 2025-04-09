using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.Entities;

public class Departments : Entity
{   
    public Departments(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public virtual ICollection<Employees> Employees { get; set; }
}
