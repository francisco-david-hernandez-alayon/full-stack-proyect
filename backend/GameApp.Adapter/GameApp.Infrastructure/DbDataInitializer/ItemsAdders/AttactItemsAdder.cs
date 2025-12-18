using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AttackItemsAdders : IItemsAdder
{
    public static readonly AttackItem WoodSword = new(
        new ItemName("wood sword"),
        new ItemDescription("A simple wood sword"),
        tradePrice: 10,
        attackDamage: 5,
        speedAttack: 3,
        durability: 5
    );

    public static readonly AttackItem IronSword = new(
        new ItemName("iron sword"),
        new ItemDescription("A basic iron sword"),
        tradePrice: 20,
        attackDamage: 10,
        speedAttack: 4,
        durability: 15
    );

    public static readonly AttackItem SteelAxe = new(
        new ItemName("steel axe"),
        new ItemDescription("A heavy steel axe"),
        tradePrice: 25,
        attackDamage: 12,
        speedAttack: 2,
        durability: 20
    );

    public static readonly AttackItem Dagger = new(
        new ItemName("dagger"),
        new ItemDescription("A small, fast dagger"),
        tradePrice: 15,
        attackDamage: 4,
        speedAttack: 6,
        durability: 8
    );

    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { WoodSword, IronSword, SteelAxe, Dagger });
    }
}
