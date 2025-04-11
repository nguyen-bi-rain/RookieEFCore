
namespace EFCore.Models.DTOs.ProjectEmployee
{
    public class ProjectEmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public bool Enable { get; set; }
    }
}