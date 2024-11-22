using BusinessLogic.IService.IRolePermissions.Dto;

namespace BusinessLogic.IService.IRolePermissions
{
    public interface IRolePermissionService
    {
        ResponseActionDto<RolePermissionsReadDto> Create(RolePermissionsCreateDto input);
        ResponseActionDto<RolePermissionsReadDto> Update(RolePermissionsUpdateDto input);
        ResponseActionDto<RolePermissionsReadDto> Delete(int id);
        ResponseActionDto<RolePermissionsReadDto> GetById(int id);
        ResponseDataDto<RolePermissionsReadDto> GetAll();
        ResponseDataDto<RolePermissionsReadDto> Search(string Role, string Permission);

    }
}
