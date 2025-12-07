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
    public List<string> CompletedScenes { get; set; } = new();

    public List<string> CurrentScenes { get; set; } = new();

    public List<UserAction> CurrentUserActions { get; set; } = new();
    
    public string FinalScene { get; set; } = default!;

    public GameStatus Status { get; set; }

    [BsonIgnoreIfNull]
    public EnemyDocument? CurrentEnemy { get; set; }
    [BsonIgnoreIfNull]
    public int? EnemyHealthPoints { get; set; }
}
