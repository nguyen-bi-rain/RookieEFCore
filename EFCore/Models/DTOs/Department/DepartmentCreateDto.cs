using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.DTOs.Department
{
    public class DepartmentCreateDto
    {
        [Required]
        public required string Name { get; set; }
    }
}