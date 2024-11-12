using BusinessLogic.IService.IUserService;
using BusinessLogic.Services.UserService;
using Data;
using Data.IRepository;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

namespace Presentation
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            ServiceProvider = serviceCollection.BuildServiceProvider();


            ApplicationConfiguration.Initialize();
            var form1 = ServiceProvider.GetService<LoginScreen>();
            Application.Run(form1);
        }
        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddTransient<LoginScreen>();
        }
    }
}