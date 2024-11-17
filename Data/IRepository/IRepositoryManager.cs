namespace Data.IRepository
{
    public interface IRepositoryManager
    {
        IUsersRepository UsersRepository { get; }
        IRolesRepository RolesRepository { get; }
        IClassesRepository ClassesRepository { get; }
        ICoursesRepository CoursesRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IEnrollmentsRepository EnrollmentsRepository { get; }
        IFacultysRepository FacultysRepository { get; }
        IStudentsRepository StudentsRepository { get; }
    }
}
