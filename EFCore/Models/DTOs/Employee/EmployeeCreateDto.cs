using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        public required string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }
        

    }
}