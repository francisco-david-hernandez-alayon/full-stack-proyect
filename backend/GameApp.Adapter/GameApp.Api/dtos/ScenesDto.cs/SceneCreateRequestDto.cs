using System.Text.Json.Serialization;
using GameApp.Adapter.Api.dtos.EnemysDtos;
using GameApp.Adapter.Api.dtos.ItemsDto;
using GameApp.Adapter.Api.dtos.OthersDto;
using GameApp.Adapter.Api.Enumerates;
using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Api.dtos.ScenesDto;

public class SceneCreateRequestDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; } = default!;
    public SceneType SceneType { get; set; }

    // optional depending on the type of scene:

    // EnemyScene
    public EnemyResponseDto? Enemy { get; set; } 

    // EnterDungeonScene
    public List<SceneResponseDto>? PossibleScenes { get; set; } 

    // ItemScene
    public ItemResponseDto? RewardItem { get; set; } 

    // TradeScene
    public List<ItemResponseDto>? CharacterItemsOffer { get; set; }
    public int? CharacterMoneyOffer { get; set; }
    public List<ItemResponseDto>? MerchantItemsOffer { get; set; }
    public int? MerchantMoneyOffer { get; set; }
}
