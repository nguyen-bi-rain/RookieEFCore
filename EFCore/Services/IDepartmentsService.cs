using EFCore.Models.DTOs.Department;

namespace EFCore.Services
{
    public interface IDepartmentsService
    {
        Task<DepartmentDto> CreateAsync(DepartmentCreateDto dto);
        Task<DepartmentDto> UpdateAsync(DepartmentUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<DepartmentDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<DepartmentDto>> GetAllAsync();

    }
}
