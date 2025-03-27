namespace TestApp.Console.Model;

public record AppSettings
{
    public required string ClientId { get; set; }

    public required string ClientSecret { get; set; }

    public required string UserAgent { get; set; }

    public required string ApiEndpoint { get; set; }
}