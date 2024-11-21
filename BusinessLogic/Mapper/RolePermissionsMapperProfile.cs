using AutoMapper;
using BusinessLogic.IService.IRolePermissions.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class RolePermissionsMapperProfile : Profile
    {
        public RolePermissionsMapperProfile() 
        {
            CreateMap<RolePermissions, RolePermissionsCreateDto>();
            CreateMap<RolePermissions, RolePermissionsReadDto>();
            CreateMap<RolePermissions, RolePermissionsUpdateDto>();
            CreateMap<RolePermissionsCreateDto, RolePermissions>();
            CreateMap<RolePermissionsReadDto, RolePermissions>();
            CreateMap<RolePermissionsUpdateDto, RolePermissions>().ForMember(x => x.Id, opt => opt.Ignore()); ;
        }
    }
}
