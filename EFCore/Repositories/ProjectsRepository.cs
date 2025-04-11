using EFCore.Models.Data;
using EFCore.Models.Entities;

namespace EFCore.Repositories
{
    public class ProjectsRepository : BaseRepository<Projects>
    {
        public ProjectsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
