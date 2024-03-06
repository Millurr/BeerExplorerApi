using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeerExplorerApi.Models;
public class Beer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string BeerName { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal AlcoholContent { get; set; }
    public string Category { get; set; } = null!;
}