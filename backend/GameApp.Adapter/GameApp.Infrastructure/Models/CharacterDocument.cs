using GameApp.Infrastructure.Enumerates;

namespace GameApp.Infrastructure.Models;

public class CharacterDocument
{
    public CharacterType Type { get; set; }
    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }
    public List<ItemDocument> InventoryList { get; set; } = new();
}
