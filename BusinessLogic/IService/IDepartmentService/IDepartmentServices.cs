using BusinessLogic.IService.IDepartmentService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IDepartmentService
{
    public interface IDepartmentServices
    {
        ResponseActionDto<DepartmentSearchResultDto> Create(DepartmentAddDto data);
        ResponseActionDto<DepartmentSearchResultDto> Update(DepartmentUpdateDto data);
        ResponseActionDto<DepartmentSearchResultDto> Delete(int id);
        ResponseActionDto<DepartmentByIdDto> GetById(int departmentId);
        ResponseDataDto<DepartmentSearchResultDto> Search(DepartmentFilterSearchDto filterInput);
        ResponseDataDto<DepartmentCountStudentsDto> DepartmentCountStudent();

    }
}
