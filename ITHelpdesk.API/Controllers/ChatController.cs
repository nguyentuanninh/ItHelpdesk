using ITHelpdesk.Application.DTOs;
using ITHelpdesk.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITHelpdesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IOllamaService _ollamaService;
        private readonly ApiResponse _response;

        public ChatController(IOllamaService ollamaService)
        {
            _ollamaService = ollamaService;
            _response = new ApiResponse();
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] string userPrompt)
        {
            var response = await _ollamaService.SendPromptAsync(userPrompt);

            return Ok(new { llmResponse = response });
        }
    }
}
