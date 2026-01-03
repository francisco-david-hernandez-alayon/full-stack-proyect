using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


// Specific class for item that affect to atributes
public class AtributeItem : Item
{
    private readonly int HealthPointsReceived;
    private readonly int FoodPointsReceived;



    // Default constructor
    public AtributeItem(ItemRarity rarity, ItemName name, ItemDescription description, int tradePrice,  int healthPointsReceived, int foodPointsReceived)
        : base(rarity, name, description, tradePrice)
    {
        HealthPointsReceived = healthPointsReceived;
        FoodPointsReceived = foodPointsReceived;
    }

    // Restore constructor
    public AtributeItem(Guid id, ItemRarity rarity, ItemName name, ItemDescription description, int tradePrice,  int healthPointsReceived, int foodPointsReceived)
        : base(id, rarity, name, description, tradePrice)
    {
        HealthPointsReceived = healthPointsReceived;
        FoodPointsReceived = foodPointsReceived;
    }

    // getters
    public int GetHealthPointsReceived() => HealthPointsReceived;

    public int GetFoodPointsReceived() => FoodPointsReceived;

    // setters
    public AtributeItem SetHealthPointsReceived(int newHealthPointsReceived) => new AtributeItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetTradePrice(), newHealthPointsReceived, GetFoodPointsReceived()); 

    public AtributeItem SetFoodPointsReceived(int newFoodPointsReceived) => new AtributeItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetTradePrice(), GetHealthPointsReceived(), newFoodPointsReceived); 

    public AtributeItem SetTradePrice(int newTradePrice) => new AtributeItem(GetGuid(), GetRarity(), GetName(), GetDescription(), newTradePrice, GetHealthPointsReceived(), GetFoodPointsReceived()); 

    // To string
    public override string ToString()
    {
        return $"{GetName()} atribute item({GetGuid()}, Difficulty {GetRarity()}): " + $"HealthPointsReceived={HealthPointsReceived}, FoodPointsReceived={FoodPointsReceived}, TradePrice={GetTradePrice()}";
    }
}