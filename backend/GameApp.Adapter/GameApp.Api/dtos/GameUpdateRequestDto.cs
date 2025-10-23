namespace GameApp.Api.dtos;

public class GameUpdateRequestDto
{
    public CharacterDto Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public FinalSceneDto FinalScene { get; set; } = default!;
    public List<SceneDto> ListCompletedScenes { get; private set; } = new();
}