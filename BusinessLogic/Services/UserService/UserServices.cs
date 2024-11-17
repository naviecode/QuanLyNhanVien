using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.IService.IUserService.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.UserService
{
    public class UserServices : IUserServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserServices(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ResponseActionDto<UserReadDto> Create(UserCreateDto userCreateDto)
        {
            var idNew  = _repositoryManager.UsersRepository.Add(_mapper.Map<UserCreateDto, Users>(userCreateDto));
            if(idNew != null && idNew != 0)
            {
                return new ResponseActionDto<UserReadDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<UserReadDto>(null, -1, "Thêm mới thất bại", "");
            }

        }
        public ResponseActionDto<UserReadDto> Delete(int userId)
        {
            var isSuccess = _repositoryManager.UsersRepository.Delete(userId);
            if (isSuccess)
            {
                return new ResponseActionDto<UserReadDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<UserReadDto>(null, -1, "Xóa thất bại", "");
            }
        }

        public ResponseDataDto<UserReadDto> GetAll()
        {
            var result = _repositoryManager.UsersRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<UserReadDto>(_mapper.Map<List<Users>, List<UserReadDto>>(result), totalItem);

        }

        public ResponseActionDto<UserReadDto> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public ResponseActionDto<UserReadDto> Update(UserUpdateDto userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
