using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.DTOs
{
    public class LLMResponse
    {
        public string Action { get; set; }
        public string? RepoName { get; set; }
        public string? GithubUsername { get; set; }
        public string? Permission { get; set; }
        public int? EmployeeId { get; set; }
    }
}
