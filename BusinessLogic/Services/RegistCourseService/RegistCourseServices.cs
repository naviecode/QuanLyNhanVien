using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IRegistCourseService;
using BusinessLogic.IService.IRegistCourseService.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.RegistCourseService
{
    public class RegistCourseServices : IRegistCourseServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public RegistCourseServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseActionDto<RegisteredCourseDto> RegisterCourse(CourseRegistrationDto data)
        {
            var course = _repositoryManager.CoursesRepository.GetAll()
                .FirstOrDefault(x => x.Id == data.CourseId);

            if (course == null)
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Đăng ký thất bại", "Khóa học không tồn tại!");
            }

            if (DateTime.Now < course.StartRegisterDate || DateTime.Now > course.EndRegisterDate)
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Đăng ký thất bại", "Đã hết hạn đăng ký!");
            }

            var currentEnrollments = _repositoryManager.EnrollmentsRepository.GetAll()
                .Count(x => x.CourseId == data.CourseId);

            if (currentEnrollments >= course.MaxAmountRegist)
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Đăng ký thất bại", "Khóa học đã đầy!");
            }

            var isAlreadyEnrolled = _repositoryManager.EnrollmentsRepository.GetAll()
                .Any(x => x.StudentId == data.StudentId && x.CourseId == data.CourseId);

            if (isAlreadyEnrolled)
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Đăng ký thất bại", "Sinh viên đã đăng ký khóa học này!");
            }

            var enrollment = new Enrollment
            {
                StudentId = data.StudentId,
                CourseId = data.CourseId,
                EnrollmentDate = data.EnrollmentDate,
                IsCanceled = false
            };
            var idNew = _repositoryManager.EnrollmentsRepository.Add(enrollment);

            if (idNew != null && idNew != 0)
            {
                course.MaxAmountRegist -= 1;
                _repositoryManager.CoursesRepository.Update(course);

                return new ResponseActionDto<RegisteredCourseDto>(null, 0, "Đăng ký thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Đăng ký thất bại", "");
            }
        }
        public ResponseActionDto<RegisteredCourseDto> CancelRegistration(CancelRegistrationDto data)
        {
            var classSection = _repositoryManager.ClassSectionsRepository.GetAll()
                .FirstOrDefault(x => x.Id == data.ClassId);

            if (classSection == null)
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Hủy đăng ký thất bại", "Lớp học không tồn tại!");
            }

            var enrollment = _repositoryManager.EnrollmentsRepository.GetAll()
                .FirstOrDefault(x => x.StudentId == data.StudentId && x.CourseId == classSection.CourseId);

            if (enrollment == null)
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Hủy đăng ký thất bại", "Sinh viên chưa đăng ký khóa học này!");
            }

            enrollment.IsCanceled = true;
            var isUpdated = _repositoryManager.EnrollmentsRepository.Update(enrollment);

            if (isUpdated)
            {
                var course = _repositoryManager.CoursesRepository.GetById(classSection.CourseId);
                if (course != null)
                {
                    course.MaxAmountRegist += 1;
                    _repositoryManager.CoursesRepository.Update(course);
                }

                return new ResponseActionDto<RegisteredCourseDto>(null, 0, "Hủy đăng ký thành công", "");
            }
            else
            {
                return new ResponseActionDto<RegisteredCourseDto>(null, -1, "Hủy đăng ký thất bại", "Có lỗi xảy ra trong quá trình hủy!");
            }
        }
        public ResponseActionDto<List<RegisteredCourseDto>> GetRegisteredCourses(int studentId)
        {
            var enrollments = _repositoryManager.EnrollmentsRepository.GetAll()
                .Where(x => x.StudentId == studentId && x.IsCanceled == null)
                .ToList();

            if (!enrollments.Any())
            {
                return new ResponseActionDto<List<RegisteredCourseDto>>(null, -1, "Không có khóa học nào được đăng ký!", "");
            }

            var result = enrollments.Select(enrollment =>
            {
                var classSection = _repositoryManager.ClassSectionsRepository.GetAll()
                    .FirstOrDefault(cs => cs.CourseId == enrollment.CourseId);
                var course = _repositoryManager.CoursesRepository.GetById(enrollment.CourseId);

                return new RegisteredCourseDto
                {
                    ClassId = classSection?.Id ?? 0,
                    CourseId = enrollment.CourseId,
                    CourseName = course?.CourseName ?? "Không rõ",
                    Credits = course?.Credits ?? 0,
                    Semester = classSection?.Semester ?? "Không rõ",
                    Year = classSection?.Year ?? 0,
                    Status = enrollment.IsCanceled == true ? "Đã hủy" : "Đang học"
                };
            }).ToList();

            return new ResponseActionDto<List<RegisteredCourseDto>>(result, 0, "Lấy danh sách khóa học thành công!", "");
        }
    }
}
