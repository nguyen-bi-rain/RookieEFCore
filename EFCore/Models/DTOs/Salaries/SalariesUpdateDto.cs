
namespace EFCore.Models.DTOs.Salaries;

public class SalariesUpdateDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal Salary { get; set; }
}