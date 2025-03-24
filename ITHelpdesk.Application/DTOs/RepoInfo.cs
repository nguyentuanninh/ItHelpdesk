using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.DTOs
{
    public class Owner
    {
        public string Login { get; set; }
        public string Avatar_url { get; set; }
    }

    public class RepoInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Owner Owner { get; set; }
        public string Html_url { get; set; }
        public int Stargazers_count { get; set; }
        public int Forks_count { get; set; }
    }
}
