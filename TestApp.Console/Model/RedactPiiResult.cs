using System.Text.Json.Serialization;

namespace TestApp.Console.Model;

public record RedactPiiResult
{
    [JsonPropertyName("costCalculation")]
    public required CostCalculation CostCalculation { get; set; }

    [JsonPropertyName("text")]
    public required string Text { get; set; }
}