using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.Services.UserService;
using Data.IRepository;

namespace BusinessLogic.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServices> _lazyUserService;
        private readonly Lazy<IRoleServices> _lazyRoleService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _lazyUserService = new Lazy<IUserServices>(()=> new UserServices(repositoryManager, mapper));
            _lazyRoleService = new Lazy<IRoleServices>(() => new RoleServices(repositoryManager, mapper));

        }

        public IUserServices UserService => _lazyUserService.Value;
        public IRoleServices RoleService => _lazyRoleService.Value;

    }
}
