namespace EFCore.Models.DTOs.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public required string Name { get; set; }
        public DateTime JoinedDate { get; set; }

    }
}