using AutoMapper;
using BusinessLogic.IService.IDepartmentService.Dto;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class DepartmentMapperProfile : Profile
    {
        public DepartmentMapperProfile() 
        {
            CreateMap<DepartmentAddDto, Department>().ForMember(dest => dest.Faculties, opt => opt.MapFrom(src => new List<Faculty>()));
            CreateMap<DepartmentUpdateDto, Department>().ForMember(dest => dest.Faculties, opt => opt.MapFrom(src => new List<Faculty>()));
            CreateMap<Department, DepartmentByIdDto>().ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Department, DepartmentSearchResultDto>().ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
