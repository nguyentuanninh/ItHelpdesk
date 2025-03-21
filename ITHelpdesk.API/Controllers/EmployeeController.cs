using ITHelpdesk.Application.DTOs;
using ITHelpdesk.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ITHelpdesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        protected ApiResponse _response;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            _response.Result = employees;
            return Ok(_response);
        }

        [HttpPost("{id}/github-collaborator")]
        public async Task<IActionResult> AddCollabToRepo(int id, [FromBody] string repoName)
        {
            var result = await _employeeService.AddEmployeeAsCollaboratorAsync(id, repoName);
            if (!result)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { "Could not add collaborator for this employee" };
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
