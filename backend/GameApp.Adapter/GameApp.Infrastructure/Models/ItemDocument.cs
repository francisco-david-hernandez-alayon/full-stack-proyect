using GameApp.Infrastructure.Enumerates;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Infrastructure.Models;

public class ItemDocument
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ItemType ItemType { get; set; }


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
