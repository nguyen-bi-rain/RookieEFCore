using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models.Entities;

public class ProjectEmployee : BaseEntity
{
    [Column(Order = 0)]
    public Guid ProjectId { get; set; }
    [Column(Order = 1)]
    public Guid EmployeeId { get; set; }
    [Required]
    public bool Enable { get; set; }
    public virtual Projects Project { get; set; }
    public virtual Employees Employee { get; set; }
}
