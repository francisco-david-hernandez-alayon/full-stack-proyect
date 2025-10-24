namespace GameApp.Api.dtos;

public class GameResponseDto
{
    public Guid Id { get; set; }

    public CharacterDto Character { get; set; } = default!;

    public int NumberScenesToFinish { get; set; }

    public List<SceneDto> CompletedScenes { get; set; } = new();

    public FinalSceneDto FinalScene { get; set; } = default!;
}
