using AutoMapper;
using EFCore.Models.DTOs.Employee;
using EFCore.Models.Entities;
using EFCore.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeesRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeesRepository = employeesRepository;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeCreateDto dto)
        {
            var model = _mapper.Map<Employees>(dto);
            await _employeesRepository.Add(model);
            await _employeesRepository.SaveChangeAsync();
            return _mapper.Map<EmployeeDto>(model);

        }

        public async Task DeleteEmployee(Guid id)
        {
            var employee = await _employeesRepository.GetById(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            await _employeesRepository.Delete(employee);
            await _employeesRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<EmployDepartmentResponse>> GetAllEmployWithDepartment()
        {
            var employeesWithDepartmentsQuery = _employeesRepository.GetAllWithQueryAble().Include(e => e.Department)
                .Select(e => new EmployDepartmentResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.Name
                });

            if (await employeesWithDepartmentsQuery.CountAsync() == 0)
            {
                throw new KeyNotFoundException("No employees found with departments");
            }

            var employeesWithDepartments = await employeesWithDepartmentsQuery.ToListAsync();
            return employeesWithDepartments;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployee()
        {
            var employees = await _employeesRepository.GetAll();
            if (!employees.Any())
            {
                throw new KeyNotFoundException("Employees not found");
            }
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByid(Guid id)
        {
            var employee = await _employeesRepository.GetById(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeProjectResponse>> GetEmployeeProjects()
        {
            var employeesWithProjectsQuery = _employeesRepository.GetAllWithQueryAble()
                .Include(e => e.Projects)
                .Select(e => new EmployeeProjectResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    ProjectName = e.Projects.Select(p => new Projects(p.Project.Name)).ToList()
                });

            if (await employeesWithProjectsQuery.CountAsync() == 0)
            {
                throw new KeyNotFoundException("No employees found with projects");
            }

            var employeesWithProjects = await employeesWithProjectsQuery.ToListAsync();
            return employeesWithProjects;
        }

        public async Task UpdateEmployee(EmployeeUpdateDto dto)
        {
            var existingEmployee = await _employeesRepository.GetById(dto.Id);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }
            
            _mapper.Map(dto, existingEmployee);
            await _employeesRepository.Update(existingEmployee);
            await _employeesRepository.SaveChangeAsync();
        }
        

        public async Task<IEnumerable<EmployeeSalaryResponse>> GetEmployeeHaveSalaryJoinDate()
        {
            var query = @"
                SELECT e.Id, e.Name, s.Salary, e.JoinedDate ,e.DepartmentId
                FROM Employees e
                INNER JOIN Salary s ON e.Id = s.EmployeeId
                WHERE s.Salary > 100 AND e.JoinedDate >= @JoinedDate";
            var parameters = new[] { new SqlParameter("@JoinedDate", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)) };
            var employeesWithSalaries = await _employeesRepository.GetAllWithSalary(query, parameters);
            return employeesWithSalaries;
        }
    }
}
