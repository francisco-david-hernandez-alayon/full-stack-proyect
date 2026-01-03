using GameApp.Adapter.Api.dtos.ScenesDto;
using GameApp.Application.Enumerates;
using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Api.dtos.GamesDto;

public class GameCreateRequestDto
{
    public GameDifficulty Difficulty { get; set; }
    public CharacterType Character { get; set; } = default!;
    public int NumberScenesToFinish { get; set; }
    public FinalSceneDto FinalScene { get; set; } = default!;
    public List<SceneResponseDto> ListCurrentScenes { get; set; } = new();

    public List<UserAction> ListCurrentUserActions { get; set; } = new();
}