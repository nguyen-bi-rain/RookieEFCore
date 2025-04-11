
namespace EFCore.Models.DTOs.Employee;

public class EmployeeSalaryResponse
{
    public required string Name { get; set; }   
    public Guid DepartmentId { get; set; }
    public DateTime JoinedDate { get; set; }    
    public decimal Salary { get; set; }
}