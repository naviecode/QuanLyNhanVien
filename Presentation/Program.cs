using BusinessLogic.IService;
using BusinessLogic.Mapper;
using BusinessLogic.Services;
using Data;
using Data.IRepository;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;
using System.Globalization;

namespace Presentation
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");

            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            var form1 = ServiceProvider.GetService<HostForm>();
            Application.Run(form1);
        }
        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);
            services.AddAutoMapper(typeof(RolesMapperProfile).Assembly);
            services.AddAutoMapper(typeof(PermissionsMapperProfile).Assembly);
            services.AddAutoMapper(typeof(ClassMapperProfile).Assembly);
            services.AddAutoMapper(typeof(CourseMapperProfile).Assembly);
            services.AddAutoMapper(typeof(DepartmentMapperProfile).Assembly);
            services.AddAutoMapper(typeof(FacultyMapperProfile).Assembly);
            services.AddAutoMapper(typeof(StudentMapperProfile).Assembly);
            services.AddAutoMapper(typeof(RolePermissionsMapperProfile).Assembly);


            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddTransient<HostForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<LoginScreen>();
        }
    }
}