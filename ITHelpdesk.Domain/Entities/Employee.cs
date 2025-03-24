using ITHelpdesk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; } = Role.User;
        public string Name { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string GithubUsername { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
