using ITHelpdesk.Application.DTOs;
using ITHelpdesk.Application.DTOs.Authen;
using ITHelpdesk.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ITHelpdesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ApiResponse _response;

        public AuthController(IAuthService authService)
        {
            _response = new ApiResponse();
            _authService = authService;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);

            if (loginResponse.Id == -1) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Account is disable");
                return BadRequest(_response);
            }

            if (loginResponse.Id == 0 || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Account or password not correct");
                return BadRequest(_response);
            }

            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto model)
        {
            var registerResponse = await _authService.Register(model);

            if (!registerResponse)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error when register");
                return BadRequest(_response);
            }

            _response.Result = registerResponse;
            return Ok(_response);
        }
    }
}
