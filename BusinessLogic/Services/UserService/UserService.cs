using BusinessLogic.IService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.IService.IUserService.Dto;
using Data.Entities;
using Data.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }

        public async Task<ResponseActionDto<UserReadDto>> Create(UserCreateDto userCreateDto)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseActionDto<UserReadDto>> Delete(int userId)
        {
            return new ResponseActionDto<UserReadDto>(null,1, "test", "test");
        }

        public async Task<ResponseDataDto<UserReadDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseActionDto<UserReadDto>> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseActionDto<UserReadDto>> Update(UserUpdateDto userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
