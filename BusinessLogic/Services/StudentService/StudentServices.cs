using AutoMapper;
using BusinessLogic.Helpers;
using BusinessLogic.IService;
using BusinessLogic.IService.IStudentService;
using BusinessLogic.IService.IStudentService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using Data.Entities;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.StudentService
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public StudentServices(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseDataDto<StudentSearchResultDto> Search(StudentSearchFilterDto filterInput)
        {
            var students = _repositoryManager.StudentsRepository.GetAll();
            var classes = _repositoryManager.ClassesRepository.GetAll();
            var query = from student in students
                        join lop in classes on student.ClassId equals lop.Id into lop
                        from subItem in lop.DefaultIfEmpty()
                        where (string.IsNullOrEmpty(filterInput.FullName) || (student.LastName + " " + student.FirstName).ToLower().Contains(filterInput.FullName.ToLower()))
                        && (string.IsNullOrEmpty(filterInput.Gender) || student.Gender.ToLower() == filterInput.Gender.ToLower())
                        && (string.IsNullOrEmpty(filterInput.Email) || student.Email.ToLower().Contains(filterInput.Email.ToLower()))
                        && (string.IsNullOrEmpty(filterInput.PhoneNumber) || student.PhoneNumber.ToLower().Contains(filterInput.PhoneNumber.ToLower()))
                        && (string.IsNullOrEmpty(filterInput.Address) || student.Address.ToLower().Contains(filterInput.Address.ToLower()))
                        && (string.IsNullOrEmpty(filterInput.ClassName) || subItem.ClassName.ToLower().Contains(filterInput.ClassName.ToLower()))
                        && (filterInput.UserId == null || student.UserId == filterInput.UserId)
                        select new StudentSearchResultDto
                        {
                            StudentId = student.Id,
                            FullName = student.LastName + " " + student.FirstName,
                            DateOfBirth = student.DateOfBirth,
                            Gender = student.Gender,
                            Email = student.Email,
                            PhoneNumber = student.PhoneNumber,
                            Address = student.Address,
                            EnrollmentDate = student.EnrollmentDate,
                            ClassName = subItem.ClassName,
                        };
            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<StudentSearchResultDto>(result, totalItem);
        }
        public ResponseDataDto<Students> GetAll()
        {
            var result = _repositoryManager.StudentsRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<Students>(result, totalItem);

        }
        public ResponseActionDto<StudentSearchResultDto> Create(StudentAddDto data)
        {
            var checkIsExist = _repositoryManager.UsersRepository.GetAll().Any(x => x.Username == data.Username);
            if (checkIsExist)
            {
                return new ResponseActionDto<StudentSearchResultDto>(null, -1, "Thêm mới thất bại", "Trùng username");
            }
            var userIdNew = _repositoryManager.UsersRepository.Add(_mapper.Map<UserCreateDto, Users>(new UserCreateDto() { Username = data.Username, PasswordHash = data.PasswordHash, RoleID = AppConsts.StudentRoleId}));
            data.UserId = userIdNew;

            checkIsExist = _repositoryManager.StudentsRepository.GetAll().Any(x => x.FirstName == data.FirstName && x.LastName == data.LastName &&
                                                                                       x.DateOfBirth == data.DateOfBirth && x.Gender == data.Gender &&
                                                                                       x.Email == data.Email && x.PhoneNumber == data.PhoneNumber &&
                                                                                       x.Address == data.Address && x.EnrollmentDate == data.EnrollmentDate);
            if (checkIsExist)
            {
                return new ResponseActionDto<StudentSearchResultDto>(null, -1, "Thêm mới thất bại", "Sinh viên đã tồn tại trong hệ thống!");

            }
            var idNew = _repositoryManager.StudentsRepository.Add(_mapper.Map<StudentAddDto, Students>(data));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<StudentSearchResultDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<StudentSearchResultDto>(null, -1, "Thêm mới thất bại", "");
            }
        }
        public ResponseActionDto<StudentSearchResultDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.StudentsRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<StudentSearchResultDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<StudentSearchResultDto>(null, -1, "Xóa thất bại", "");
            }
        }
        public ResponseActionDto<StudentSearchResultDto> Update(StudentUpdateDto data)
        {
            var result = _repositoryManager.StudentsRepository.GetById(data.Id);
            var userResult = _repositoryManager.UsersRepository.GetById(data.UserId);
            if (result != null && userResult != null)
            {
                _mapper.Map(new UserUpdateDto() { Id = data.UserId, Username = data.Username, PasswordHash = data.PasswordHash}, userResult);
                var userRes = _repositoryManager.UsersRepository.Update(userResult);
                _mapper.Map(data, result);
                var res = _repositoryManager.StudentsRepository.Update(result);
                if (res == true && userRes == true)
                    return new ResponseActionDto<StudentSearchResultDto>(new StudentSearchResultDto(), 0, "Cập nhập thành công", "");
                else
                    return new ResponseActionDto<StudentSearchResultDto>(new StudentSearchResultDto(), -1, "Cập nhập không thành công", "");
            }
            return new ResponseActionDto<StudentSearchResultDto>(new StudentSearchResultDto(), -1, "Không tìm thấy", "");

        }
        public ResponseActionDto<StudentResultByIdDto> GetById(int id)
        {
            var result = _repositoryManager.StudentsRepository.GetById(id);
            if (result != null)
            {
                var studentUser = _repositoryManager.UsersRepository.GetById(result.UserId);
                var res = _mapper.Map<Students, StudentResultByIdDto>(result);
                res.Username = studentUser.Username;
                res.PasswordHash = studentUser.PasswordHash;
                res.RoleID = studentUser.RoleID;
                return new ResponseActionDto<StudentResultByIdDto>(res, 0, "", "");
            }
            return new ResponseActionDto<StudentResultByIdDto>(new StudentResultByIdDto(), -1, "Không tìm thấy", "");

        }

        public ResponseActionDto<StudentGetInfoDto> GetInfoUser(StudentGetInfoFilterDto input)
        {
            var students = _repositoryManager.StudentsRepository.GetAll();
            var departments = _repositoryManager.DepartmentsRepository.GetAll();
            var classes = _repositoryManager.ClassesRepository.GetAll();
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();

            var studentInfoFull = from student in students
                                  join classe in classes on student.ClassId equals classe.Id into intoStudentClass
                                  from classe in intoStudentClass.DefaultIfEmpty()
                                  join department in departments on classe.DepartmentId equals department.Id into ClassDepartment
                                  from department in ClassDepartment.DefaultIfEmpty()
                                  where (string.IsNullOrEmpty(input.StudentName) || EF.Functions.Like((student.LastName + " " + student.FirstName), $"%{input.StudentName}%"))
                                  && (input.UserCurrentId == 0 || student.UserId == input.UserCurrentId)
                                  && (input.StudentId  == 0 || student.Id == input.StudentId)
                                  && (input.DepartmentId == 0 || department.Id == input.DepartmentId)
                                  select new StudentGetInfoDto
                                  {
                                      StudentId = student.Id,
                                      FullName = student.FirstName + ' ' + student.LastName,
                                      DateOfBirth = student.DateOfBirth,
                                      Gender = student.Gender,
                                      Email = student.Email,
                                      PhoneNumber = student.PhoneNumber,
                                      Address = student.Address,
                                      EnrollmentDate = student.EnrollmentDate,
                                      Country = "HCM",
                                      UserId = student.UserId,
                                      DepartmentName = department.DepartmentName,
                                      ClassName = classe.ClassName
                                  };

            return new ResponseActionDto<StudentGetInfoDto>(studentInfoFull.FirstOrDefault() ?? new StudentGetInfoDto(), 0, "", "");
        }

        public ResponseDataDto<StudentTrendDto> StudentTrend()
        {
            var students = _repositoryManager.StudentsRepository.GetAll();
            var query = from student in students
                        group student by student.EnrollmentDate.Year into studentGroup
                        select new StudentTrendDto
                        {
                           Year = studentGroup.Key,
                           CountStudent = studentGroup.Count(x=> x!= null)

                        };
            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<StudentTrendDto>(result, totalItem);
        }

    }
}
