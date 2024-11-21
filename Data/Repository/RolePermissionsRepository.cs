using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class RolePermissionsRepository : RepositoryBase<RolePermissions>, IRolePermissionsRepository
    {
        public RolePermissionsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
