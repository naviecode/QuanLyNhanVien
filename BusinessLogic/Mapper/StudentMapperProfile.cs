using AutoMapper;
using BusinessLogic.IService.IStudentService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<StudentAddDto, Students>();
            CreateMap<StudentUpdateDto, Students>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Students, StudentResultByIdDto>();
        }
    }
}
