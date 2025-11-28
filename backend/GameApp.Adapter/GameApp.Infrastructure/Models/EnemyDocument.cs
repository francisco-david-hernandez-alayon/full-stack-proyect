using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Adapter.Infrastructure.Models;

public class EnemyDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int HealthPoints { get; set; }
    public int DamageAttack { get; set; }
    public int SpeedAttack { get; set; }
    public int MoneyReward { get; set; }
}
