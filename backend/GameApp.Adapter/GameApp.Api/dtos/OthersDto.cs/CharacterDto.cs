using System.Text.Json.Serialization;
using GameApp.Adapter.Api.dtos.ItemsDto;
using GameApp.Application.Enumerates;

namespace GameApp.Adapter.Api.dtos.OthersDto;

public class CharacterDto
{
    public CharacterType Type { get; set; } = default!; 

    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }
    public List<ItemResponseDto> InventoryList { get; set; } = new();


    // Optional Character habilities
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CurrentHits { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CurrentKills { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CurrentNothingHappensScenes { get; set; }
}