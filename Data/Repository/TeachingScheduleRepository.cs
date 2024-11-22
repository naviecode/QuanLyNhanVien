using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class TeachingScheduleRepository : RepositoryBase<TeachingSchedule>, ITeachingScheduleRepository
    {
        public TeachingScheduleRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
