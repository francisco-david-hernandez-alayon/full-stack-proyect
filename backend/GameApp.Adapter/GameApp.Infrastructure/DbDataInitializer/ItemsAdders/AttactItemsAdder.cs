using GameApp.Domain.Entities.Items;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AttackItemsAdders : IItemsAdder
{
    public static readonly AttackItem WoodSword = new(
        ItemRarity.Common,
        new ItemName("wood sword"),
        new ItemDescription("A simple wood sword"),
        tradePrice: 10,
        attackDamage: 10,
        speedAttack: 2,
        durability: 5
    );

    public static readonly AttackItem IronSword = new(
        ItemRarity.Rare,
        new ItemName("iron sword"),
        new ItemDescription("A basic iron sword"),
        tradePrice: 20,
        attackDamage: 20,
        speedAttack: 3,
        durability: 10
    );

    public static readonly AttackItem Dagger = new(
        ItemRarity.Rare,
        new ItemName("dagger"),
        new ItemDescription("A small, fast dagger"),
        tradePrice: 15,
        attackDamage: 15,
        speedAttack: 4,
        durability: 8
    );

    public static readonly AttackItem SteelAxe = new(
        ItemRarity.Epic,
        new ItemName("steel axe"),
        new ItemDescription("A heavy steel axe"),
        tradePrice: 25,
        attackDamage: 25,
        speedAttack: 1,
        durability: 12
    );



    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { WoodSword, IronSword, SteelAxe, Dagger });
    }
}
