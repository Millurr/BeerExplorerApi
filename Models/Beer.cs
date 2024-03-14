using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerExplorerApi.Models;
public class Beer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("name")]
    public string BeerName { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("alcoholContent")]
    public decimal AlcoholContent { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = null!;
}