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
            var idNew = _repositoryManager.RolePermissionsRepository.Add(_mapper.Map<RolePermissionsCreateDto, RolePermissions>(input));
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
            var isSuccess = _repositoryManager.RolePermissionsRepository.Delete(id);
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
            //var RolePermissions = _repositoryManager.RolePermissionsRepository.GetAll().ToList();
            //var Permissions = _repositoryManager.PermissionsRepository.GetAll().ToList();
            //var query = from rolePermission in RolePermissions
            //            join permission in Permissions
            //            on rolePermission.PermissionID equals permission.Id into rolePermissionNames
            //            from permissonNames in rolePermissionNames
            //            select new
            //            {
            //                RoleID = rolePermission.RoleID,
            //                PermissionName = permissonNames.PermissionName
            //            };
            //List<RolePermissionsReadDto> result = query.Select(q=> new RolePermissionsReadDto
            //{
            //    RoleID =q.RoleID,
            //    PermissionName =q.PermissionName,
            //}).ToList();

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

        public ResponseActionDto<RolePermissionsReadDto> Update(RolePermissionsUpdateDto input)
        {
            if (_repositoryManager.RolePermissionsRepository.GetAll().Any(x => x.PermissionID == input.PermissionID && x.RoleID == input.RoleID))
            {
                return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Cập nhập thất bại", "Quyền đã được cấp");
            }
            var result = _repositoryManager.RolePermissionsRepository.GetById(input.Id);
            if (result != null)
            {
                _repositoryManager.RolePermissionsRepository.Update(_mapper.Map(input, result));
                return new ResponseActionDto<RolePermissionsReadDto>(null, 0, "Cập nhập thành công", "");
            }
            return new ResponseActionDto<RolePermissionsReadDto>(null, -1, "Không tìm thấy", "");
        }
    }
}
