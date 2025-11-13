using GameApp.Api.Enumerates;
using GameApp.Domain.Enumerates;

namespace GameApp.Api.dtos;

public class SceneCreateRequestDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; } = default!;
    public SceneType SceneType { get; set; }

    // optional depending on the type of scene:

    // EnemyScene
    public EnemyDto? Enemy { get; set; } 

    // EnterDungeonScene
    public List<SceneResponseDto>? PossibleScenes { get; set; } 

    // ItemScene
    public ItemDto? RewardItem { get; set; } 

    // TradeScene
    public List<ItemDto>? CharacterItemsOffer { get; set; }
    public int? CharacterMoneyOffer { get; set; }
    public List<ItemDto>? MerchantItemsOffer { get; set; }
    public int? MerchantMoneyOffer { get; set; }
}
