using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.ITeachingScheduleService;
using BusinessLogic.IService.ITeachingScheduleService.Dto;
using Data.Entities;
using Data.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            if (_repositoryManager.TeachingScheduleRepository.GetAll().Any(x=>x.Date == create.Date && x.StartAndEndTime == create.StartAndEndTime))
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(null, -1, "Giờ này đã có người dạy", "");
            }

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

        public ResponseDataDto<TeachingScheduleReadDto> GetTimeTable(int currentUser)
        {
            var teachings = _repositoryManager.TeachingScheduleRepository.GetAll().ToList();
            var courses = _repositoryManager.CoursesRepository.GetAll().ToList();
            var faculties = _repositoryManager.FacultysRepository.GetAll().ToList();
            var enrollments = _repositoryManager.EnrollmentsRepository.GetAll().ToList();
            var student = _repositoryManager.StudentsRepository.GetAll()
                                .FirstOrDefault(x => x.UserId == currentUser);

            if (student != null) 
            {
                var query = from teaching in teachings
                            join course in courses on teaching.CourseScheduleId equals course.Id into teachingCourses
                            from course in teachingCourses.DefaultIfEmpty()
                            join faculty in faculties on teaching.FacultyScheduleId equals faculty.Id into teachingFaculties
                            from faculty in teachingFaculties.DefaultIfEmpty()
                            join enrollment in enrollments on course?.Id equals enrollment.CourseId into courseEnrollments
                            from enrollment in courseEnrollments.DefaultIfEmpty()
                            where enrollment != null && enrollment.StudentId == student.Id
                            select new TeachingScheduleReadDto
                            {
                                Id = teaching.Id,
                                CourseName = course?.CourseName ?? "N/A",
                                FactlyName = faculty != null ? $"{faculty.LastName} {faculty.FirstName}" : "N/A",
                                StartAndEndTime = teaching.StartAndEndTime,
                                Date = teaching.Date,
                                Room = teaching.Room
                            };
                var result = query.ToList();
                int totalItem = result.Count();
                return new ResponseDataDto<TeachingScheduleReadDto>(result, totalItem);
            }
            else
            {
                return new ResponseDataDto<TeachingScheduleReadDto>(null, 0);
            }
     
        }

        public ResponseDataDto<TeachingScheduleReadDto> Search(string filter)
        {
            var teachings = _repositoryManager.TeachingScheduleRepository.GetAll();
            var courses = _repositoryManager.CoursesRepository.GetAll();
            var factlys = _repositoryManager.FacultysRepository.GetAll();

            var query = from teching in teachings
                        join course in courses on teching.CourseScheduleId equals course.Id into teachingCourse
                        from course in teachingCourse.DefaultIfEmpty()
                        join factly in factlys on teching.FacultyScheduleId equals factly.Id into teachingFaculty
                        from factly in teachingFaculty.DefaultIfEmpty()
                        
                        where factly.LastName.Contains(filter) || string.IsNullOrEmpty(filter)
                        select new TeachingScheduleReadDto
                        {
                            Id = teching.Id,
                            CourseName = course.CourseName,
                            FactlyName = factly.FirstName + ' ' + factly.LastName,
                            StartAndEndTime = teching.StartAndEndTime,
                            Date = teching.Date,
                            Room = teching.Room
                        };
            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<TeachingScheduleReadDto>(result, totalItem);
        }

        public ResponseActionDto<TeachingScheduleReadDto> Update(TeachingScheduleUpdateDto update)
        {
            if (_repositoryManager.TeachingScheduleRepository.GetAll().Any(x => x.Date == update.Date && x.StartAndEndTime == update.StartAndEndTime))
            {
                return new ResponseActionDto<TeachingScheduleReadDto>(null, -1, "Giờ này đã có người dạy", "");
            }
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
