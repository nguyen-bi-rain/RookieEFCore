using EFCore.Models;
using EFCore.Models.DTOs.Department;
using EFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;
        public DepartmentController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<DepartmentDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetAllDepartment()
        {
            try{
                var departments = await _departmentsService.GetAllAsync();
                return Ok(ApiResponse<IEnumerable<DepartmentDto>>.Success(departments, "Departments retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DepartmentDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            try
            {
                var department = await _departmentsService.GetByIdAsync(id);
                return Ok(ApiResponse<DepartmentDto>.Success(department, "Department retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<DepartmentDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 500)]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDto dto)
        {
            try
            {
                var department = await _departmentsService.CreateAsync(dto);
                return Ok(ApiResponse<DepartmentDto>.Success(department, "Department created successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Error(ex.Message, 400));
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<DepartmentDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string>), 500)]
        public async Task<IActionResult> Update([FromBody] DepartmentUpdateDto dto)
        {
            try
            {
                var department = await _departmentsService.UpdateAsync(dto);
                return Ok(ApiResponse<DepartmentDto>.Success(department, "Department updated successfully"));
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
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _departmentsService.DeleteAsync(id);
                return Ok(ApiResponse<string>.Success("Department deleted successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
    }
}