using EFCore.Models.Entities;

namespace EFCore.Models.DTOs.ProjectEmployee;

public class ProjectEmployeeResponse
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public Employees Employees { get; set; }
    public bool Enable { get; set; }
}