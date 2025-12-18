using GameApp.Adapter.Api.dtos.ItemsDto;
using GameApp.Application.Enumerates;

namespace GameApp.Adapter.Api.dtos.OthersDto;

public class CharacterResponseDto
{
    public CharacterType Type { get; set; } = default!; 

    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }
    public List<ItemResponseDto> InventoryList { get; set; } = new();
}