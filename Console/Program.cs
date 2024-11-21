using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Consoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Load cấu hình
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Cấu hình DI container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("HelloWorld");

            // 3. Gọi service
            //var dataService = serviceProvider.GetService<>();
            //var students = dataService.GetAllStudents();

            //Console.WriteLine("Danh sách sinh viên:");
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student);
            //}
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Đăng ký chuỗi kết nối
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //// Đăng ký các service
            //services.AddSingleton<IDataService>(provider => new DataService(connectionString));
        }
    }
}
