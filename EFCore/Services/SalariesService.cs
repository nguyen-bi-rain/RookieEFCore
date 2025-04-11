using AutoMapper;
using EFCore.Models.DTOs.Salaries;
using EFCore.Models.Entities;
using EFCore.Repositories;

namespace EFCore.Services;

public class SalariesService : ISalariesService
{
    private readonly SalariesRepository _salariesRepository;
    private readonly IMapper _mapper;
    public SalariesService(SalariesRepository salariesRepository, IMapper mapper)
    {
        _salariesRepository = salariesRepository;
        _mapper = mapper;
    }
    public async Task<SalariesCreateDto> CreateAsync(SalariesCreateDto dto)
    {
        var salary = _mapper.Map<Salaries>(dto);
        await _salariesRepository.Add(salary);
        await _salariesRepository.SaveChangeAsync();
        return dto;
    }

    public async Task DeleteAsync(Guid id)
    {
        var salary = await  _salariesRepository.GetById(id);
        
        if(salary == null)
        {
            throw new KeyNotFoundException("Salary not found");
        }
        await _salariesRepository.Delete(salary);
        await _salariesRepository.SaveChangeAsync();
    }

    public async Task<IEnumerable<SalariesDto>> GetAllAsync()
    {
        var salaries = await _salariesRepository.GetAll();
        if (!salaries.Any())
        {
            throw new KeyNotFoundException("No salaries found");
        }
        return _mapper.Map<IEnumerable<SalariesDto>>(salaries);
    }

    public async Task<SalariesDto> GetByIdAsync(Guid id)
    {
        var salary = await _salariesRepository.GetById(id);
        if (salary == null)
        {
            throw new KeyNotFoundException("Salary not found");
        }
        return _mapper.Map<SalariesDto>(salary);
    }

    public async Task<SalariesUpdateDto> UpdateAsync(SalariesUpdateDto dto)
    {
        var salary = await _salariesRepository.GetById(dto.Id);
        if (salary == null)
        {
            throw new KeyNotFoundException("Salary not found");
        }
        _mapper.Map(dto, salary);
        await _salariesRepository.Update(salary);
        await _salariesRepository.SaveChangeAsync();
        return dto;
    }
}