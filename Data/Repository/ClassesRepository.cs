using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class ClassesRepository : RepositoryBase<Class>, IClassesRepository
    {
        public ClassesRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
