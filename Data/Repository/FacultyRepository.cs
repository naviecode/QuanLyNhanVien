using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class FacultyRepository : RepositoryBase<Faculty>, IFacultysRepository
    {
        public FacultyRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
