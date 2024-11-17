using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class DepartmentsRepository : RepositoryBase<Department>, IDepartmentsRepository
    {
        public DepartmentsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
