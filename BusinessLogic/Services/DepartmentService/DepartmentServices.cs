using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.IDepartmentService;
using BusinessLogic.IService.IDepartmentService.Dto;
using Data.Entities;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;

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
                                dept.DepartmentName.ToLower().Contains(filterInput.DepartmentName.ToLower()))
                        select new DepartmentSearchResultDto
                        {
                            DepartmentId = dept.Id,
                            DepartmentName = dept.DepartmentName
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<DepartmentSearchResultDto>(result, totalItem);
        }
        public ResponseDataDto<DepartmentSearchResultDto> GetCombobox()
        {
            var result = _repositoryManager.DepartmentsRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<DepartmentSearchResultDto>(_mapper.Map<List<Department>, List<DepartmentSearchResultDto>>(result), totalItem);
        }
    }
}
