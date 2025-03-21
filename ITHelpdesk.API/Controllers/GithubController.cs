using ITHelpdesk.Application.DTOs;
using ITHelpdesk.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ITHelpdesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGithubService _githubService;
        protected ApiResponse _response;

        public GithubController(IGithubService githubService)
        {
            _githubService = githubService;
            _response = new ApiResponse();
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchRepo([FromQuery] string? keyword)
        {
            var matchedRepos = await _githubService.SearchRepositoriesByNameAsync(keyword);
            _response.Result = matchedRepos;
            return Ok(_response);
        }


        [HttpPost("add-collaborator")]
        public async Task<IActionResult> AddCollaborator([FromQuery] string repoName,
                                                         [FromQuery] string collaborator,
                                                         [FromQuery] string permission = "push")
        {
            var success = await _githubService.AddCollaboratorAsync(repoName, collaborator, permission);
            if (!success)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { "Failed to add collaborator." };
                return BadRequest(_response);
            }
            return Ok("Collaborator added successfully!");
        }
    }
}
