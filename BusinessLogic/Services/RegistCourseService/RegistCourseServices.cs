using AutoMapper;
using BusinessLogic.Helpers;
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
        public ResponseActionDto<RegisteredSearchResultto> RegisterCourse(CourseRegistrationDto data)
        {
            var course = _repositoryManager.CoursesRepository.GetAll()
                .FirstOrDefault(x => x.Id == data.CourseId);

            if (course == null)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Đăng ký thất bại", "Khóa học không tồn tại!");
            }

            if (DateTime.Now < course.StartRegisterDate || DateTime.Now > course.EndRegisterDate)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Đăng ký thất bại", "Đã hết hạn đăng ký!");
            }

            var currentEnrollments = _repositoryManager.EnrollmentsRepository.GetAll()
                .Count(x => x.CourseId == data.CourseId);

            if (currentEnrollments >= course.MaxAmountRegist)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Đăng ký thất bại", "Khóa học đã đầy!");
            }

            var isAlreadyEnrolled = _repositoryManager.EnrollmentsRepository.GetAll()
                .Any(x => x.StudentId == data.StudentId && x.CourseId == data.CourseId);

            if (isAlreadyEnrolled)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Đăng ký thất bại", "Sinh viên đã đăng ký khóa học này!");
            }

            var enrollment = new Enrollment
            {
                StudentId = data.StudentId,
                CourseId = data.CourseId,
                EnrollmentDate = DateTime.Now,
                IsCanceled = false
            };
            var idNew = _repositoryManager.EnrollmentsRepository.Add(enrollment);

            if (idNew != null && idNew != 0)
            {
                course.MaxAmountRegist -= 1;
                _repositoryManager.CoursesRepository.Update(course);

                return new ResponseActionDto<RegisteredSearchResultto>(null, 0, "Đăng ký thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Đăng ký thất bại", "");
            }
        }
        public ResponseActionDto<RegisteredSearchResultto> CancelRegistration(int courseId)
        {
            var student = _repositoryManager.StudentsRepository.GetAll()
                .FirstOrDefault(s => s.UserId == UserSession.UserId);

            if (student == null)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Hủy đăng ký thất bại", "Sinh viên không tồn tại!");
            }

            var classSection = _repositoryManager.ClassSectionsRepository.GetAll()
                .FirstOrDefault(cs => cs.CourseId == courseId);

            if (classSection == null)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Hủy đăng ký thất bại", "Lớp học không tồn tại!");
            }

            var checkCourse = _repositoryManager.CoursesRepository.GetAll().FirstOrDefault(x => x.Id == courseId);
            if (checkCourse.EndRegisterDate < DateTime.Now)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Hủy đăng ký thất bại", "Thời hạn đăng ký đã kết thúc, không thể hủy!");
            }

            if (classSection.ClassId == student.ClassId)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Hủy đăng ký thất bại", "Không thể hủy khóa học thuộc lớp học chính!");
            }

            var enrollment = _repositoryManager.EnrollmentsRepository.GetAll()
                .FirstOrDefault(e => e.StudentId == student.Id && e.CourseId == courseId);

            if (enrollment == null)
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Hủy đăng ký thất bại", "Sinh viên chưa đăng ký khóa học này!");
            }

            enrollment.IsCanceled = true;
            var isUpdated = _repositoryManager.EnrollmentsRepository.Update(enrollment);

            if (isUpdated)
            {
                var course = _repositoryManager.CoursesRepository.GetById(courseId);
                if (course != null)
                {
                    course.MaxAmountRegist += 1;
                    _repositoryManager.CoursesRepository.Update(course);
                }

                return new ResponseActionDto<RegisteredSearchResultto>(null, 0, "Hủy đăng ký thành công", "");
            }
            else
            {
                return new ResponseActionDto<RegisteredSearchResultto>(null, -1, "Hủy đăng ký thất bại", "Có lỗi xảy ra trong quá trình hủy!");
            }
        }

        public ResponseDataDto<RegisteredSearchResultto> GetRegisteredCourses(RegisteredFilterSearchDto filterInput)
        {
            var students = _repositoryManager.StudentsRepository.GetAll();
            var enrollments = _repositoryManager.EnrollmentsRepository.GetAll();
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();
            var classes = _repositoryManager.ClassesRepository.GetAll();
            var courses = _repositoryManager.CoursesRepository.GetAll();
            var faculties = _repositoryManager.FacultysRepository.GetAll();

            var query = from student in students
                        join enrollment in enrollments on student.Id equals enrollment.StudentId
                        join classSection in classSections on enrollment.CourseId equals classSection.CourseId
                        join cls in classes on classSection.ClassId equals cls.Id
                        join course in courses on classSection.CourseId equals course.Id
                        join faculty in faculties on classSection.FacultyId equals faculty.Id into facultyJoin
                        from faculty in facultyJoin.DefaultIfEmpty()
                        where student.UserId == UserSession.UserId
                           && enrollment.IsCanceled == null
                           && (string.IsNullOrEmpty(filterInput.ClassName) || cls.ClassName.ToLower().Contains(filterInput.ClassName.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.CourseName) || course.CourseName.ToLower().Contains(filterInput.CourseName.ToLower()))
                           && (!filterInput.Credits.HasValue || course.Credits == filterInput.Credits.Value)
                           && (string.IsNullOrEmpty(filterInput.FacultyName) || (faculty.LastName + " " + faculty.FirstName).ToLower().Contains(filterInput.FacultyName.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.Semester) || classSection.Semester.ToLower().Contains(filterInput.Semester.ToLower()))
                           && (!filterInput.Year.HasValue || classSection.Year == filterInput.Year.Value)
                        select new RegisteredSearchResultto
                        {
                            ClassId = cls.Id,
                            ClassName = cls.ClassName,
                            CourseId = course.Id,
                            CourseName = course.CourseName,
                            Credits = course.Credits,
                            Semester = classSection.Semester,
                            Year = classSection.Year,
                            Status = enrollment.IsCanceled == true ? "Đã hủy" : "Đang học",
                            FacultyName = faculty != null ? (faculty.LastName + " " + faculty.FirstName) : "Không rõ"
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<RegisteredSearchResultto>(result, totalItem);
        }



    }
}
