using BusinessLogic.IService.IStudentService.Dto;

namespace BusinessLogic.IService.IStudentService
{
    public interface IStudentServices
    {
        ResponseDataDto<StudentSearchResultDto> Search(StudentSearchFilterDto filterInput);
        ResponseActionDto<StudentSearchResultDto> Create(StudentAddDto data);
        ResponseActionDto<StudentSearchResultDto> Delete(int id);
        ResponseActionDto<StudentSearchResultDto> Update(StudentUpdateDto data);
        ResponseActionDto<StudentResultByIdDto> GetById(int id);
        ResponseActionDto<StudentGetInfoDto> GetInfoUser(StudentGetInfoFilterDto input);
        ResponseDataDto<StudentTrendDto> StudentTrend();

    }
}
