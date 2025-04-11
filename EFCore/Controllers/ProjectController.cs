using EFCore.Models;
using EFCore.Models.DTOs.Project;
using EFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProjectDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllAsync();
                return Ok(ApiResponse<IEnumerable<ProjectDto>>.Success(projects, "Projects retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ProjectDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            try
            {
                var project = await _projectService.GetByIdAsync(id);
                return Ok(ApiResponse<ProjectDto>.Success(project, "Project retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ProjectDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 500)]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDto dto)
        {
            try
            {
                var project = await _projectService.CreateAsync(dto);
                return Ok(ApiResponse<ProjectDto>.Success(project, "Project created successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<ProjectDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> Update([FromBody] ProjectUpdateDto dto)
        {
            try
            {
                await _projectService.UpdateAsync(dto);
                return Ok(ApiResponse<string>.Success("Project updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 204)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _projectService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Error(ex.Message, 400));
            }
        }
        
    }
}
