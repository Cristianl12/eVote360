using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace eVote360.Application.Services
{
    public class OcrService
    {
        private readonly HttpClient _httpClient;

        public OcrService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string?> LeerTextoAsync(Stream imagen)
        {
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(imagen), "file", "document.jpg");
            content.Add(new StringContent("helloworld"), "apikey"); // Clave pública gratuita
            content.Add(new StringContent("spa"), "language");      // Español

            var response = await _httpClient.PostAsync("https://api.ocr.space/parse/image", content);
            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            var text = doc.RootElement
                .GetProperty("ParsedResults")[0]
                .GetProperty("ParsedText")
                .GetString();

            return text;
        }
    }
}

