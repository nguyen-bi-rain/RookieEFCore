
using EFCore.Models.Entities;

namespace EFCore.Repositories
{
    public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee>
    {
        Task<ProjectEmployee> GetProjectEmployeeByProjectIds(Guid id);
    }
}