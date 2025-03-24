using ITHelpdesk.Application.DTOs;
using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Domain.SD;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Service
{
    public class GithubService : IGithubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _personalAccessToken;
        private readonly string _adminGitHubUser;

        public GithubService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _personalAccessToken = config["Github:Token"];
            _adminGitHubUser = config["Github:AdminUser"];
        }


        public async Task<List<RepoInfo>> SearchRepositoriesByNameAsync(string? searchText)
        {
            var client = _httpClientFactory.CreateClient("GitHubClient");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _personalAccessToken);


            var response = await client.GetAsync("user/repos?per_page=100");
            if (!response.IsSuccessStatusCode) return new List<RepoInfo>();

            var json = await response.Content.ReadAsStringAsync();

            var repoList = JsonSerializer.Deserialize<List<RepoInfo>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<RepoInfo>();

            // Fillter repo by searchText
            var matchedRepos = new List<RepoInfo>();
            foreach (var repo in repoList)
            {
                if (searchText== null || repo.Name != null && repo.Name.ToLower().Contains(searchText.ToLower()))
                {
                    matchedRepos.Add(repo);
                }
            }

            return matchedRepos;
        }


        public async Task<bool> AddCollaboratorAsync(
            string repoName,
            string collaboratorUsername,
            string permission = GithubPermission.PUSH)
        {
            var client = _httpClientFactory.CreateClient("GitHubClient");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _personalAccessToken);

            var body = new { permission = permission };
            var content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json");

            var url = $"repos/{_adminGitHubUser}/{repoName}/collaborators/{collaboratorUsername}";
            var response = await client.PutAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }


}
