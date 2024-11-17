using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class RolesRepository : RepositoryBase<Roles>, IRolesRepository
    {
        public RolesRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
