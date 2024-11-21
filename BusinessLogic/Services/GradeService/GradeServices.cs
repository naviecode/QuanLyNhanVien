using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IGradeService;
using BusinessLogic.IService.IGradeService.Dto;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.GradeService
{
    public class GradeServices : IGradeServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GradeServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseActionDto<StudentGradeSearchResultDto> AddOrUpdateGrade(GradeAddOrUpdateDto data)
        {
            var enrollments = _repositoryManager.EnrollmentsRepository.GetAll();
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();

            var enrollment = (from e in enrollments
                              join cs in classSections
                              on e.CourseId equals cs.CourseId
                              where e.StudentId == data.StudentId
                                 && cs.CourseId == data.CourseId
                                 && cs.Semester == data.Semester
                                 && cs.Year == data.Year
                              select e).FirstOrDefault();

            if (enrollment == null)
            {
                return new ResponseActionDto<StudentGradeSearchResultDto>(null, -1, "Nhập điểm thất bại", "Không tìm thấy bản ghi đăng ký khóa học tương ứng!");
            }

            enrollment.Grade = data.Grade;

            var isUpdated = _repositoryManager.EnrollmentsRepository.Update(enrollment);

            if (isUpdated)
            {
                return new ResponseActionDto<StudentGradeSearchResultDto>(null, 0, "Nhập điểm thành công", "");
            }
            else
            {
                return new ResponseActionDto<StudentGradeSearchResultDto>(null, -1, "Nhập điểm thất bại", "Có lỗi xảy ra khi cập nhật điểm!");
            }
        }
        public ResponseDataDto<StudentGradeSearchResultDto> SearchGrades(StudentGradeFilterSearchDto filterInput)
        {
            var enrollments = _repositoryManager.EnrollmentsRepository.GetAll();
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();
            var students = _repositoryManager.StudentsRepository.GetAll();
            var courses = _repositoryManager.CoursesRepository.GetAll();

            var query = from e in enrollments
                        join cs in classSections on e.CourseId equals cs.CourseId
                        join s in students on e.StudentId equals s.Id
                        join c in courses on cs.CourseId equals c.Id
                        where (string.IsNullOrEmpty(filterInput.StudentName) || EF.Functions.Like((s.LastName + " " + s.FirstName), $"%{filterInput.StudentName}%"))
                           && (string.IsNullOrEmpty(filterInput.CourseName) || EF.Functions.Like(c.CourseName, $"%{filterInput.CourseName}%"))
                           && (!filterInput.Grade.HasValue || e.Grade == filterInput.Grade)
                           && (string.IsNullOrEmpty(filterInput.Semester) || cs.Semester == filterInput.Semester)
                           && (filterInput.Year == 0 || cs.Year == filterInput.Year)
                        select new StudentGradeSearchResultDto
                        {
                            StudentId = s.Id,
                            StudentName = s.LastName + " " + s.FirstName,
                            CourseId = c.Id,
                            CourseName = c.CourseName,
                            Grade = e.Grade,
                            Semester = cs.Semester,
                            Year = cs.Year
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<StudentGradeSearchResultDto>(result, totalItem);
        }
        public ResponseActionDto<StudentGradeByIdDto> GetById(int studentId, int courseId, string semester, int year)
        {
            var enrollments = _repositoryManager.EnrollmentsRepository.GetAll();
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();
            var students = _repositoryManager.StudentsRepository.GetAll();
            var courses = _repositoryManager.CoursesRepository.GetAll();

            var query = (from e in enrollments
                         join cs in classSections on e.CourseId equals cs.CourseId
                         join s in students on e.StudentId equals s.Id
                         join c in courses on cs.CourseId equals c.Id
                         where e.StudentId == studentId
                               && e.CourseId == courseId
                               && cs.Semester == semester
                               && cs.Year == year
                         select new StudentGradeByIdDto
                         {
                             StudentId = s.Id,
                             StudentName = s.LastName + " " + s.FirstName,
                             CourseId = c.Id,
                             CourseName = c.CourseName,
                             Grade = e.Grade,
                             Semester = cs.Semester,
                             Year = cs.Year
                         }).FirstOrDefault();

            if (query != null)
            {
                return new ResponseActionDto<StudentGradeByIdDto>(query, 0, "Lấy thông tin thành công", "");
            }
            else
            {
                return new ResponseActionDto<StudentGradeByIdDto>(null, -1, "Không tìm thấy thông tin", "");
            }
        }

    }
}
