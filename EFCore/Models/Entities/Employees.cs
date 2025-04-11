using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCore.Models.Entities;
public class Employees : BaseEntity
{
    public Employees(string name, Guid departmentId, DateTime joinedDate)
    {
        Name = name;
        DepartmentId = departmentId;
        JoinedDate = joinedDate;
    }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }   
    public Guid DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public virtual Departments Department { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime JoinedDate { get; set; }
    public virtual Salaries Salary { get; set; }
    public virtual ICollection<ProjectEmployee> Projects { get; set; } 
}
