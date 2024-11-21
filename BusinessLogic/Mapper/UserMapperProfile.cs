using AutoMapper;
using BusinessLogic.IService.IUserService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() 
        {
            CreateMap<Users, UserCreateDto>();
            CreateMap<Users, UserReadDto>();
            CreateMap<Users, UserUpdateDto>();
            CreateMap<UserCreateDto, Users>();
            CreateMap<UserReadDto, Users>();
            CreateMap<UserUpdateDto, Users>().ForMember(x => x.Id, opt => opt.Ignore()); ;
        }
    }
}
