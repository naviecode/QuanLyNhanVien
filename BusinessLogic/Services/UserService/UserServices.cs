using BusinessLogic.IService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.IService.IUserService.Dto;
using Data.IRepository;

namespace BusinessLogic.Services.UserService
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserServices(IRepositoryManager repositoryManager) 
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseActionDto<UserReadDto>> Create(UserCreateDto userCreateDto)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseActionDto<UserReadDto>> Delete(int userId)
        {
            throw new NotImplementedException();
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
