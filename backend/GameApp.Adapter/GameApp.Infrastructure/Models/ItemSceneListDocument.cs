using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Adapter.Infrastructure.Models;

public class ItemSceneListDocument
{
    public string SceneName { get; set; } = default!;

    [BsonIgnoreIfNull]
    public int? tradeSceneMerchantMoneyToSpent { get; set; }
}
