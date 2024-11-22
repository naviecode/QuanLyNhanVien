namespace Data.IRepository
{
    public interface IRepositoryManager
    {
        IUsersRepository UsersRepository { get; }
        IRolesRepository RolesRepository { get; }
        IClassesRepository ClassesRepository { get; }
        IClassSectionsRepository ClassSectionsRepository { get; }
        ICoursesRepository CoursesRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IEnrollmentsRepository EnrollmentsRepository { get; }
        IFacultysRepository FacultysRepository { get; }
        IStudentsRepository StudentsRepository { get; }
        IPermissionsRepository PermissionsRepository { get; }
        IRolePermissionsRepository RolePermissionsRepository { get; }
        ITeachingScheduleRepository TeachingScheduleRepository { get; }
    }
}
