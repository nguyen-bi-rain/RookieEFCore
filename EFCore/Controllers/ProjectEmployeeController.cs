using EFCore.Models;
using EFCore.Models.DTOs.ProjectEmployee;
using EFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController : ControllerBase
    {
        private readonly IProjectEmployeeService _projectEmployeeService;
        
        public ProjectEmployeeController(IProjectEmployeeService projectEmployeeService)
        {
            _projectEmployeeService = projectEmployeeService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProjectEmployeeResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetAllProjectEmployee()
        {
            try
            {
                var projectEmployees = await _projectEmployeeService.GetAllProjectEmployee();
                return Ok(ApiResponse<IEnumerable<ProjectEmployeeResponse>>.Success(projectEmployees, "Project employees retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ProjectEmployeeResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> CreateProjectEmployee([FromBody] ProjectEmployeeDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid data", 400));
                }
                await _projectEmployeeService.CreateProjectEmployee(dto);
                return Ok(ApiResponse<string>.Success("", "Project employee created successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> DeleteProjectEmployee(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid ID", 400));
                }
                await _projectEmployeeService.DeleteProjectEmployee(id);
                return Ok(ApiResponse<string>.Success("", "Project employee deleted successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> UpdateProjectEmployee(Guid id, [FromBody] ProjectEmployeeDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid data", 400));
                }
                await _projectEmployeeService.UpdateProjectEmployee(id, dto);
                return Ok(ApiResponse<string>.Success("", "Project employee updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ProjectEmployeeResponse>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetProjectEmployeeByProjectId(Guid id)
        {
            try
            {
                var projectEmployee = await _projectEmployeeService.GetProjectEmployeeByProjectId(id);
                return Ok(ApiResponse<ProjectEmployeeResponse>.Success(projectEmployee, "Project employee retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
    }
}
