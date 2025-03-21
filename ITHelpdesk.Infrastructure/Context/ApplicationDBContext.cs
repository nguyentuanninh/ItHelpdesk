using ITHelpdesk.Domain.Entities;
using ITHelpdesk.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                               new Employee
                               {
                                   Id = 1,
                                   Username = "ninh",
                                   Password = "password",
                                   Role = Role.Admin,
                                   Name = "Nguyen Tuan Ninh",
                                   Email = "",
                                   GithubUsername = "johndoe",
                                   DateOfBirth = new DateTime(1990, 1, 1),
                                   PhoneNumber = "1234567890",
                                   IsActive = true,
                                   CreatedDate = DateTime.UtcNow,
                                   ModifiedDate = DateTime.UtcNow
                               },
                               new Employee
                               {
                                   Id = 1,
                                   Username = "phuc",
                                   Password = "password",
                                   Role = Role.Employee,
                                   Name = "Nguyen Duy Phuc",
                                   Email = "",
                                   GithubUsername = "johndoe",
                                   DateOfBirth = new DateTime(1990, 1, 1),
                                   PhoneNumber = "1234567890",
                                   IsActive = true,
                                   CreatedDate = DateTime.UtcNow,
                                   ModifiedDate = DateTime.UtcNow
                               },
                               new Employee
                               {
                                   Id = 1,
                                   Username = "manh",
                                   Password = "password",
                                   Role = Role.Employee,
                                   Name = "Nguyen Dinh Manh",
                                   Email = "",
                                   GithubUsername = "johndoe",
                                   DateOfBirth = new DateTime(1990, 1, 1),
                                   PhoneNumber = "1234567890",
                                   IsActive = true,
                                   CreatedDate = DateTime.UtcNow,
                                   ModifiedDate = DateTime.UtcNow
                               });
        }
    }
}
