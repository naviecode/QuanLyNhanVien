using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.Services.UserService;
using Data.IRepository;

namespace BusinessLogic.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServices> _lazyUserService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _lazyUserService = new Lazy<IUserServices>(()=> new UserServices(repositoryManager, mapper));
        }

        public IUserServices UserService => _lazyUserService.Value;
    }
}
