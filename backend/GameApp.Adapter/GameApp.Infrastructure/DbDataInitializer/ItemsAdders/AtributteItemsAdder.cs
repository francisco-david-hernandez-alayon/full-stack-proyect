using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AtributteItemsAdders : IItemsAdder
{

    public static readonly AtributeItem HealthPotion = new(
        new ItemName("health potion"),
        new ItemDescription("A health potion"),
        tradePrice: 10,
        healthPointsReceived: 20,
        foodPointsReceived: 0
    );

    public static readonly AtributeItem Bread = new(
        new ItemName("bread"),
        new ItemDescription("A simple bread to eat"),
        tradePrice: 2,
        healthPointsReceived: 0,
        foodPointsReceived: 3
    );

    public static readonly AtributeItem Apple = new(
        new ItemName("apple"),
        new ItemDescription("A nutritious apple"),
        tradePrice: 4,
        healthPointsReceived: 1,
        foodPointsReceived: 5
    );

    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { Bread, HealthPotion, Apple });
    }
}
