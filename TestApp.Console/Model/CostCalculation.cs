using System.Text.Json.Serialization;

namespace TestApp.Console.Model;

public record CostCalculation
{
    [JsonPropertyName("operation")]
    public required string Operation { get; set; }

    [JsonPropertyName("charactersIn")]
    public long CharactersIn { get; set; }

    [JsonPropertyName("charactersOut")]
    public long? CharactersOut { get; set; }

    [JsonPropertyName("totalCharacters")]
    public long TotalCharacters { get; set; }

    [JsonPropertyName("charactersPerPage")]
    public long CharactersPerPage { get; set; }

    [JsonPropertyName("pages")]
    public long Pages { get; set; }

    [JsonPropertyName("pageCost")]
    public long PageCost { get; set; }

    [JsonPropertyName("totalCost")]
    public long TotalCost { get; set; }
}