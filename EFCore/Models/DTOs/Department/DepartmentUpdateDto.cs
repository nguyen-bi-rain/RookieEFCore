using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.DTOs.Department
{
    public class DepartmentUpdateDto
    {
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}