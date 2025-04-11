using EFCore.Models.Data;
using EFCore.Models.Entities;

namespace EFCore.Repositories
{
    public class SalariesRepository : BaseRepository<Salaries>
    {
        public SalariesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
