using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString;

        public DatabaseContext() 
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }

        public DbSet<Students> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Class> Classes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermissions>()
                .HasKey(rp => new { rp.RoleID, rp.PermissionID });

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleID);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionID);

            modelBuilder.Entity<Students>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Students>(s => s.UserId);

            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.User)
                .WithOne(u => u.Faculty)
                .HasForeignKey<Faculty>(f => f.UserId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseID);

            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.Department)
                .WithMany(d => d.Faculties)
                .HasForeignKey(f => f.DepartmentID);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Faculty)
                .WithMany(f => f.Classes)
                .HasForeignKey(c => c.FacultyID);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany(c => c.Classes)
                .HasForeignKey(c => c.CourseID);

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasColumnType("decimal(5,2)");
        }
    }
}
