using GameApp.Adapter.Infrastructure.Enumerates;

namespace GameApp.Adapter.Infrastructure.Models;

public class CharacterDocument
{
    public CharacterType Type { get; set; }
    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }
    public List<InventoryItemDocument> InventoryList { get; set; } = new();
}
