using BusinessLogic.IService.IStudentService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IStudentService
{
    public interface IStudentServices
    {
        ResponseDataDto<StudentSearchResultDto> Search(StudentSearchFilterDto filterInput);
        ResponseActionDto<StudentSearchResultDto> Create(StudentAddDto data);
        ResponseActionDto<StudentSearchResultDto> Delete(int id);
        public ResponseActionDto<StudentSearchResultDto> Update(StudentUpdateDto data);
        ResponseActionDto<StudentResultByIdDto> GetById(int id);
    }
}
