using EFCore.Models.Data;
using EFCore.Models.Entities;

namespace EFCore.Repositories
{
    public class DepartmentsRepository : BaseRepository<Departments>
    {
        public DepartmentsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
