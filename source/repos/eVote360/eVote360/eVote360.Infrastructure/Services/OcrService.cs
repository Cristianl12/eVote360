using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace eVote360.Infrastructure.Services
{
    public class OcrService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OcrService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["Ocr:ApiKey"] ?? "helloworld";
        }

        public async Task<string?> LeerTextoAsync(Stream imagen)
        {
            try
            {
                using var content = new MultipartFormDataContent();
                content.Add(new StreamContent(imagen), "file", "document.jpg");
                content.Add(new StringContent(_apiKey), "apikey");
                content.Add(new StringContent("spa"), "language");

                var response = await _httpClient.PostAsync("https://api.ocr.space/parse/image", content);
                
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(json);
                var text = doc.RootElement
                    .GetProperty("ParsedResults")[0]
                    .GetProperty("ParsedText")
                    .GetString();

                return text;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
