using BusinessLogic.IService.IRoleService.Dto;

namespace BusinessLogic.IService.IRoleService
{
    public interface IRoleServices
    {
        ResponseActionDto<RoleReadDto> Create(RoleCreateDto userCreateDto);
        ResponseActionDto<RoleReadDto> Update(RoleUpdateDto userUpdateDto);
        ResponseActionDto<RoleReadDto> Delete(int id);
        ResponseActionDto<RoleReadDto> GetById(int id);
        ResponseDataDto<RoleReadDto> GetAll();
        ResponseDataDto<RoleReadDto> GetCombobox();
    }
}
