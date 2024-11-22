using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IDepartmentService;
using BusinessLogic.IService.IDepartmentService.Dto;
using Data.Entities;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic.Services.DepartmentService
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DepartmentServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseActionDto<DepartmentSearchResultDto> Create(DepartmentAddDto data)
        {
            var checkIsExist = _repositoryManager.DepartmentsRepository.GetAll()
                                      .Any(x => x.DepartmentName == data.DepartmentName);
            if (checkIsExist)
            {
                return new ResponseActionDto<DepartmentSearchResultDto>(null, -1, "Thêm mới thất bại", "Tên khoa đã tồn tại trong hệ thống!");
            }

            var idNew = _repositoryManager.DepartmentsRepository.Add(_mapper.Map<DepartmentAddDto, Department>(data));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<DepartmentSearchResultDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<DepartmentSearchResultDto>(null, -1, "Thêm mới thất bại", "");
            }
        }
        public ResponseActionDto<DepartmentSearchResultDto> Update(DepartmentUpdateDto data)
        {
            var existingDepartment = _repositoryManager.DepartmentsRepository.GetById(data.DepartmentId);
            if (existingDepartment != null)
            {
                _mapper.Map(data, existingDepartment);

                var isUpdated = _repositoryManager.DepartmentsRepository.Update(existingDepartment);

                if (isUpdated)
                {
                    return new ResponseActionDto<DepartmentSearchResultDto>(null, 0, "Cập nhật thành công", "");
                }
                else
                {
                    return new ResponseActionDto<DepartmentSearchResultDto>(null, -1, "Cập nhật không thành công", "");
                }
            }
            return new ResponseActionDto<DepartmentSearchResultDto>(null, -1, "Không tìm thấy khoa", "");
        }

        public ResponseActionDto<DepartmentSearchResultDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.DepartmentsRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<DepartmentSearchResultDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<DepartmentSearchResultDto>(null, -1, "Xóa thất bại", "");
            }
        }
        public ResponseActionDto<DepartmentByIdDto> GetById(int departmentId)
        {
            var result = _repositoryManager.DepartmentsRepository.GetById(departmentId);

            if (result != null)
            {
                var dtoResult = _mapper.Map<Department, DepartmentByIdDto>(result);
                return new ResponseActionDto<DepartmentByIdDto>(dtoResult, 0, "", "");
            }
            return new ResponseActionDto<DepartmentByIdDto>(null, -1, "Không tìm thấy khoa", "");
        }
        public ResponseDataDto<DepartmentSearchResultDto> Search(DepartmentFilterSearchDto filterInput)
        {
            var departments = _repositoryManager.DepartmentsRepository.GetAll();

            var query = from dept in departments
                        where (string.IsNullOrEmpty(filterInput.DepartmentName) ||
                               EF.Functions.Like(dept.DepartmentName, $"%{filterInput.DepartmentName}%"))
                        select new DepartmentSearchResultDto
                        {
                            DepartmentId = dept.Id,
                            DepartmentName = dept.DepartmentName
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<DepartmentSearchResultDto>(result, totalItem);
        }

        public ResponseDataDto<DepartmentCountStudentsDto> DepartmentCountStudent()
        {
            var departments = _repositoryManager.DepartmentsRepository.GetAll();
            var classes = _repositoryManager.ClassesRepository.GetAll();
            var students = _repositoryManager.StudentsRepository.GetAll();

            var query = from department in departments
                         join classe in classes on department.Id equals classe.DepartmentId into departmentClass
                         from classe in departmentClass.DefaultIfEmpty()
                         join student in students on classe.Id equals student.ClassId into classesStudent
                         from student in classesStudent.DefaultIfEmpty()
                         group student by department.DepartmentName into departmentGroup
                         select new DepartmentCountStudentsDto
                         {
                             DepartmentName = departmentGroup.Key,
                             StudentCount = departmentGroup.Count(x=>x != null),
                         };
            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<DepartmentCountStudentsDto>(result, totalItem);

        }
    }
}
