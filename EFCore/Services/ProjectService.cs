using AutoMapper;
using EFCore.Models.DTOs.Project;
using EFCore.Models.Entities;
using EFCore.Repositories;

namespace EFCore.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectsRepository _projectsRepository;
        private readonly IMapper _mapper;

        public ProjectService(ProjectsRepository projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> CreateAsync(ProjectCreateDto dto)
        {
            var project = _mapper.Map<Projects>(dto);
            await _projectsRepository.Add(project);
            await _projectsRepository.SaveChangeAsync();
            return _mapper.Map<ProjectDto>(project);

        }

        public async Task DeleteAsync(Guid id)
        {
            var project = await _projectsRepository.GetById(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }
            await _projectsRepository.Delete(project);
            await _projectsRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _projectsRepository.GetAll();
            if (!projects.Any())
            {
                throw new KeyNotFoundException("No projects found");
            }
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);

        }

        public async Task<ProjectDto> GetByIdAsync(Guid id)
        {
            var project = await _projectsRepository.GetById(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }
            return _mapper.Map<ProjectDto>(project);
        }


        public async Task UpdateAsync(ProjectUpdateDto dto)
        {
            var project = _mapper.Map<Projects>(dto);
            await _projectsRepository.Update(project);
            await _projectsRepository.SaveChangeAsync();

        }
    }
}
