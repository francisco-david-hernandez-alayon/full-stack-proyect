using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using GameApp.Application.Enumerates;
using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Infrastructure.Models;

public class ItemDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public ItemRarity Rarity { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ItemType ItemType { get; set; }
    public int TradePrice { get; set; } = 0;


    [BsonIgnoreIfNull]
    public int? HealthPointsReceived { get; set; }

    [BsonIgnoreIfNull]
    public int? FoodPointsReceived { get; set; }

    [BsonIgnoreIfNull]
    public int? AttackDamage { get; set; }

    [BsonIgnoreIfNull]
    public int? SpeedAttack { get; set; }

    [BsonIgnoreIfNull]
    public int? Durability { get; set; }
}
