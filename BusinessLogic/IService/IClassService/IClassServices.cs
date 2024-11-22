using BusinessLogic.IService.IClassService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IClassService
{
    public interface IClassServices
    {
        ResponseActionDto<ClassSearchResultDto> Create(ClassAddDto data);
        ResponseActionDto<ClassSearchResultDto> Delete(int id);
        ResponseActionDto<ClassByIdDto> GetById(int classId);
        ResponseDataDto<ClassSearchResultDto> Search(ClassFilterSearchDto filterInput);
        ResponseActionDto<ClassSearchResultDto> Update(ClassUpdateDto data);
        ResponseActionDto<ClassSearchResultDto> AssignStudentToClass(AssignStudentToClassDto data);
        ResponseActionDto<ClassSearchResultDto> AddCourseToClass(AddCourseToClassDto data);
        ResponseDataDto<ClassSectionSearchResultDto> ClassSectionSearch(ClassSectionFilterSearchDto filterInput);
        ResponseDataDto<ClassSearchResultDto> GetCombobox();
    }
}
