using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IRolePermissions;
using BusinessLogic.IService.IRolePermissions.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.RolePermissionsService
{
    public class RolePermissionsServices : IRolePermissionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public RolePermissionsServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ResponseActionDto<RolePermissionsReadDto> Create(RolePermissionsCreateDto input)
        {
            if(_repositoryManager.RolePermissionsRepository.GetAll().Any(x=>x.PermissionID == input.PermissionID && x.RoleID == input.RoleID))
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Thêm mới thất bại", "Quyền đã được cấp");
            }
            var maxId =_repositoryManager.RolePermissionsRepository.GetAll().Max(x => x.Id) + 1;
            var mapperInsert = _mapper.Map<RolePermissionsCreateDto, RolePermissions>(input);
            mapperInsert.Id = maxId;
            var idNew = _repositoryManager.RolePermissionsRepository.Add(mapperInsert);
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Thêm mới thất bại", "");
            }
        }

        public ResponseActionDto<RolePermissionsReadDto> Delete(int id)
        {
            var RolePermissionFind = _repositoryManager.RolePermissionsRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if(RolePermissionFind == null)
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Không tìm thấy để xóa", "");

            }
            var isSuccess = _repositoryManager.RolePermissionsRepository.Delete(RolePermissionFind);
            if (isSuccess)
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Xóa thất bại", "");
            }
        }

        public ResponseDataDto<RolePermissionsReadDto> GetAll()
        {
            var result = _repositoryManager.RolePermissionsRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<RolePermissionsReadDto>(_mapper.Map<List<RolePermissions>, List<RolePermissionsReadDto>>(result), totalItem);
        }

        public ResponseActionDto<RolePermissionsReadDto> GetById(int id)
        {
            var result = _repositoryManager.RolePermissionsRepository.GetAll().Where(x=>x.Id == id).FirstOrDefault();
            if (result != null)
            {
                return new ResponseActionDto<RolePermissionsReadDto>(_mapper.Map<RolePermissions, RolePermissionsReadDto>(result), 0, "", "");
            }
            return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Không tìm thấy", "");
        }

        public ResponseDataDto<RolePermissionsReadDto> Search(string Role, string Permission)
        {
            var result = _repositoryManager.RolePermissionsRepository.GetAll().Where(x=> (x.Permission.PermissionName.Contains(Permission) || string.IsNullOrEmpty(Permission)) && (x.Role.RoleName.Contains(Role) || string.IsNullOrEmpty(Role))).ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<RolePermissionsReadDto>(_mapper.Map<List<RolePermissions>, List<RolePermissionsReadDto>>(result), totalItem);
        }

        public ResponseActionDto<RolePermissionsReadDto> Update(RolePermissionsUpdateDto input)
        {
            if (_repositoryManager.RolePermissionsRepository.GetAll().Any(x => x.PermissionID == input.PermissionID && x.RoleID == input.RoleID))
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Cập nhập thất bại", "Quyền đã được cấp");
            }
            var result = _repositoryManager.RolePermissionsRepository.GetAll().Where(x => x.Id == input.Id).FirstOrDefault();
            if (result != null)
            {
                var maxId = _repositoryManager.RolePermissionsRepository.GetAll().Max(x => x.Id) + 1;
                var newRolePermission = new RolePermissions()
                {
                    Id = maxId,
                    RoleID = input.RoleID,
                    PermissionID = input.PermissionID,
                };
                _repositoryManager.RolePermissionsRepository.Delete(result);
                _repositoryManager.RolePermissionsRepository.Add(newRolePermission);
                return new ResponseActionDto<RolePermissionsReadDto>(null, 0, "Cập nhập thành công", "");
            }
            return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Không tìm thấy", "");
        }
    }
}
