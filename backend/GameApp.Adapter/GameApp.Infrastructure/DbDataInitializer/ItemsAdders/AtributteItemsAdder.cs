using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AtributteItemsAdders : IItemsAdder
{
    public static readonly AtributeItem HealthPotion = new(
        new ItemName("health potion"),
        new ItemDescription("A health potion"),
        tradePrice: 8,
        healthPointsReceived: 50,
        foodPointsReceived: 0
    );

    public static readonly AtributeItem Bread = new(
        new ItemName("bread"),
        new ItemDescription("A simple bread to eat"),
        tradePrice: 3,
        healthPointsReceived: 0,
        foodPointsReceived: 40
    );

    public static readonly AtributeItem CheeseCake = new(
        new ItemName("CheeseCake"),
        new ItemDescription("A nutritious cheesecake"),
        tradePrice: 5,
        healthPointsReceived: 5,
        foodPointsReceived: 50
    );

    public static readonly AtributeItem Apple = new(
        new ItemName("apple"),
        new ItemDescription("A nutritious apple"),
        tradePrice: 4,
        healthPointsReceived: 10,
        foodPointsReceived: 30
    );

    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { Bread, HealthPotion, CheeseCake, Apple });
    }
}
