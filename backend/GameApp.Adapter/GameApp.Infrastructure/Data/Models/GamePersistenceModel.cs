namespace GameApp.Infrastructure.Data.Models;

public class GamePersistenceModel
{
    public Guid Id { get; set; }

    public Guid CharacterId { get; set; } // FK
    public CharacterPersistenceModel Character { get; set; } = default!;

    public int NumberScenesToFinish { get; set; }

    public List<ScenePersistenceModel> CompletedScenes { get; set; } = new();

    public Guid FinalSceneId { get; set; } // FK
    public FinalScenePersistenceModel FinalScene { get; set; } = default!;
}
