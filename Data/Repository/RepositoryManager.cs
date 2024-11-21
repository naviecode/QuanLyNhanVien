using Data.IRepository;

namespace Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DatabaseContext _databaseContext;
        public RepositoryManager(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }
        private IUsersRepository _usersRepository;
        private IRolesRepository _rolesRepository;
        private IPermissionsRepository _permissionsRepository;
        private IClassesRepository _classesRepository;
        private ICoursesRepository _coursesRepository;
        private IDepartmentsRepository _departmentsRepository;
        private IEnrollmentsRepository _enrollmentsRepository;
        private IFacultysRepository _facultysRepository;
        private IStudentsRepository _studentsRepository;
        private IRolePermissionsRepository _rolePermissionsRepository;


        public IUsersRepository UsersRepository => _usersRepository ?? new UsersRepository(_databaseContext);
        public IRolesRepository RolesRepository => _rolesRepository ?? new RolesRepository(_databaseContext);
        public IPermissionsRepository PermissionsRepository => _permissionsRepository ?? new PermissionsRepository(_databaseContext);
        public IClassesRepository ClassesRepository => _classesRepository ?? new ClassesRepository(_databaseContext);
        public ICoursesRepository CoursesRepository => _coursesRepository ?? new CoursesRepository(_databaseContext);
        public IDepartmentsRepository DepartmentsRepository => _departmentsRepository ?? new DepartmentsRepository(_databaseContext);
        public IEnrollmentsRepository EnrollmentsRepository => _enrollmentsRepository ?? new EnrollmentsRepository(_databaseContext);
        public IFacultysRepository FacultysRepository => _facultysRepository ?? new FacultyRepository(_databaseContext);
        public IStudentsRepository StudentsRepository => _studentsRepository ?? new StudentsRepository(_databaseContext);
        public IRolePermissionsRepository RolePermissionsRepository => _rolePermissionsRepository ?? new RolePermissionsRepository(_databaseContext);
    }
}
