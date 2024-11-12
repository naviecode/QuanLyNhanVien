using BusinessLogic.IService.IUserService.Dto;

namespace BusinessLogic.IService.IUserService
{
    public interface IUserService
    {
        Task<ResponseActionDto<UserReadDto>> Create(UserCreateDto userCreateDto);
        Task<ResponseActionDto<UserReadDto>> Update(UserUpdateDto userUpdateDto);
        Task<ResponseActionDto<UserReadDto>> Delete(int userId);
        Task<ResponseDataDto<UserReadDto>> GetAll();
        Task<ResponseActionDto<UserReadDto>> GetById(int userId);
    }
}
