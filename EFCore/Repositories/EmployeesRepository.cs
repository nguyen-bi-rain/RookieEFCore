using EFCore.Models.Data;
using EFCore.Models.DTOs.Employee;
using EFCore.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories
{
    public class EmployeesRepository : BaseRepository<Employees>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<EmployeeSalaryResponse>> GetAllWithSalary(string query, SqlParameter[] parameters)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddRange(parameters);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var employees = new List<EmployeeSalaryResponse>();
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new EmployeeSalaryResponse
                            {
                                Name = reader["Name"].ToString(),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                JoinedDate = Convert.ToDateTime(reader["JoinedDate"]),
                                DepartmentId = Guid.Parse(reader["DepartmentId"].ToString()),
                            });
                        }

                        if (!employees.Any())
                        {
                            throw new KeyNotFoundException("No employees found with projects");
                        }

                        return employees;
                    }
                }
            }
        }
    }
}
