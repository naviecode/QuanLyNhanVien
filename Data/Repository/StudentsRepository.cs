using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class StudentsRepository : RepositoryBase<Students>, IStudentsRepository
    {
        public StudentsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
