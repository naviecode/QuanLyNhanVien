using BusinessLogic.IService.IRoleService.Dto;

namespace BusinessLogic.IService.IRoleService
{
    public interface IRoleServices
    {
        ResponseDataDto<RoleReadDto> GetCombobox();
    }
}
