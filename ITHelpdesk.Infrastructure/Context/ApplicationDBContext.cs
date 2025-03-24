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
                                   Password = "$2a$10$Jil6WdJRhv8MYNqBwMbc7u445ywywJ2fyddH1SMJ5rrf3KL/cmjEK",
                                   Role = Role.Admin,
                                   Name = "Nguyen Tuan Ninh",
                                   Email = "",
                                   GithubUsername = "johndoe",
                                   DateOfBirth = DateTime.UtcNow,
                                   PhoneNumber = "1234567890",
                                   IsActive = true,
                                   CreatedDate = DateTime.UtcNow,
                                   ModifiedDate = DateTime.UtcNow
                               },
                               new Employee
                               {
                                   Id = 2,
                                   Username = "phuc",
                                   Password = "$2a$10$Jil6WdJRhv8MYNqBwMbc7u445ywywJ2fyddH1SMJ5rrf3KL/cmjEK",
                                   Role = Role.Operator,
                                   Name = "Nguyen Duy Phuc",
                                   Email = "",
                                   GithubUsername = "johndoe",
                                   DateOfBirth = DateTime.UtcNow,
                                   PhoneNumber = "1234567890",
                                   IsActive = true,
                                   CreatedDate = DateTime.UtcNow,
                                   ModifiedDate = DateTime.UtcNow
                               },
                               new Employee
                               {
                                   Id = 3,
                                   Username = "manh",
                                   Password = "$2a$10$Jil6WdJRhv8MYNqBwMbc7u445ywywJ2fyddH1SMJ5rrf3KL/cmjEK",
                                   Role = Role.User,
                                   Name = "Nguyen Dinh Manh",
                                   Email = "",
                                   GithubUsername = "johndoe",
                                   DateOfBirth = DateTime.UtcNow,
                                   PhoneNumber = "1234567890",
                                   IsActive = true,
                                   CreatedDate = DateTime.UtcNow,
                                   ModifiedDate = DateTime.UtcNow
                               });
        }
    }
}
