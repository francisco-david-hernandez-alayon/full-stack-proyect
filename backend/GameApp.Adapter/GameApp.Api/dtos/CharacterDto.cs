using GameApp.Api.Enumerates;

namespace GameApp.Api.dtos;

public class CharacterDto
{
    public CharacterType Type { get; set; } = default!; 

    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }
    public List<ItemDto> InventoryList { get; set; } = new();
}