using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IRoleService.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.RoleService
{
    public class RoleServices : IRoleServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public RoleServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ResponseActionDto<RoleReadDto> Create(RoleCreateDto input)
        {
            var idNew = _repositoryManager.RolesRepository.Add(_mapper.Map<RoleCreateDto, Roles>(input));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<RoleReadDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<RoleReadDto>(null, -1, "Thêm mới thất bại", "");
            }
        }

        public ResponseActionDto<RoleReadDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.RolesRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<RoleReadDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<RoleReadDto>(null, -1, "Xóa thất bại", "");
            }
        }

        public ResponseDataDto<RoleReadDto> GetAll()
        {
            var result = _repositoryManager.RolesRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<RoleReadDto>(_mapper.Map<List<Roles>, List<RoleReadDto>>(result), totalItem);
        }

        public ResponseActionDto<RoleReadDto> GetById(int id)
        {
            var result = _repositoryManager.RolesRepository.GetById(id);
            if (result != null)
            {
                return new ResponseActionDto<RoleReadDto>(_mapper.Map<Roles, RoleReadDto>(result), 0, "", "");
            }
            return new ResponseActionDto<RoleReadDto>(null, -1, "Không tìm thấy", "");
        }

        public ResponseDataDto<RoleReadDto> GetCombobox()
        {
            var result = _repositoryManager.RolesRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<RoleReadDto>(_mapper.Map<List<Roles>, List<RoleReadDto>>(result), totalItem);

        }

        public ResponseActionDto<RoleReadDto> Update(RoleUpdateDto input)
        {
            var result = _repositoryManager.RolesRepository.GetById(input.Id);
            if (result != null)
            {
                var isSuccess = _repositoryManager.RolesRepository.Update(_mapper.Map(input, result));
                if (isSuccess)
                {
                    return new ResponseActionDto<RoleReadDto>(null, 0, "Cập nhập thành công", "");
                }
                return new ResponseActionDto<RoleReadDto>(null, -1, "Cập nhập thất bại", "");

            }
            return new ResponseActionDto<RoleReadDto>(null, -1, "Không tìm thấy", "");
        }
    }
}
