using System.Text.Json.Serialization;

namespace Domain.Models;

public class BooksDTO
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("cover")]
    public string? Cover { get; set; }

}