using AutoMapper;
using BusinessLogic.IService.ICourseService.Dto;
using BusinessLogic.IService.IStudentService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<StudentAddDto, Students>().ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => new List<Enrollment>()));
            CreateMap<StudentUpdateDto, Students>().ForMember(x => x.Id, opt => opt.Ignore()).ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => new List<Enrollment>()));
            CreateMap<Students, StudentResultByIdDto>();
            CreateMap<Students, StudentSearchResultDto>().ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
