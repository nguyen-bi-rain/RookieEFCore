using EFCore.Models.DTOs.Salaries;

namespace EFCore.Services
{
    public interface ISalariesService
    {
        Task<SalariesCreateDto> CreateAsync(SalariesCreateDto dto);
        Task<SalariesUpdateDto> UpdateAsync( SalariesUpdateDto dto);
        Task<SalariesDto> GetByIdAsync(Guid id);
        Task<IEnumerable<SalariesDto>> GetAllAsync();   
        Task DeleteAsync(Guid id);

    }
}
