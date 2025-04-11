namespace EFCore.Models.DTOs.Employee
{
    public class EmployDepartmentResponse
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public required string Name { get; set; }
        public string DepartmentName { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
