using GameApp.Domain.Enumerates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Adapter.Infrastructure.Models;

public class GameDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public CharacterDocument Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public List<ItemSceneListDocument> CompletedScenes { get; set; } = new();

    public List<ItemSceneListDocument> CurrentScenes { get; set; } = new();

    public List<UserAction> CurrentUserActions { get; set; } = new();
    
    public string FinalScene { get; set; } = default!;

    public GameStatus Status { get; set; }

    // TradeScene


    // Current enemy
    [BsonIgnoreIfNull]
    public string? CurrentEnemyName { get; set; }
    [BsonIgnoreIfNull]
    public int? CurrentEnemyHealthPoints { get; set; }

}
