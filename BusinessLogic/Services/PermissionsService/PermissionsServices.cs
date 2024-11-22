using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IPermissions;
using BusinessLogic.IService.IPermissions.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.PermissionsService
{
    public class PermissionsServices : IPermissionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PermissionsServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ResponseActionDto<PermissionsReadDto> Create(PermissionsCreateDto input)
        {
            var idNew = _repositoryManager.PermissionsRepository.Add(_mapper.Map<PermissionsCreateDto, Permissions>(input));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<PermissionsReadDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<PermissionsReadDto>(null, -1, "Thêm mới thất bại", "");
            }
        }

        public ResponseActionDto<PermissionsReadDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.PermissionsRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<PermissionsReadDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<PermissionsReadDto>(null, -1, "Xóa thất bại", "");
            }
        }

        public ResponseDataDto<PermissionsReadDto> GetAll()
        {
            var result = _repositoryManager.PermissionsRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<PermissionsReadDto>(_mapper.Map<List<Permissions>, List<PermissionsReadDto>>(result), totalItem);
        }

        public ResponseActionDto<PermissionsReadDto> GetById(int id)
        {
            var result = _repositoryManager.PermissionsRepository.GetById(id);
            if (result != null)
            {
                return new ResponseActionDto<PermissionsReadDto>(_mapper.Map<Permissions, PermissionsReadDto>(result), 0, "", "");
            }
            return new ResponseActionDto<PermissionsReadDto>(null, -1, "Không tìm thấy", "");
        }

        public ResponseActionDto<PermissionsReadDto> Update(PermissionsUpdateDto input)
        {
            var result = _repositoryManager.PermissionsRepository.GetById(input.Id);
            if (result != null)
            {
                var isSuccess = _repositoryManager.PermissionsRepository.Update(_mapper.Map(input,result));
                if (isSuccess)
                {
                    return new ResponseActionDto<PermissionsReadDto>(null, 0, "Cập nhập thành công", "");
                }
                return new ResponseActionDto<PermissionsReadDto>(null, -1, "Cập nhập thất bại", "");
            }
            return new ResponseActionDto<PermissionsReadDto>(null, -1, "Không tìm thấy", "");
        }
        public ResponseDataDto<PermissionsReadDto> GetCombobox()
        {
            var result = _repositoryManager.PermissionsRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<PermissionsReadDto>(_mapper.Map<List<Permissions>, List<PermissionsReadDto>>(result), totalItem);

        }

        public ResponseDataDto<PermissionsReadDto> Search(string filter)
        {
            var result = _repositoryManager.PermissionsRepository.GetAll().Where(x=>x.PermissionName.Contains(filter) || string.IsNullOrEmpty(filter)).ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<PermissionsReadDto>(_mapper.Map<List<Permissions>, List<PermissionsReadDto>>(result), totalItem);
        }
    }
}
