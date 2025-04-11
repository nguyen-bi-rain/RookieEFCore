using EFCore.Models.DTOs.Employee;

namespace EFCore.Services
{
    public interface IEmployeeService 
    {
        Task<EmployeeDto> CreateEmployee(EmployeeCreateDto dto);
        Task<EmployeeDto> GetEmployeeByid(Guid id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployee();
        Task DeleteEmployee(Guid id);
        Task UpdateEmployee(EmployeeUpdateDto dto);
        Task<IEnumerable<EmployDepartmentResponse>> GetAllEmployWithDepartment();
        Task<IEnumerable<EmployeeProjectResponse>> GetEmployeeProjects();
        Task<IEnumerable<EmployeeSalaryResponse>> GetEmployeeHaveSalaryJoinDate();
    }
}
