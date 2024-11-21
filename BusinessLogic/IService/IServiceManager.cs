using BusinessLogic.IService.IPermissions;
using BusinessLogic.IService.IRolePermissions;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IUserService;

namespace BusinessLogic.IService
{
    public interface IServiceManager
    {
        IUserServices UserService { get; }
        IRoleServices RoleService { get; }
        IPermissionService PermissionService { get; }
        IRolePermissionService RolePermissionService { get; }
    }
}
