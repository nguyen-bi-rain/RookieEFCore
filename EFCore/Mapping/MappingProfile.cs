using AutoMapper;
using EFCore.Models.DTOs.Department;
using EFCore.Models.DTOs.Employee;
using EFCore.Models.DTOs.Project;
using EFCore.Models.DTOs.ProjectEmployee;
using EFCore.Models.DTOs.Salaries;
using EFCore.Models.Entities;

namespace EFCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Departments, DepartmentDto>().ReverseMap();
            CreateMap<Departments,DepartmentCreateDto>().ReverseMap();
            CreateMap<DepartmentDto,DepartmentCreateDto>().ReverseMap();
            CreateMap<DepartmentDto,DepartmentUpdateDto>().ReverseMap();
            CreateMap<Departments,DepartmentUpdateDto>().ReverseMap();

            CreateMap<Employees, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeDto, EmployeeCreateDto>().ReverseMap();
            CreateMap<EmployeeDto, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employees, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employees, EmployeeUpdateDto>().ReverseMap();


            CreateMap<Salaries, SalariesDto>().ReverseMap();
            CreateMap<SalariesDto, SalariesCreateDto>().ReverseMap();
            CreateMap<SalariesDto, SalariesUpdateDto>().ReverseMap();

            CreateMap<Projects, ProjectDto>().ReverseMap();
            CreateMap<ProjectDto, ProjectCreateDto>().ReverseMap();
            CreateMap<ProjectDto, ProjectUpdateDto>().ReverseMap();
            CreateMap<Projects, ProjectCreateDto>().ReverseMap();
            CreateMap<Projects, ProjectUpdateDto>().ReverseMap();

            CreateMap<Salaries, SalariesCreateDto>().ReverseMap();
            CreateMap<Salaries, SalariesUpdateDto>().ReverseMap();
            CreateMap<SalariesDto, SalariesCreateDto>().ReverseMap();
            CreateMap<SalariesDto, SalariesUpdateDto>().ReverseMap();

            
            CreateMap<EmployeeDto, EmployeeCreateDto>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

            CreateMap<ProjectEmployee,ProjectEmployeeDto>().ReverseMap();
            

        }
    }
}