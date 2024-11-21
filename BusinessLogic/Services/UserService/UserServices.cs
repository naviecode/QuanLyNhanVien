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

        public ResponseActionDto<UserReadDto> ChangePassword(string username, string passwordOld, string passwordNew)
        {
            throw new NotImplementedException();
        }

        public ResponseActionDto<UserReadDto> Create(UserCreateDto userCreateDto)
        {
            var checkIsExist = _repositoryManager.UsersRepository.GetAll().Any(x=>x.Username == userCreateDto.Username);
            if (checkIsExist)
            {
                return new ResponseActionDto<UserReadDto>(null, -1, "Thêm mới thất bại", "Trùng username");

            }
            var idNew = _repositoryManager.UsersRepository.Add(_mapper.Map<UserCreateDto, Users>(userCreateDto));
            if (idNew != null && idNew != 0)
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
            var result = _repositoryManager.UsersRepository.GetById(userId);
            if(result != null)
            {
                return new ResponseActionDto<UserReadDto>(_mapper.Map<Users, UserReadDto>(result), 0, "", "");
            }
            return new ResponseActionDto<UserReadDto>(new UserReadDto(), -1, "Không tìm thấy", "");

        }

        public ResponseActionDto<UserReadDto> Login(string username, string password)
        {
            var result = _repositoryManager.UsersRepository.GetAll().Where(x=> x.Username == username && x.PasswordHash == password).FirstOrDefault();
            if (result != null)
            {
                return new ResponseActionDto<UserReadDto>(_mapper.Map<Users, UserReadDto>(result), 0, "", "");
            }
            return new ResponseActionDto<UserReadDto>(null, -1, "Tên đăng nhập hoặc mật khẩu không đúng", "");
        }

        public ResponseActionDto<UserReadDto> Update(UserUpdateDto userUpdateDto)
        {
            var result = _repositoryManager.UsersRepository.GetById(userUpdateDto.Id);
            if(result != null)
            {
                _repositoryManager.UsersRepository.Update(_mapper.Map(userUpdateDto, result));
                return new ResponseActionDto<UserReadDto>(null, 0, "Cập nhập thành công", "");
            }
            return new ResponseActionDto<UserReadDto>(null, -1, "Không tìm thấy", "");
        }
    }
}
