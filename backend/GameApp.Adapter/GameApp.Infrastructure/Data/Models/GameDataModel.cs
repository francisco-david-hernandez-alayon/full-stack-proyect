namespace GameApp.Infrastructure.Data.Models;

public class GameDataModel
{
    public Guid Id { get; set; }
    public string CharacterJson { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public string CompletedScenesJson { get; set; } = default!;
    public string FinalSceneJson { get; set; } = default!;
}
