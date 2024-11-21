using AutoMapper;
using BusinessLogic.IService.IPermissions.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class PermissionsMapperProfile : Profile
    {
        public PermissionsMapperProfile() 
        {
            CreateMap<Permissions, PermissionsCreateDto>();
            CreateMap<Permissions, PermissionsReadDto>();
            CreateMap<Permissions, PermissionsUpdateDto>();
            CreateMap<PermissionsCreateDto, Permissions>();
            CreateMap<PermissionsReadDto, Permissions>();
            CreateMap<PermissionsUpdateDto, Permissions>().ForMember(x=>x.Id, opt=> opt.Ignore());
        }
    }
}
