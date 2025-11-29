using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


public abstract class Item
{
    private readonly Guid Id;
    private readonly ItemName Name;
    private readonly ItemDescription Description;
    private readonly int TradePrice;

    // Default constructor
    protected Item(ItemName name, ItemDescription description, int tradePrice)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        TradePrice = tradePrice;
    }

    // Restore Constructor
    protected Item(Guid id, ItemName name, ItemDescription description, int tradePrice)
    {
        Id = id;
        Name = name;
        Description = description;
        TradePrice = tradePrice;
    }

    public Guid GetGuid() => Id;
    public ItemName GetName() => Name;
    public ItemDescription GetDescription() => Description;
    public int GetTradePrice() => TradePrice;

}