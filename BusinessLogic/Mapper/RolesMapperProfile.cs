using AutoMapper;
using BusinessLogic.IService.IRoleService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class RolesMapperProfile : Profile
    {
        public RolesMapperProfile() 
        {
            CreateMap<RoleReadDto, Roles>();
            CreateMap<Roles, RoleReadDto>();

        }
    }
}
