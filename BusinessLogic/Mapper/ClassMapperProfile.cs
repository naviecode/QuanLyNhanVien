using AutoMapper;
using BusinessLogic.IService.IClassService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class ClassMapperProfile : Profile
    {
        public ClassMapperProfile()
        {
            CreateMap<ClassAddDto, Class>();
            CreateMap<ClassUpdateDto, Class>();
            CreateMap<Class, ClassByIdDto>().ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Class, ClassSearchResultDto>().ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
