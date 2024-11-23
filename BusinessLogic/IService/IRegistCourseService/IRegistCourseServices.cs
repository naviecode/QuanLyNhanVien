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
        ResponseActionDto<RegisteredSearchResultto> RegisterCourse(CourseRegistrationDto data);
        ResponseActionDto<RegisteredSearchResultto> CancelRegistration(int courseId);
        ResponseDataDto<RegisteredSearchResultto> GetRegisteredCourses(RegisteredFilterSearchDto filterInput);
    }
}
