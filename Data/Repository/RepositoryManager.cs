using Data.IRepository;
using System;

namespace Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DatabaseContext _databaseContext;
        public RepositoryManager(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }
        private IUsersRepository _usersRepository;
        private IRolesRepository _rolesRepository;

        public IUsersRepository UsersRepository => _usersRepository ?? new UsersRepository(_databaseContext);
        public IRolesRepository RolesRepository => _rolesRepository ?? new RolesRepository(_databaseContext);

    }
}
