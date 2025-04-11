using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } 
    public DateTime? CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }

}
