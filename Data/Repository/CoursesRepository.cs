using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class CoursesRepository : RepositoryBase<Course>, ICoursesRepository
    {
        public CoursesRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
