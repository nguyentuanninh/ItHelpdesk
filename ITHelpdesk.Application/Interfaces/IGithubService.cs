using ITHelpdesk.Application.DTOs;
using ITHelpdesk.Domain.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Interfaces
{
    public interface IGithubService
    {
        Task<List<RepoInfo>> SearchRepositoriesByNameAsync(string? searchText);
        Task<bool> AddCollaboratorAsync(string repoName, string collaboratorUsername, string permission = GithubPermission.PUSH);
    }
}
