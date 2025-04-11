using EFCore.Models.DTOs.Employee;
using EFCore.Models.Entities;
using Microsoft.Data.SqlClient;

namespace EFCore.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employees>
{
    Task<IEnumerable<EmployeeSalaryResponse>> GetAllWithSalary(string query, SqlParameter[] parameters);

}