using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models.Entities;

public class Salaries : BaseEntity
{
    public Salaries(Guid employeeId, decimal salary)
    {
        EmployeeId = employeeId;
        Salary = salary;
    }

    public Guid EmployeeId { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; } 
    [ForeignKey("EmployeeId")]
    public virtual Employees Employee { get; set; }
}
