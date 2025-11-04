using GameApp.Domain.Enumerates;
using GameApp.Infrastructure.Enumerates;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Infrastructure.Models;

public class SceneDocument
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; }
    public SceneType SceneType { get; set; }


    [BsonIgnoreIfNull]
    public EnemyDocument? Enemy { get; set; }

    [BsonIgnoreIfNull]
    public List<SceneDocument>? PossibleScenes { get; set; }

    [BsonIgnoreIfNull]
    public ItemDocument? RewardItem { get; set; }

    [BsonIgnoreIfNull]
    public List<ItemDocument>? CharacterItemsOffer { get; set; }

    [BsonIgnoreIfNull]
    public int? CharacterMoneyOffer { get; set; }

    [BsonIgnoreIfNull]
    public List<ItemDocument>? MerchantItemsOffer { get; set; }

    [BsonIgnoreIfNull]
    public int? MerchantMoneyOffer { get; set; }
}
