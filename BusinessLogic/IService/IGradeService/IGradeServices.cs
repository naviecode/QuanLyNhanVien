using BusinessLogic.IService.IGradeService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IGradeService
{
    public interface IGradeServices
    {
        ResponseActionDto<StudentGradeSearchResultDto> AddOrUpdateGrade(GradeAddOrUpdateDto data);
        ResponseDataDto<StudentGradeSearchResultDto> SearchGrades(StudentGradeFilterSearchDto filterInput);
        ResponseActionDto<StudentGradeByIdDto> GetById(int studentId, int courseId, string semester, int year);
    }
}
