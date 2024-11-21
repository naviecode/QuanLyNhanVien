using AutoMapper;
using BusinessLogic.IService.IRoleService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class RolesMapperProfile : Profile
    {
        public RolesMapperProfile() 
        {
            CreateMap<Roles, RoleReadDto>();
            CreateMap<Roles, RoleUpdateDto>();
            CreateMap<Roles, RoleCreateDto>();
            CreateMap<RoleReadDto, Roles>();
            CreateMap<RoleUpdateDto, Roles>().ForMember(x => x.Id, opt => opt.Ignore()); ;
            CreateMap<RoleCreateDto, Roles>();
        }
    }
}
