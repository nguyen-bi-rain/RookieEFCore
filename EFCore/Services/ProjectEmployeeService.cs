using AutoMapper;
using EFCore.Models.DTOs.Project;
using EFCore.Models.DTOs.ProjectEmployee;
using EFCore.Models.Entities;
using EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly IMapper _mapper;

        public ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _projectEmployeeRepository = projectEmployeeRepository;
        }
        public async Task CreateProjectEmployee(ProjectEmployeeDto dto)
        {
            var model = _mapper.Map<ProjectEmployee>(dto);
            await _projectEmployeeRepository.Add(model);
            await _projectEmployeeRepository.SaveChangeAsync();
        }


        public async Task DeleteProjectEmployee(Guid id)
        {
            var projectEmployee = await _projectEmployeeRepository.GetProjectEmployeeByProjectIds(id);
            if (projectEmployee == null)
            {
                throw new KeyNotFoundException("Project employee not found");
            }
            await _projectEmployeeRepository.Delete(projectEmployee);
            await _projectEmployeeRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<ProjectEmployeeResponse>> GetAllProjectEmployee()
        {
            var projectEmployees = _projectEmployeeRepository.GetAllWithQueryAble().Include(pe => pe.Project)
                .Include(pe => pe.Employee)
                .Select(pe => new ProjectEmployeeResponse
                {
                    ProjectName = pe.Project.Name,
                    Employees = pe.Employee,
                    Enable = pe.Enable
                });

            if (projectEmployees == null || !projectEmployees.Any())
            {
                throw new KeyNotFoundException("No project employees found");
            }

            return await projectEmployees.ToListAsync();
        }

        public async Task<ProjectEmployeeResponse> GetProjectEmployeeByProjectId(Guid id)
        {
            var projectEmployee = await _projectEmployeeRepository.GetAllWithQueryAble().Include(pe => pe.Project)
                .Include(pe => pe.Employee)
                .Where(pe => pe.Id == id)
                .Select(pe => new ProjectEmployeeResponse
                {
                    ProjectName = pe.Project.Name,
                    Employees = pe.Employee,
                    Enable = pe.Enable
                }).FirstOrDefaultAsync();

            if (projectEmployee == null)
            {
                throw new KeyNotFoundException("Project employee not found");
            }

            return projectEmployee;
        }

        public async Task UpdateProjectEmployee(Guid id, ProjectEmployeeDto dto)
        {
            var projectEmployee = await _projectEmployeeRepository.GetProjectEmployeeByProjectIds(id);
            if (projectEmployee == null)
            {
                throw new KeyNotFoundException("Project employee not found");
            }
            _mapper.Map(projectEmployee,dto);
            await _projectEmployeeRepository.Update(projectEmployee);
            await _projectEmployeeRepository.SaveChangeAsync();
        }
    }
}
