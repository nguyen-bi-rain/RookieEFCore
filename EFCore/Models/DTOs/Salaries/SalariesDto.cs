using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Models.DTOs.Salaries
{
    public class SalariesDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
