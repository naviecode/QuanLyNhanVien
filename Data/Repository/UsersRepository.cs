using Data.Entities;
using Data.IRepository;

namespace Data.Repository
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepository
    {
        public UsersRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
