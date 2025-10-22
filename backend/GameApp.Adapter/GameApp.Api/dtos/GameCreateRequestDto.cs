namespace GameApp.Api.dtos;

public class GameCreateRequestDto
{
    public CharacterDto Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public FinalSceneDto FinalScene { get; set; } = default!;
}