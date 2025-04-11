using EFCore.Models.Data;
using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories
{
    public class ProjectEmployeeRepository : BaseRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        private readonly ApplicationDbContext _context; 
        public ProjectEmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProjectEmployee> GetProjectEmployeeByProjectIds(Guid id)
        {
            var projectEmployee = await _context.ProjectEmployees.FirstOrDefaultAsync(x => x.Id == id);
            if (projectEmployee == null)
            {
                throw new KeyNotFoundException("Project employee not found");
            }
            return projectEmployee;
        }
    }
}
