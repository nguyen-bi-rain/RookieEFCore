using AutoMapper;
using EFCore.Models.DTOs.Department;
using EFCore.Models.Entities;
using EFCore.Repositories;

namespace EFCore.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly DepartmentsRepository _departmentsRepository;
        private readonly IMapper _mapper;
        public DepartmentsService(DepartmentsRepository departmentsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _departmentsRepository = departmentsRepository;
        }
        public async Task<DepartmentDto> CreateAsync(DepartmentCreateDto dto)
        {
            var department =  _mapper.Map<Departments>(dto);
            await _departmentsRepository.Add(department);
            await _departmentsRepository.SaveChangeAsync();
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task DeleteAsync(Guid id)
        {
            var department = await _departmentsRepository.GetById(id);
            if (department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }   
            await _departmentsRepository.Delete(department);
            await _departmentsRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentsRepository.GetAll();
            if(!departments.Any())
            {
                throw new KeyNotFoundException("Departments not found");
            }
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);    
        }

        public async Task<DepartmentDto?> GetByIdAsync(Guid id)
        {
            var department = await _departmentsRepository.GetById(id);
            if(department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> UpdateAsync(DepartmentUpdateDto dto)
        {
            var department = await _departmentsRepository.GetById(dto.Id);
            if (department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }
            await _departmentsRepository.Update(department);
            await _departmentsRepository.SaveChangeAsync();
            return _mapper.Map<DepartmentDto>(department);
        }
    }
}
