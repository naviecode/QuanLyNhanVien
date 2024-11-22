using BusinessLogic.IService.ICourseService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.ICourseService
{
    public interface ICourseServices
    {
        ResponseDataDto<CourseSearchResultDto> Search(CourseSearchFilterDto filterInput);
        ResponseActionDto<CourseSearchResultDto> Create(CourseAddDto data);
        ResponseActionDto<CourseSearchResultDto> Delete(int id);
        ResponseActionDto<CourseSearchResultDto> Update(CourseUpdateDto data);
        ResponseActionDto<CourseResultByIdDto> GetById(int userId);
        ResponseDataDto<CourseNearCloseDto> CourseNearClose();
        ResponseDataDto<CourseSearchResultDto> GetCombobox();

    }
}
