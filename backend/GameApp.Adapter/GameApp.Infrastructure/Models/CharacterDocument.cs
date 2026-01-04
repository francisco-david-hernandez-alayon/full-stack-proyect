using GameApp.Application.Enumerates;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Adapter.Infrastructure.Models;

public class CharacterDocument
{
    public CharacterType Type { get; set; }
    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }
    public List<InventoryItemDocument> InventoryList { get; set; } = new();

    // Optional Character habilities
    [BsonIgnoreIfNull]
    public int? CurrentHits { get; set; }
}
