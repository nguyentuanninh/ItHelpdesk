using ITHelpdesk.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Service
{
    public class OllamaService : IOllamaService
    {
        private readonly HttpClient _httpClient;
        private const string MODEL_NAME = "llama2";

        public OllamaService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OllamaClient");
        }

        public async Task<string> SendPromptAsync(string prompt)
        {
            var requestBody = new
            {
                model = MODEL_NAME,
                prompt = prompt,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync("/api/generate", requestBody);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(responseContent);
            var responseElement = document.RootElement;

            var generatedText = responseElement.GetProperty("response").GetString();

            return generatedText ?? string.Empty;
        }
    }
}
