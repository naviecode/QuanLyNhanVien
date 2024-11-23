using AutoMapper;
using BusinessLogic.IService.ICourseService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class CourseMapperProfile : Profile
    {
        public CourseMapperProfile() 
        {
            CreateMap<CourseAddDto, Course>().ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => new List<Enrollment>())).ForMember(dest => dest.Classes, opt => opt.MapFrom(src => new List<Class>()));
            CreateMap<CourseUpdateDto, Course>().ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => new List<Enrollment>())).ForMember(dest => dest.Classes, opt => opt.MapFrom(src => new List<Class>()));
            CreateMap<Course, CourseResultByIdDto>().ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Course, CourseSearchResultDto>();
        }
    }
}
