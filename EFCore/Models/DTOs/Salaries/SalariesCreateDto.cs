using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.DTOs.Salaries
{
    public class SalariesCreateDto
    {
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public decimal Salary { get; set; }

    }
}
