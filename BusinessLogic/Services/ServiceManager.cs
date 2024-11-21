﻿using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IClassService;
using BusinessLogic.IService.ICourseService;
using BusinessLogic.IService.IDepartmentService;
using BusinessLogic.IService.IFacultyService;
using BusinessLogic.IService.IGradeService;
using BusinessLogic.IService.IRegistCourseService;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IStudentService;
using BusinessLogic.IService.IUserService;
using BusinessLogic.Services.ClassService;
using BusinessLogic.Services.CourseService;
using BusinessLogic.Services.DepartmentService;
using BusinessLogic.Services.FacultyService;
using BusinessLogic.Services.GradeService;
using BusinessLogic.Services.RegistCourseService;
using BusinessLogic.Services.StudentService;
using BusinessLogic.Services.UserService;
using Data.IRepository;
using Microsoft.EntityFrameworkCore.Internal;

namespace BusinessLogic.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServices> _lazyUserService;
        private readonly Lazy<IRoleServices> _lazyRoleService;
        private readonly Lazy<IStudentServices> _lazystudentService;
        private readonly Lazy<IClassServices> _lazyclassService;
        private readonly Lazy<ICourseServices> _lazycourseService;
        private readonly Lazy<IDepartmentServices> _lazydepartmentService;
        private readonly Lazy<IFacultyServices> _lazyfacultyService;
        private readonly Lazy<IGradeServices> _lazygradeService;
        private readonly Lazy<IRegistCourseServices> _lazyregistCourseService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _lazyUserService = new Lazy<IUserServices>(()=> new UserServices(repositoryManager, mapper));
            _lazyRoleService = new Lazy<IRoleServices>(() => new RoleServices(repositoryManager, mapper));
            _lazystudentService = new Lazy<IStudentServices>(() => new StudentServices(repositoryManager, mapper));
            _lazyclassService = new Lazy<IClassServices>(() => new ClassServices(repositoryManager, mapper));
            _lazycourseService = new Lazy<ICourseServices>(() => new CourseServices(repositoryManager, mapper));
            _lazydepartmentService = new Lazy<IDepartmentServices>(() => new DepartmentServices(repositoryManager, mapper));
            _lazyfacultyService = new Lazy<IFacultyServices>(() => new FacultyServices(repositoryManager, mapper));
            _lazygradeService = new Lazy<IGradeServices>(() => new GradeServices(repositoryManager, mapper));
            _lazyregistCourseService = new Lazy<IRegistCourseServices>(() => new RegistCourseServices(repositoryManager, mapper));
        }

        public IUserServices UserService => _lazyUserService.Value;
        public IRoleServices RoleService => _lazyRoleService.Value;
        public IStudentServices StudentService => _lazystudentService.Value;
        public IClassServices ClassService => _lazyclassService.Value;
        public ICourseServices CourseService => _lazycourseService.Value;
        public IDepartmentServices DepartmentService => _lazydepartmentService.Value;
        public IFacultyServices FacultyService => _lazyfacultyService.Value;
        public IGradeServices GradeService => _lazygradeService.Value;
        public IRegistCourseServices RegistCourseService => _lazyregistCourseService.Value;

    }
}
