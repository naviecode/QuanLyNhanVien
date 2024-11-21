using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class PermissionsRepository : RepositoryBase<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
