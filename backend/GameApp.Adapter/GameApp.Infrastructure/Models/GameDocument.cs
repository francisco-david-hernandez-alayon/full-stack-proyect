using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApp.Infrastructure.Models;

public class GameDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public CharacterDocument Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public List<SceneDocument> CompletedScenes { get; set; } = new();

    public List<SceneDocument> CurrentScenes { get; set; } = new();
    public FinalSceneDocument FinalScene { get; set; } = default!;
}
