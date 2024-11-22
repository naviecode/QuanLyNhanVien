using AutoMapper;
using BusinessLogic.Helpers;
using BusinessLogic.IService;
using BusinessLogic.IService.ICourseService.Dto;
using BusinessLogic.IService.IFacultyService;
using BusinessLogic.IService.IFacultyService.Dto;
using BusinessLogic.IService.IUserService.Dto;
using Data.Entities;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.FacultyService
{
    public class FacultyServices : IFacultyServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public FacultyServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseDataDto<FacultyResultSearchDto> Search(FacultyFilterSearchDto filterInput)
        {
            var faculties = _repositoryManager.FacultysRepository.GetAll();
            var departments = _repositoryManager.DepartmentsRepository.GetAll();

            var query = from faculty in faculties
                        join department in departments on faculty.DepartmentId equals department.Id
                        where (string.IsNullOrEmpty(filterInput.FullName) ||
                               (faculty.LastName + " " + faculty.FirstName).ToLower().Contains(filterInput.FullName.ToLower()))
                              && (string.IsNullOrEmpty(filterInput.Email) ||
                                  faculty.Email.ToLower().Contains(filterInput.Email.ToLower()))
                              && (string.IsNullOrEmpty(filterInput.PhoneNumber) ||
                                  faculty.PhoneNumber.ToLower().Contains(filterInput.PhoneNumber.ToLower()))
                              && (string.IsNullOrEmpty(filterInput.DepartmentName) ||
                                  department.DepartmentName.ToLower().Contains(filterInput.DepartmentName.ToLower()))
                        select new FacultyResultSearchDto
                        {
                            FacultyId = faculty.Id,
                            FullName = faculty.LastName + " " + faculty.FirstName,
                            Email = faculty.Email,
                            PhoneNumber = faculty.PhoneNumber,
                            DepartmentName = department.DepartmentName
                        };

            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<FacultyResultSearchDto>(result, totalItem);
        }
        public ResponseActionDto<FacultyResultSearchDto> Create(FacultyAddDto data)
        {
            var checkIsExist = _repositoryManager.UsersRepository.GetAll()
                                    .Any(x => x.Username == data.Username);
            if (checkIsExist)
            {
                return new ResponseActionDto<FacultyResultSearchDto>(null, -1, "Thêm mới thất bại", "Trùng username");
            }

            var userIdNew = _repositoryManager.UsersRepository.Add(
                                _mapper.Map<UserCreateDto, Users>(new UserCreateDto
                                {
                                    Username = data.Username,
                                    PasswordHash = data.PasswordHash,
                                    RoleID = AppConsts.FacultyRoleId
                                }));
            data.UserId = userIdNew;

            checkIsExist = _repositoryManager.FacultysRepository.GetAll()
                            .Any(x => x.FirstName == data.FirstName &&
                                      x.LastName == data.LastName &&
                                      x.DepartmentId == data.DepartmentID &&
                                      x.Email == data.Email &&
                                      x.PhoneNumber == data.PhoneNumber);
            if (checkIsExist)
            {
                return new ResponseActionDto<FacultyResultSearchDto>(null, -1, "Thêm mới thất bại", "Giảng viên đã tồn tại!");
            }

            var idNew = _repositoryManager.FacultysRepository.Add(_mapper.Map<FacultyAddDto, Faculty>(data));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<FacultyResultSearchDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<FacultyResultSearchDto>(null, -1, "Thêm mới thất bại", "");
            }
        }
        public ResponseActionDto<FacultyResultSearchDto> Update(FacultyUpdateDto data)
        {
            var result = _repositoryManager.FacultysRepository.GetById(data.FacultyId);
            var userResult = _repositoryManager.UsersRepository.GetById(data.UserId);

            if (result != null && userResult != null)
            {
                _mapper.Map(new UserUpdateDto
                {
                    Id = data.UserId,
                    Username = data.Username,
                    PasswordHash = data.PasswordHash
                }, userResult);

                var userRes = _repositoryManager.UsersRepository.Update(userResult);

                _mapper.Map(data, result);
                var res = _repositoryManager.FacultysRepository.Update(result);

                if (res && userRes)
                {
                    return new ResponseActionDto<FacultyResultSearchDto>(new FacultyResultSearchDto(), 0, "Cập nhật thành công", "");
                }
                else
                {
                    return new ResponseActionDto<FacultyResultSearchDto>(new FacultyResultSearchDto(), -1, "Cập nhật không thành công", "");
                }
            }
            return new ResponseActionDto<FacultyResultSearchDto>(new FacultyResultSearchDto(), -1, "Không tìm thấy", "");
        }
        public ResponseActionDto<FacultyResultSearchDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.FacultysRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<FacultyResultSearchDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<FacultyResultSearchDto>(null, -1, "Xóa thất bại", "");
            }
        }
        public ResponseActionDto<FacultyByIdDto> GetById(int id)
        {
            var result = _repositoryManager.FacultysRepository.GetById(id);
            if (result != null)
            {
                var userResult = _repositoryManager.UsersRepository.GetById(result.UserId);
                var res = _mapper.Map<Faculty, FacultyByIdDto>(result);
                res.Username = userResult.Username;
                res.PasswordHash = userResult.PasswordHash;
                return new ResponseActionDto<FacultyByIdDto>(res, 0, "", "");
            }
            return new ResponseActionDto<FacultyByIdDto>(new FacultyByIdDto(), -1, "Không tìm thấy", "");
        }
        public ResponseDataDto<FacultyResultSearchDto> GetCombobox()
        {
            var faculties = _repositoryManager.FacultysRepository.GetAll();
            var departments = _repositoryManager.DepartmentsRepository.GetAll();

            var query = from faculty in faculties
                        join department in departments
                        on faculty.DepartmentId equals department.Id into departmentJoin
                        from dept in departmentJoin.DefaultIfEmpty()
                        select new FacultyResultSearchDto
                        {
                            FacultyId = faculty.Id,
                            FullName = faculty.LastName + " " + faculty.FirstName,
                            Email = faculty.Email,
                            PhoneNumber = faculty.PhoneNumber,
                            DepartmentName = dept != null ? dept.DepartmentName : string.Empty
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<FacultyResultSearchDto>(result, totalItem);
        }

    }
}
