using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


public abstract class Item
{
    private readonly Guid Id;
    private readonly ItemRarity Rarity;
    private readonly ItemName Name;
    private readonly ItemDescription Description;
    private readonly int TradePrice;

    // Default constructor
    protected Item(ItemRarity rarity, ItemName name, ItemDescription description, int tradePrice)
    {
        Id = Guid.NewGuid();
        Rarity = rarity;
        Name = name;
        Description = description;
        TradePrice = tradePrice;
    }

    // Restore Constructor
    protected Item(Guid id, ItemRarity rarity, ItemName name, ItemDescription description, int tradePrice)
    {
        Id = id;
        Rarity = rarity;
        Name = name;
        Description = description;
        TradePrice = tradePrice;
    }

    public Guid GetGuid() => Id;
    public ItemName GetName() => Name;
    public ItemDescription GetDescription() => Description;
    public int GetTradePrice() => TradePrice;
    public ItemRarity GetRarity() => Rarity;

}