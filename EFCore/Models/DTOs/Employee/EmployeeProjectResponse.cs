using EFCore.Models.Entities;

namespace EFCore.Models.DTOs.Employee
{
    public class EmployeeProjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Projects> ProjectName { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Enable { get; set; }
    }
}
