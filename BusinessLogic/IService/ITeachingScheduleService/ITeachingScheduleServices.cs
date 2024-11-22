using BusinessLogic.IService.ITeachingScheduleService.Dto;

namespace BusinessLogic.IService.ITeachingScheduleService
{
    public interface ITeachingScheduleServices
    {
        ResponseActionDto<TeachingScheduleReadDto> Create(TeachingScheduleCreateDto create);
        ResponseActionDto<TeachingScheduleReadDto> Update(TeachingScheduleUpdateDto update);
        ResponseActionDto<TeachingScheduleReadDto> Delete(int id);
        ResponseDataDto<TeachingScheduleReadDto> GetAll();
        ResponseActionDto<TeachingScheduleReadDto> GetById(int id);
        ResponseDataDto<TeachingScheduleReadDto> Search(string filter);

    }
}
