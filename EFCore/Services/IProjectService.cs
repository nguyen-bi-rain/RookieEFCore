using EFCore.Models.DTOs.Project;

namespace EFCore.Services
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateAsync(ProjectCreateDto dto);
        Task UpdateAsync(ProjectUpdateDto dto);
        Task<ProjectDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
    
}
