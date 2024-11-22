using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IClassService.Dto;
using BusinessLogic.IService.ICourseService;
using BusinessLogic.IService.ICourseService.Dto;
using Data.Entities;
using Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.CourseService
{
    public class CourseServices : ICourseServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CourseServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseDataDto<CourseSearchResultDto> Search(CourseSearchFilterDto filterInput)
        {
            var courses = _repositoryManager.CoursesRepository.GetAll();
            var query = from course in courses
                        where (string.IsNullOrEmpty(filterInput.CourseName) || course.CourseName.ToLower().Contains(filterInput.CourseName.ToLower()))
                        && (filterInput.Credits == 0 || course.Credits == filterInput.Credits)
                        select new CourseSearchResultDto
                        {
                            Id = course.Id,
                            CourseName = course.CourseName,
                            Credits = course.Credits,
                            StartRegisterDate = course.StartRegisterDate,
                            EndRegisterDate = course.EndRegisterDate,
                            MaxAmountRegist = course.MaxAmountRegist,
                        };

            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<CourseSearchResultDto>(result, totalItem);
        }
        public ResponseActionDto<CourseSearchResultDto> Create(CourseAddDto data)
        {
            var checkIsExist = _repositoryManager.CoursesRepository.GetAll().Any(x => x.CourseName == data.CourseName);
            if (checkIsExist)
            {
                return new ResponseActionDto<CourseSearchResultDto>(null, -1, "Thêm mới thất bại", "Khóa học đã tồn tại trong hệ thống!");

            }
            var idNew = _repositoryManager.CoursesRepository.Add(_mapper.Map<CourseAddDto, Course>(data));
            if (idNew != null && idNew != 0)
            {
                return new ResponseActionDto<CourseSearchResultDto>(null, 0, "Thêm mới thành công", idNew.ToString());
            }
            else
            {
                return new ResponseActionDto<CourseSearchResultDto>(null, -1, "Thêm mới thất bại", "");
            }
        }
        public ResponseActionDto<CourseSearchResultDto> Delete(int id)
        {
            var isSuccess = _repositoryManager.CoursesRepository.Delete(id);
            if (isSuccess)
            {
                return new ResponseActionDto<CourseSearchResultDto>(null, 0, "Xóa thành công", "");
            }
            else
            {
                return new ResponseActionDto<CourseSearchResultDto>(null, -1, "Xóa thất bại", "");
            }
        }
        public ResponseActionDto<CourseSearchResultDto> Update(CourseUpdateDto data)
        {
            var result = _repositoryManager.CoursesRepository.GetById(data.CourseId);
            if (result != null)
            {
                _mapper.Map(data, result);
                var res = _repositoryManager.CoursesRepository.Update(result);
                if (res == true)
                    return new ResponseActionDto<CourseSearchResultDto>(new CourseSearchResultDto(), 0, "Cập nhập thành công", "");
                else
                    return new ResponseActionDto<CourseSearchResultDto>(new CourseSearchResultDto(), -1, "Cập nhập không thành công", "");
            }
            return new ResponseActionDto<CourseSearchResultDto>(new CourseSearchResultDto(), -1, "Không tìm thấy", "");

        }
        public ResponseActionDto<CourseResultByIdDto> GetById(int userId)
        {
            var result = _repositoryManager.CoursesRepository.GetById(userId);
            if (result != null)
            {
                return new ResponseActionDto<CourseResultByIdDto>(_mapper.Map<Course, CourseResultByIdDto>(result), 0, "", "");
            }
            return new ResponseActionDto<CourseResultByIdDto>(new CourseResultByIdDto(), -1, "Không tìm thấy", "");
        }
        public ResponseDataDto<CourseSearchResultDto> GetCombobox()
        {
            var currentDate = DateTime.Now;

            var courses = _repositoryManager.CoursesRepository.GetAll();
            var classSections = _repositoryManager.ClassSectionsRepository.GetAll();

            var registeredCourseIds = classSections.Select(cs => cs.CourseId).Distinct().ToHashSet();

            var query = from course in courses
                        where course.StartRegisterDate <= currentDate
                           && course.EndRegisterDate >= currentDate
                           && course.MaxAmountRegist > 0
                           && !registeredCourseIds.Contains(course.Id) 
                        select new CourseSearchResultDto
                        {
                            Id = course.Id,
                            CourseName = course.CourseName,
                            Credits = course.Credits,
                            StartRegisterDate = course.StartRegisterDate,
                            EndRegisterDate = course.EndRegisterDate,
                            MaxAmountRegist = course.MaxAmountRegist
                        };

            var result = query.ToList();
            int totalItem = result.Count();

            return new ResponseDataDto<CourseSearchResultDto>(result, totalItem);
        }
        public ResponseDataDto<CourseNearCloseDto> CourseNearClose()
        {   /*
                ĐÃ ĐÓNG:
                CÒN MỞ: 
                SẮP ĐÓNG: CÒN 5 NGÀY NỮA HẾT HẠN ĐĂNG KÝ
             */
            var courses = _repositoryManager.CoursesRepository.GetAll();
            var query = from course in courses
                        where course.EndRegisterDate >= DateTime.Now && course.MaxAmountRegist != 0
                        orderby course.EndRegisterDate ascending
                        select new CourseNearCloseDto
                        {
                            CourseName = course.CourseName,
                            EndRegisterDate = course.EndRegisterDate,
                            MaxAmountRegist = course.MaxAmountRegist,
                            Status = (course.EndRegisterDate - DateTime.Now).Days < 5 ? "Sắp đóng" : "Còn mở"
                        };

            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<CourseNearCloseDto>(result, totalItem);
        }

        public ResponseDataDto<CourseSearchResultDto> GetCombobox_sonnq()
        {
            var courses = _repositoryManager.CoursesRepository.GetAll();
            var query = from course in courses
                        select new CourseSearchResultDto
                        {
                            Id = course.Id,
                            CourseName = course.CourseName
                        };
            var result = query.ToList();
            int totalItem = result.Count();
            return new ResponseDataDto<CourseSearchResultDto>(result, totalItem);
        }
    }
}
