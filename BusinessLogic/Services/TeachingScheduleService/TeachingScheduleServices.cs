using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.ITeachingScheduleService;
using BusinessLogic.IService.ITeachingScheduleService.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.TeachingScheduleService
{
    public class TeachingScheduleServices : ITeachingScheduleServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TeachingScheduleServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseActionDto<TeachingScheduleReadDto> Create(TeachingScheduleCreateDto create)
        {
            //check có bị trùng khung giờ với giáo viên khác không
            /*
                7-11
                1-5
                6-9
             */

            var idNew = _repositoryManager.TeachingScheduleRepository.Add(_mapper.Map<TeachingScheduleCreateDto, TeachingSchedule>(create));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(null, -1, "Thêm mới thất bại", "");
            }
        }

        public ResponseActionDto<TeachingScheduleReadDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.TeachingScheduleRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(null, -1, "Xóa thất bại", "");
            }
        }

        public ResponseDataDto<TeachingScheduleReadDto> GetAll()
        {
            var result = _repositoryManager.TeachingScheduleRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<TeachingScheduleReadDto>(_mapper.Map<List<TeachingSchedule>, List<TeachingScheduleReadDto>>(result), totalItem);
        }

        public ResponseActionDto<TeachingScheduleReadDto> GetById(int id)
        {
            var result = _repositoryManager.TeachingScheduleRepository.GetById(id);
            if (result != null)
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(_mapper.Map<TeachingSchedule, TeachingScheduleReadDto>(result), 0, "", "");
            }
            return new ResponseActionDto<TeachingScheduleReadDto>(null, -1, "Không tìm thấy", "");
        }

        public ResponseDataDto<TeachingScheduleReadDto> Search(string filter)
        {
            var result = _repositoryManager.TeachingScheduleRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<TeachingScheduleReadDto>(_mapper.Map<List<TeachingSchedule>, List<TeachingScheduleReadDto>>(result), totalItem);
        }

        public ResponseActionDto<TeachingScheduleReadDto> Update(TeachingScheduleUpdateDto update)
        {   
            //check có bị trùng khung giờ với giáo viên khác không
            /*
                7-11
                1-5
                6-9
             */
            var result = _repositoryManager.TeachingScheduleRepository.GetById(update.Id);
            if (result != null)
            {
                _repositoryManager.TeachingScheduleRepository.Update(_mapper.Map(update, result));
                return new ResponseActionDto<TeachingScheduleReadDto>(null, 0, "Cập nhập thành công", "");
            }
            return new ResponseActionDto<TeachingScheduleReadDto>(null, -1, "Không tìm thấy", "");
        }
    }
}
