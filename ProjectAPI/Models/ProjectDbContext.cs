using Microsoft.EntityFrameworkCore;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class ProjectDbContext : DbContext
    {

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, FName = "Viktor", LName = "Gunnarsson", Titel = "Utvecklare" });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, FName = "Erik", LName = "Norell", Titel = "Utvecklare" });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 3, FName = "Lukas", LName = "Rose", Titel = "Utvecklare" });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 4, FName = "Erik", LName = "Risholm", Titel = "Utvecklare" });



            modelBuilder.Entity<Project>().HasData(new Project { Id = 1, ProjectName = "Desktop Application" }); 
            modelBuilder.Entity<Project>().HasData(new Project { Id = 2, ProjectName = "Rest Api" }); 
            modelBuilder.Entity<Project>().HasData(new Project { Id = 3, ProjectName = "Mobile Application" }); 
            modelBuilder.Entity<Project>().HasData(new Project { Id = 4, ProjectName = "Presentation" });
            

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 1 , WeekNumber = 12, ProjectId = 1, EmployeeId = 1 ,HoursWorked = 40.20});  
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 2 , WeekNumber = 12, ProjectId = 2, EmployeeId = 1 ,HoursWorked = 10.20});  
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 3 , WeekNumber = 12, ProjectId = 3, EmployeeId = 3 ,HoursWorked = 10.50});  
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 4 , WeekNumber = 12, ProjectId = 4, EmployeeId = 1 ,HoursWorked = 12});  
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 5 , WeekNumber = 12, ProjectId = 2, EmployeeId = 2 ,HoursWorked = 40.2});  
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 6 , WeekNumber = 12, ProjectId = 3, EmployeeId = 2 ,HoursWorked = 10});  
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 7 , WeekNumber = 12, ProjectId = 4, EmployeeId = 4 ,HoursWorked = 45});  








            



        }


    }
}
