using GameApp.Api.Enumerates;

namespace GameApp.Api.dtos;

public class GameCreateRequestDto
{
    public CharacterType Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public FinalSceneDto FinalScene { get; set; } = default!;
    public List<SceneDto> ListCurrentScenes { get; set; } = new();
}