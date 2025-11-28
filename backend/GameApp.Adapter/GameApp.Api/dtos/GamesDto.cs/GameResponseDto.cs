using GameApp.Adapter.Api.dtos.EnemysDtos;
using GameApp.Adapter.Api.dtos.OthersDto;
using GameApp.Adapter.Api.dtos.ScenesDto;
using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Api.dtos.GamesDto;

public class GameResponseDto
{
    public Guid Id { get; set; }

    public CharacterDto Character { get; set; } = default!;

    public int NumberScenesToFinish { get; set; }

    public List<SceneResponseDto> ListCompletedScenes { get; set; } = new();

    public List<SceneResponseDto> ListCurrentScenes { get; set; } = new();

    public List<UserAction> ListCurrentUserActions { get; set; } = new();

    public FinalSceneDto FinalScene { get; set; } = default!;

    public EnemyDto? CurrentEnemy { get; set; }
}
