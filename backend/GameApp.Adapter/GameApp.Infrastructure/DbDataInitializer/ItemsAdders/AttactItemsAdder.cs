using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AttackItemsAdders : IItemsAdder
{
    private static readonly AttackItem _woodSword = new(
        new ItemName("wood sword"),
        new ItemDescription("A simple wood sword"),
        tradePrice: 10,
        attackDamage: 5,
        speedAttack: 3,
        durability: 5
    );

    private static readonly AttackItem _ironSword = new(
        new ItemName("iron sword"),
        new ItemDescription("A basic iron sword"),
        tradePrice: 20,
        attackDamage: 10,
        speedAttack: 4,
        durability: 15
    );

    private static readonly AttackItem _steelAxe = new(
        new ItemName("steel axe"),
        new ItemDescription("A heavy steel axe"),
        tradePrice: 25,
        attackDamage: 12,
        speedAttack: 2,
        durability: 20
    );

    private static readonly AttackItem _dagger = new(
        new ItemName("dagger"),
        new ItemDescription("A small, fast dagger"),
        tradePrice: 15,
        attackDamage: 4,
        speedAttack: 6,
        durability: 8
    );

    // Getters
    public static AttackItem WoodSword => _woodSword;
    public static AttackItem IronSword => _ironSword;
    public static AttackItem SteelAxe => _steelAxe;
    public static AttackItem Dagger => _dagger;

    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { _woodSword, _ironSword, _steelAxe, _dagger });
    }
}
