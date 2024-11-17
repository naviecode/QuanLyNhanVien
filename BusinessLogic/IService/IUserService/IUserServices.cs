using BusinessLogic.IService.IUserService.Dto;

namespace BusinessLogic.IService.IUserService
{
    public interface IUserServices
    {
        ResponseActionDto<UserReadDto> Create(UserCreateDto userCreateDto);
        ResponseActionDto<UserReadDto> Update(UserUpdateDto userUpdateDto);
        ResponseActionDto<UserReadDto> Delete(int userId);
        ResponseDataDto<UserReadDto> GetAll();
        ResponseActionDto<UserReadDto> GetById(int userId);

    }
}
