using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Models;
using EFCore.Models.DTOs.Salaries;
using EFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalariesService _salaryService;
        public SalaryController(ISalariesService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<SalariesDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> GetAllSalaries()
        {
            try
            {
                var salaries = await _salaryService.GetAllAsync();
                return Ok(ApiResponse<IEnumerable<SalariesDto>>.Success(salaries, "Salaries retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryById(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid ID", 400));
                }
                var salary = await _salaryService.GetByIdAsync(id);
                return Ok(ApiResponse<SalariesDto>.Success(salary, "Salary retrieved successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<SalariesDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        public async Task<IActionResult> CreateSalary([FromBody] SalariesCreateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid data", 400));
                }
                var salary = await _salaryService.CreateAsync(dto);
                
                return Ok(ApiResponse<SalariesCreateDto>.Success(salary, "Salary created successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<SalariesDto>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 404)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        public async Task<IActionResult> UpdateSalary([FromBody] SalariesUpdateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid data", 400));
                }
                var salary = await _salaryService.UpdateAsync(dto);
                return Ok(ApiResponse<SalariesUpdateDto>.Success(salary, "Salary updated successfully"));
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
        public async Task<IActionResult> DeleteSalary(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ApiResponse<string>.Error("Invalid ID", 400));
                }
                await _salaryService.DeleteAsync(id);
                return Ok(ApiResponse<string>.Success("Salary deleted successfully", "Salary deleted successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Error(ex.Message, 404));
            }
        }
    }
}