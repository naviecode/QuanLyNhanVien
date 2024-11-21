using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IPermissions;
using BusinessLogic.IService.IRolePermissions;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.Services.PermissionsService;
using BusinessLogic.Services.RolePermissionsService;
using BusinessLogic.Services.RoleService;
using BusinessLogic.Services.UserService;
using Data.IRepository;

namespace BusinessLogic.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServices> _lazyUserService;
        private readonly Lazy<IRoleServices> _lazyRoleService;
        private readonly Lazy<IPermissionService> _lazyPermissionService;
        private readonly Lazy<IRolePermissionService> _lazyRolePermissionService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _lazyUserService = new Lazy<IUserServices>(()=> new UserServices(repositoryManager, mapper));
            _lazyRoleService = new Lazy<IRoleServices>(() => new RoleServices(repositoryManager, mapper));
            _lazyPermissionService = new Lazy<IPermissionService>(()=> new PermissionsServices(repositoryManager, mapper));
            _lazyRolePermissionService = new Lazy<IRolePermissionService> (()=> new RolePermissionsServices(repositoryManager, mapper));

        }

        public IUserServices UserService => _lazyUserService.Value;
        public IRoleServices RoleService => _lazyRoleService.Value;
        public IPermissionService PermissionService => _lazyPermissionService.Value;
        public IRolePermissionService RolePermissionService => _lazyRolePermissionService.Value;
    }
}
