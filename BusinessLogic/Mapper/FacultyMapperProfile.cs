using AutoMapper;
using BusinessLogic.IService.IFacultyService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class FacultyMapperProfile : Profile
    {
        public FacultyMapperProfile()
        {
            CreateMap<FacultyAddDto, Faculty>().ForMember(dest => dest.Classes, opt => opt.MapFrom(src => new List<Class>()));
            CreateMap<FacultyUpdateDto, Faculty>().ForMember(dest => dest.Classes, opt => opt.MapFrom(src => new List<Class>()));
            CreateMap<Faculty, FacultyByIdDto>().ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Faculty, FacultyResultSearchDto>().ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
