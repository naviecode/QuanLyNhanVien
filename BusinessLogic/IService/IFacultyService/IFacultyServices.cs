using BusinessLogic.IService.IFacultyService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IFacultyService
{
    public interface IFacultyServices
    {
        ResponseDataDto<FacultyResultSearchDto> Search(FacultyFilterSearchDto filterInput);
        ResponseActionDto<FacultyResultSearchDto> Create(FacultyAddDto data);
        ResponseActionDto<FacultyResultSearchDto> Update(FacultyUpdateDto data);
        ResponseActionDto<FacultyResultSearchDto> Delete(int id);
        ResponseActionDto<FacultyByIdDto> GetById(int id);
        ResponseDataDto<FacultyResultSearchDto> GetCombobox();
    }
}
