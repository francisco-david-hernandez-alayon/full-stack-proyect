using System.Text.Json.Serialization;
using GameApp.Adapter.Api.dtos.EnemysDtos;
using GameApp.Adapter.Api.dtos.ItemsDto;
using GameApp.Adapter.Api.dtos.OthersDto;
using GameApp.Adapter.Api.Enumerates;
using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Api.dtos.ScenesDto;

public class SceneResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; } = default!;
    public SceneType SceneType { get; set; }

    // optional depending on the type of scene:

    // EnemyScene
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EnemyResponseDto? Enemy { get; set; }

    // ItemScene
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ItemResponseDto? RewardItem { get; set; }

    // TradeScene
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ItemResponseDto>? MerchantItemsOffer { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MerchantMoneyToSpent { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ProfitMerchantMargin { get; set; }

}
