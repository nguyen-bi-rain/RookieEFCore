using EFCore.Models;
using EFCore.Models.DTOs.Employee;
using EFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmployeeDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]

        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployee();
                return Ok(ApiResponse<IEnumerable<EmployeeDto>>.Success(employees, "Employees retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<EmployeeDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid data", 400));
                }
                var employee = await _employeeService.CreateEmployee(dto);
                return Ok(ApiResponse<EmployeeDto>.Success(employee, ""));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }

        [HttpGet("employee-department")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmployDepartmentResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        public async Task<IActionResult> GetEmployeeWithDepartment()
        {
            var employees = await _employeeService.GetAllEmployWithDepartment();
            return Ok(ApiResponse<IEnumerable<EmployDepartmentResponse>>.Success(employees, ""));
        }

        [HttpGet("getemployee")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmployeeProjectResponse>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        public async Task<IActionResult> GetEmployeeProjects()
        {
            try
            {
                var employees = await _employeeService.GetEmployeeProjects();
                if (employees == null || !employees.Any())
                {
                    return NotFound(ApiResponse<string>.Error("No employees found", 404));
                }
                return Ok(ApiResponse<IEnumerable<EmployeeProjectResponse>>.Success(employees, "Employees retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByid(id);
                return Ok(ApiResponse<EmployeeDto>.Success(employee, "Employee retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<EmployeeDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeUpdateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid data", 400));
                }
                await _employeeService.UpdateEmployee(dto);
                return Ok(ApiResponse<string>.Success("", "Employee updated successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Innvalid id"));
                }
                await _employeeService.DeleteEmployee(id);
                return NoContent();
            }catch (KeyNotFoundException ex)
            {
                return BadRequest(ApiResponse<string>.Error(ex.Message,400));
            }
        }
        [HttpGet("salary-join-date")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EmployeeDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        public async Task<IActionResult> GetEmployeeHaveSalaryJoinDate()
        {
            try
            {
                var employees = await _employeeService.GetEmployeeHaveSalaryJoinDate();
                if (employees == null || !employees.Any())
                {
                    return NotFound(ApiResponse<string>.Error("No employees found", 404));
                }
                return Ok(ApiResponse<IEnumerable<EmployeeSalaryResponse>>.Success(employees, "Employees retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
    }
}
