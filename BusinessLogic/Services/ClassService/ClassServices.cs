using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IClassService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.IRoleService.Dto;
using Data.Entities;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.ClassService
{
    public class ClassServices : IClassServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ClassServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseActionDto<ClassSearchResultDto> Create(ClassAddDto data)
        {
            var checkIsExist = _repositoryManager.ClassesRepository.GetAll().Any(x => x.ClassName == data.ClassName && x.ClassYear == data.ClassYear && x.DepartmentId == data.DepartmentId);
            if (checkIsExist)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Thêm mới thất bại", "Lớp đã tồn tại trong hệ thống!");

            }
            var idNew = _repositoryManager.ClassesRepository.Add(_mapper.Map<ClassAddDto, Class>(data));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Thêm mới thất bại", "");
            }
        }
        public ResponseActionDto<ClassSearchResultDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.ClassesRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Xóa thất bại", "");
            }
        }
        public ResponseActionDto<ClassByIdDto> GetById(int classId)
        {
            var result = _repositoryManager.ClassesRepository.GetById(classId);

            if (result != null)
            {
                var dtoResult = _mapper.Map<Class, ClassByIdDto>(result);
                return new ResponseActionDto<ClassByIdDto>(dtoResult, 0, "", "");
            }
            return new ResponseActionDto<ClassByIdDto>(null, -1, "Không tìm thấy lớp học", "");
        }
        public ResponseDataDto<ClassSearchResultDto> Search(ClassFilterSearchDto filterInput)
        {
            var classes = _repositoryManager.ClassesRepository.GetAll();
            var departments = _repositoryManager.DepartmentsRepository.GetAll();

            var query = from cls in classes
                        join dept in departments
                        on cls.DepartmentId equals dept.Id into deptJoin
                        from department in deptJoin.DefaultIfEmpty() 
                        where (string.IsNullOrEmpty(filterInput.ClassName) || cls.ClassName.ToLower().Contains(filterInput.ClassName.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.ClassYear) || cls.ClassYear.ToLower().Contains(filterInput.ClassYear.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.DepartmentName) || department.DepartmentName.ToLower().Contains(filterInput.DepartmentName.ToLower()))
                        select new ClassSearchResultDto
                        {
                            ClassId = cls.Id,
                            ClassName = cls.ClassName,
                            ClassYear = cls.ClassYear,
                            DepartmentName = department != null ? department.DepartmentName : string.Empty 
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<ClassSearchResultDto>(result, totalItem);
        }



        public ResponseActionDto<ClassSearchResultDto> Update(ClassUpdateDto data)
        {
            var existingClass = _repositoryManager.ClassesRepository.GetById(data.ClassId);
            if (existingClass != null)
            {
                _mapper.Map(data, existingClass);

                var isUpdated = _repositoryManager.ClassesRepository.Update(existingClass);

                if (isUpdated)
                {
                    return new ResponseActionDto<ClassSearchResultDto>(null, 0, "Cập nhật thành công", "");
                }
                else
                {
                    return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Cập nhật không thành công", "");
                }
            }
            return new ResponseActionDto<ClassSearchResultDto>( null, -1, "Không tìm thấy lớp học", "");
        }

        public ResponseActionDto<ClassSearchResultDto> AssignStudentToClass(AssignStudentToClassDto data)
        {
            var classData = _repositoryManager.ClassesRepository.GetAll()
                .FirstOrDefault(x => x.Id == data.ClassId);

            if (classData == null)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Phân công thất bại", "Lớp học không tồn tại!");
            }

            var isAlreadyAssigned = _repositoryManager.StudentsRepository.GetAll()
                .Any(x => x.Id == data.StudentId && x.ClassId == data.ClassId);

            if (isAlreadyAssigned)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Phân công thất bại", "Sinh viên đã được phân công vào lớp này!");
            }

            var student = _repositoryManager.StudentsRepository.GetById(data.StudentId);
            if (student == null)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Phân công thất bại", "Sinh viên không tồn tại!");
            }

            student.ClassId = data.ClassId;
            var isUpdated = _repositoryManager.StudentsRepository.Update(student);

            if (isUpdated)
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, 0, "Phân công thành công", "Sinh viên đã được phân công vào lớp!");
            }
            else
            {
                return new ResponseActionDto<ClassSearchResultDto>(null, -1, "Phân công thất bại", "");
            }
        }
        public ResponseActionDto<ClassSearchResultDto> AddCourseToClass(AddCourseToClassDto data)
        {
            var isCourseAssigned = _repositoryManager.ClassSectionsRepository.GetAll()
                .Any(x => x.CourseId == data.CourseId &&
                          x.Semester == data.Semester && x.Year == data.Year);

            if (isCourseAssigned)
            {
                return new ResponseActionDto<ClassSearchResultDto>(
                    null, -1, "Thêm học phần thất bại", "Học phần đã được phân công cho một lớp khác trong học kỳ hiện tại!");
            }

            var classEntity = _repositoryManager.ClassesRepository.GetById(data.ClassId);
            if (classEntity == null)
            {
                return new ResponseActionDto<ClassSearchResultDto>(
                    null, -1, "Thêm học phần thất bại", "Không tìm thấy lớp học!");
            }

            var courseEntity = _repositoryManager.CoursesRepository.GetById(data.CourseId);
            if (courseEntity == null)
            {
                return new ResponseActionDto<ClassSearchResultDto>(
                    null, -1, "Thêm học phần thất bại", "Không tìm thấy khóa học!");
            }

            var facultyEntity = _repositoryManager.FacultysRepository.GetById(data.FacultyId);
            if (facultyEntity == null)
            {
                return new ResponseActionDto<ClassSearchResultDto>(
                    null, -1, "Thêm học phần thất bại", "Không tìm thấy giảng viên!");
            }

            var classSectionId = _repositoryManager.ClassSectionsRepository.Add(new ClassSection
            {
                ClassId = data.ClassId,
                CourseId = data.CourseId,
                FacultyId = data.FacultyId,
                Semester = data.Semester,
                Year = data.Year
            });

            if (classSectionId == null || classSectionId == 0)
            {
                return new ResponseActionDto<ClassSearchResultDto>(
                    null, -1, "Thêm học phần thất bại", "Không thể thêm học phần vào lớp!");
            }

            var currentStudentCount = _repositoryManager.StudentsRepository.GetAll()
                .Count(s => s.ClassId == data.ClassId);

            courseEntity.MaxAmountRegist -= currentStudentCount;
            _repositoryManager.CoursesRepository.Update(courseEntity);

            var studentsInClass = _repositoryManager.StudentsRepository.GetAll()
                .Where(s => s.ClassId == data.ClassId);

            foreach (var student in studentsInClass)
            {
                var isAlreadyEnrolled = _repositoryManager.EnrollmentsRepository.GetAll()
                    .Any(e => e.StudentId == student.Id && e.CourseId == data.CourseId);

                if (!isAlreadyEnrolled)
                {
                    _repositoryManager.EnrollmentsRepository.Add(new Enrollment
                    {
                        StudentId = student.Id,
                        CourseId = data.CourseId,
                        EnrollmentDate = DateTime.Now,
                        IsCanceled = false
                    });
                }
            }


            return new ResponseActionDto<ClassSearchResultDto>(null, 0, "Thêm học phần thành công!", "");
        }
        public ResponseDataDto<ClassSectionSearchResultDto> ClassSectionSearch(ClassSectionFilterSearchDto filterInput)
        {
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();
            var classes = _repositoryManager.ClassesRepository.GetAll();
            var courses = _repositoryManager.CoursesRepository.GetAll();
            var faculty = _repositoryManager.FacultysRepository.GetAll();

            var query = from cs in classSections
                        join cls in classes on cs.ClassId equals cls.Id
                        join crs in courses on cs.CourseId equals crs.Id
                        join fac in faculty on cs.FacultyId equals fac.Id into facJoin
                        from facultyMember in facJoin.DefaultIfEmpty()
                        where (string.IsNullOrEmpty(filterInput.ClassName) || cls.ClassName.ToLower().Contains(filterInput.ClassName.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.CourseName) || crs.CourseName.ToLower().Contains(filterInput.CourseName.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.FacultyName) ||
                               (facultyMember.LastName + " " + facultyMember.FirstName).ToLower().Contains(filterInput.FacultyName.ToLower()))
                           && (string.IsNullOrEmpty(filterInput.Semester) || cs.Semester.ToLower().Contains(filterInput.Semester.ToLower()))
                           && (!filterInput.Year.HasValue || filterInput.Year == 0 || cs.Year == filterInput.Year)
                        select new ClassSectionSearchResultDto
                        {
                            ClassSectionId = cs.Id,
                            ClassName = cls.ClassName,
                            CourseName = crs.CourseName,
                            FacultyName = facultyMember != null
                                ? facultyMember.LastName + " " + facultyMember.FirstName
                                : string.Empty,
                            Semester = cs.Semester,
                            Year = cs.Year
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<ClassSectionSearchResultDto>(result, totalItem);
        }

        public ResponseDataDto<ClassSearchResultDto> GetCombobox()
        {
            var result = _repositoryManager.ClassesRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<ClassSearchResultDto>(_mapper.Map<List<Class>, List<ClassSearchResultDto>>(result), totalItem);
        }

    }
}
