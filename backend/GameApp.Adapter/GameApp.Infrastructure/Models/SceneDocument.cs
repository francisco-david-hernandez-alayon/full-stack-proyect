using GameApp.Domain.Enumerates;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Application.Enumerates;

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

    // EnemyScene
    [BsonIgnoreIfNull]
    public string? Enemy { get; set; }

    // ItemScene
    [BsonIgnoreIfNull]
    public string? RewardItem { get; set; }

    // TradeScene
    [BsonIgnoreIfNull]
    public int? MerchantMoneyToSpent { get; set; }

    [BsonIgnoreIfNull]
    public List<ItemDocument>? MerchantItemsOffer { get; set; }

    [BsonIgnoreIfNull]
    public int? ProfitMerchantMargin { get; set; }

}
