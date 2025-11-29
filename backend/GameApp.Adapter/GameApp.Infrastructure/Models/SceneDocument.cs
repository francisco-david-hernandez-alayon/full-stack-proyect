using GameApp.Domain.Enumerates;
using GameApp.Adapter.Infrastructure.Enumerates;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.Models;

public class SceneDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; }
    public SceneType SceneType { get; set; }


    [BsonIgnoreIfNull]
    public string? Enemy { get; set; }
    [BsonIgnoreIfNull]
    public int? EnemyHealthPoints { get; set; }

    [BsonIgnoreIfNull]
    public List<SceneDocument>? PossibleScenes { get; set; }

    [BsonIgnoreIfNull]
    public string? RewardItem { get; set; }
    [BsonIgnoreIfNull]
    public int? AttackItemDurability { get; set;  }

    [BsonIgnoreIfNull]
    public List<ItemDocument>? CharacterItemsOffer { get; set; }

    [BsonIgnoreIfNull]
    public int? CharacterMoneyOffer { get; set; }

    [BsonIgnoreIfNull]
    public List<ItemDocument>? MerchantItemsOffer { get; set; }

    [BsonIgnoreIfNull]
    public int? MerchantMoneyOffer { get; set; }
}
