using GameApp.Api.Enumerates;
using GameApp.Domain.Enumerates;

namespace GameApp.Api.dtos;

public class GameCreateRequestDto
{
    public CharacterType Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public FinalSceneDto FinalScene { get; set; } = default!;
    public List<SceneResponseDto> ListCurrentScenes { get; set; } = new();

    public List<UserAction> ListCurrentUserActions { get; set; } = new();
}