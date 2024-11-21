using BusinessLogic.IService.IRegistCourseService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IRegistCourseService
{
    public interface IRegistCourseServices
    {
        ResponseActionDto<RegisteredCourseDto> RegisterCourse(CourseRegistrationDto data);
        ResponseActionDto<RegisteredCourseDto> CancelRegistration(CancelRegistrationDto data);
        ResponseActionDto<List<RegisteredCourseDto>> GetRegisteredCourses(int studentId);
    }
}
