using ITHelpdesk.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IOllamaService _ollamaService;

        public ChatHub(IOllamaService ollamaService)
        {
            _ollamaService = ollamaService;
        }

        public async Task SendMessage(string userName, string prompt)
        {

            var llmResponse = await _ollamaService.SendPromptAsync(prompt);

            await Clients.All.SendAsync("ReceiveMessage", new
            {
                User = userName,
                Prompt = prompt,
                Reply = llmResponse
            });
        }
    }
}
