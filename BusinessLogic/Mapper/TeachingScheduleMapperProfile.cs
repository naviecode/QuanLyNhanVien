using AutoMapper;
using BusinessLogic.IService.ITeachingScheduleService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class TeachingScheduleMapperProfile : Profile
    {
        public TeachingScheduleMapperProfile() 
        {
            CreateMap<TeachingSchedule, TeachingScheduleCreateDto>();
            CreateMap<TeachingSchedule, TeachingScheduleReadDto>();
            CreateMap<TeachingSchedule, TeachingScheduleUpdateDto>();
            CreateMap<TeachingScheduleCreateDto, TeachingSchedule>();
            CreateMap<TeachingScheduleReadDto, TeachingSchedule>();
            CreateMap<TeachingScheduleUpdateDto, TeachingSchedule>().ForMember(x => x.Id, opt => opt.Ignore()); ;
        }
    }
}
