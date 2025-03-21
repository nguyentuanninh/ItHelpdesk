using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Interfaces
{
    public interface IOllamaService
    {
        Task<string> SendPromptAsync(string prompt);
    }
}
