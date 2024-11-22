
using BusinessLogic.IService.IClassService;
using BusinessLogic.IService.ICourseService;
using BusinessLogic.IService.IDepartmentService;
using BusinessLogic.IService.IFacultyService;
using BusinessLogic.IService.IGradeService;
using BusinessLogic.IService.IPermissions;
using BusinessLogic.IService.IRegistCourseService;
using BusinessLogic.IService.IRolePermissions;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IStudentService;
using BusinessLogic.IService.ITeachingScheduleService;
using BusinessLogic.IService.IUserService;

namespace BusinessLogic.IService
{
    public interface IServiceManager
    {
        IUserServices UserService { get; }
        IRoleServices RoleService { get; }
        IStudentServices StudentService { get; }
        IClassServices ClassService { get; }
        ICourseServices CourseService { get; }
        IDepartmentServices DepartmentService { get; }
        IFacultyServices FacultyService { get; }
        IGradeServices GradeService { get; }
        IRegistCourseServices RegistCourseService { get; }
        IPermissionService PermissionService { get; }
        IRolePermissionService RolePermissionService { get; }
        ITeachingScheduleServices TeachingScheduleService { get; }
    }
}
