using AutoMapper;
using BusinessLogic.IService.ICourseService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class CourseMapperProfile : Profile
    {
        public CourseMapperProfile() 
        {
            CreateMap<CourseAddDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseResultByIdDto>().ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Course, CourseSearchResultDto>();
        }
    }
}
