using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class EnrollmentsRepository : RepositoryBase<Enrollment>, IEnrollmentsRepository
    {
        public EnrollmentsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
