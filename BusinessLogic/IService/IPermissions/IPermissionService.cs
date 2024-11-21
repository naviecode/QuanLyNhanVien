using BusinessLogic.IService.IPermissions.Dto;

namespace BusinessLogic.IService.IPermissions
{
    public interface IPermissionService
    {
        ResponseActionDto<PermissionsReadDto> Create(PermissionsCreateDto input);
        ResponseActionDto<PermissionsReadDto> Update(PermissionsUpdateDto input);
        ResponseActionDto<PermissionsReadDto> Delete(int id);
        ResponseActionDto<PermissionsReadDto> GetById(int id);
        ResponseDataDto<PermissionsReadDto> GetAll();
        ResponseDataDto<PermissionsReadDto> GetCombobox();

    }
}
