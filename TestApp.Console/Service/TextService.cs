using System.Text.Json;
using TestApp.Console.Interface.Service;
using TestApp.Console.Model;

namespace TestApp.Console.Service;

public class TextService(AppSettings appSettings) : ITextService
{
    public async Task<string> RedactPii(Exception ex)
    {
        // create a base64 encoded api key
        var apiKeyText = $"{appSettings.ClientId}:{appSettings.ClientSecret}";
        var apiKey = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(apiKeyText));

        // use the api key as the basic token
        var authorization = $"Basic {apiKey}";

        // populate endpoint paramaters
        var sourceLanguage = "en";
        var minimumScore = 0.75;

        dynamic requestBody = new
        {
            text = ex.ToString(),
            language = sourceLanguage,
            minimumScore
        };

        var requestBodyJson = JsonSerializer.Serialize(requestBody);

        // invoke the api endpoint
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, appSettings.ApiEndpoint);
        request.Headers.Add("Authorization", authorization);
        request.Headers.Add("User-Agent", appSettings.UserAgent);
        var content = new StringContent(requestBodyJson, null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseJson = await response.Content.ReadAsStringAsync();
        var redactPiiResult = JsonSerializer.Deserialize<RedactPiiResult>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return redactPiiResult!.Text;
    }
}