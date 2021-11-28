using System;
using CrudDemo.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CrudDemo.Data
{
    public class DemoDbContext : DbContext
    {        
        public DemoDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(employee => employee.Ref_Department)
                .WithMany(department => department.Ref_ManyEmployees)
                .HasForeignKey(employee => employee.DepartmentCode);
           

            // many-to-many navigation, Employee/Project
            // EF 6 can do this automatically for you but
            // I don't like the generated db objects
            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasKey(key => new {key.EmployeeId, key.ProjectId});
            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne(employee => employee.Ref_Employee)
                .WithMany(employee => employee.Ref_Projects)
                .HasForeignKey(employee => employee.EmployeeId);
            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne(project => project.Ref_Project)
                .WithMany(project => project.Ref_ManyEmployees)
                .HasForeignKey(project => project.ProjectId);

            modelBuilder.Entity<ProjectEntity>()
                 .HasOne(project => project.Ref_CreatedByEmployee)
                 .WithMany(employee => employee.Ref_CreatedProjects)
                 .HasForeignKey(project => project.CreatedByEmployeeId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DepartmentEntity>()
                .HasData(
                    new DepartmentEntity
                    {
                        DepartmentCode = "IT",
                        Name = "Information Technology"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "SALES",
                        Name = "Sales"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "AD",
                        Name = "Advertising"
                    },
                    new DepartmentEntity
                    {
                        DepartmentCode = "SUP",
                        Name = "Tech Support"
                    }
                );
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
    }

    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DemoDbContext>
    {
        public DemoDbContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile(Path.Combine(@Directory.GetCurrentDirectory(), "connectionStrings.json"))
            //    //.AddUserSecrets("8c724486-0e01-4d42-bfff-aeda2705bfc7")                
            //    .Build();
            var dbUser = Environment.GetEnvironmentVariable("SQLUSER");
            var dbPasswd = Environment.GetEnvironmentVariable("SQLPASSWD");
            var builder = new DbContextOptionsBuilder<DemoDbContext>();
            builder.UseSqlServer($"Server=tcp:127.0.0.1,1433;Database=CrudDemoDb;Trusted_Connection=true;integrated security=false;User Id={dbUser};password={dbPasswd}");
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //builder.UseNpgsql(connectionString);

            return new DemoDbContext(builder.Options);
        }
    }
}
