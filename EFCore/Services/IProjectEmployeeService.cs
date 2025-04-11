using EFCore.Models.DTOs.Project;
using EFCore.Models.DTOs.ProjectEmployee;

namespace EFCore.Services
{
    public interface IProjectEmployeeService 
    {
        Task<IEnumerable<ProjectEmployeeResponse>> GetAllProjectEmployee();
        Task<ProjectEmployeeResponse> GetProjectEmployeeByProjectId(Guid id);
        Task CreateProjectEmployee(ProjectEmployeeDto dto);
        Task DeleteProjectEmployee(Guid id);
        Task UpdateProjectEmployee(Guid id, ProjectEmployeeDto dto);
        
    }
}
