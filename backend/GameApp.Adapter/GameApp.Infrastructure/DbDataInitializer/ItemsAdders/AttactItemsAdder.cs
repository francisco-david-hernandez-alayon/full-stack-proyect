using GameApp.Domain.Entities.Items;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Combat;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AttackItemsAdders : IItemsAdder
{
    // COMMON
    public static readonly AttackItem WoodenStick = new(
        ItemRarity.Common,
        new ItemName("Wooden stick"),
        new ItemDescription("A simple, sturdy stick used as a weapon in a pinch. Lightweight but not very powerful in combat."),
        tradePrice: 1,
        attackDamage: 5,
        speedAttack: 0,
        durability: 5,
        new CriticalDamage(criticalProbability: 5, extraDamage: 5)
    );

    public static readonly AttackItem SharpStone = new(
        ItemRarity.Common,
        new ItemName("Sharp stone"),
        new ItemDescription("A jagged stone sharpened for quick strikes. Very fast to wield, but fragile and wears down easily in combat."),
        tradePrice: 3,
        attackDamage: 10,
        speedAttack: 3,
        durability: 5,
        new CriticalDamage(criticalProbability: 5, extraDamage: 15)
    );

    public static readonly AttackItem WoodenBludgeon = new(
        ItemRarity.Common,
        new ItemName("Wooden Bludgeon"),
        new ItemDescription("A simple wooden bludgeon that delivers heavy, crushing blows. Slow and fragile, it can break easily in prolonged combat."),
        tradePrice: 4,
        attackDamage: 20,
        speedAttack: 0,
        durability: 4,
        new CriticalDamage(criticalProbability: 5, extraDamage: 10)
    );

    public static readonly AttackItem OldStoneSword = new(
        ItemRarity.Common,
        new ItemName("Old Stone Sword"),
        new ItemDescription("A worn sword, whose blade is carved from solid stone. Capable of giving battle despite its age."),
        tradePrice: 5,
        attackDamage: 7,
        speedAttack: 2,
        durability: 7,
        new CriticalDamage(criticalProbability: 10, extraDamage: 5)
    );

    public static readonly AttackItem StoneAxe = new(
        ItemRarity.Common,
        new ItemName("Stone axe"),
        new ItemDescription("A rugged stone axe, primarily used for chopping wood but effective in battle."),
        tradePrice: 5,
        attackDamage: 10,
        speedAttack: 1,
        durability: 8,
        new CriticalDamage(criticalProbability: 5, extraDamage: 5)
    );

    

    // RARE
    public static readonly AttackItem KnightSword = new(
        ItemRarity.Rare,
        new ItemName("Knight sword"),
        new ItemDescription("The standard sword wielded by the kingdom's knights. Well-balanced for both offense and defense, reliable in the hands of trained warriors."),
        tradePrice: 10,
        attackDamage: 10,
        speedAttack: 2,
        durability: 12,
        new CriticalDamage(criticalProbability: 5, extraDamage: 5)
    );

    public static readonly AttackItem IronDaggers = new(
        ItemRarity.Rare,
        new ItemName("Iron daggers"),
        new ItemDescription("Two finely forged iron daggers, light and deadly in expert hands. Extremely fast, ideal for quick and critical strikes."),
        tradePrice: 14,
        attackDamage: 15,
        speedAttack: 4,
        durability: 10,
        new CriticalDamage(criticalProbability: 15, extraDamage: 10)
    );

    public static readonly AttackItem IronSpear = new(
        ItemRarity.Rare,
        new ItemName("Iron Spear"),
        new ItemDescription("A long iron spear designed for powerful thrusts. Heavy and slow, it deals solid damage but offers little precision for critical strikes."),
        tradePrice: 15,
        attackDamage: 22,
        speedAttack: 1,
        durability: 12,
        new CriticalDamage(criticalProbability: 5, extraDamage: 3)
    );

    public static readonly AttackItem BlacksmithsHammer = new(
        ItemRarity.Rare,
        new ItemName("Blacksmith's Hammer"),
        new ItemDescription("A heavy, expertly forged hammer built for durability. Highly reliable, it can endure repeated strikes without breaking."),
        tradePrice: 20,
        attackDamage: 12,
        speedAttack: 0,
        durability: 15,
        new CriticalDamage(criticalProbability: 5, extraDamage: 5)
    );

    public static readonly AttackItem Mace = new(
        ItemRarity.Rare,
        new ItemName("Mace"),
        new ItemDescription("A heavily reinforced mace full of spikes"),
        tradePrice: 22,
        attackDamage: 30,
        speedAttack: 0,
        durability: 7,
        new CriticalDamage(criticalProbability: 15, extraDamage: 5)
    );



    // EPIC
    public static readonly AttackItem DaggerSwampBeast = new(
        ItemRarity.Epic,
        new ItemName("Dagger of the swamp beast"),
        new ItemDescription("A dagger forged from one of the swamp beast's claws. Its creation is a mystery, though it is said that the beast's claws can appear in the swamp it inhabits. Its unparalleled speed and critical strike potential make it incredibly lethal."),
        tradePrice: 60,
        attackDamage: 20,
        speedAttack: 5,
        durability: 15,
        new CriticalDamage(criticalProbability: 35, extraDamage: 15)
    );

    public static readonly AttackItem WilliamKinonSword = new(
        ItemRarity.Epic,
        new ItemName("William Kinon's Sword"),
        new ItemDescription("The sword of the great William Kinon, one of the court's most distinguished warriors. Forged from the finest materials and said to be imbued with his spirit, it is perfectly balanced and as deadly as its legendary wielder, though the current whereabouts of both the sword and its wielder are unknown."),
        tradePrice: 70,
        attackDamage: 22,
        speedAttack: 3,
        durability: 22,
        new CriticalDamage(criticalProbability: 15, extraDamage: 5)
    );

    public static readonly AttackItem SacredForestBranch = new(
        ItemRarity.Epic,
        new ItemName("Sacred forest branch"),
        new ItemDescription("A sharp branch from the sacred forest. How it came to leave the forest is a mystery, but its incredible durability is clearly due to the power of the forest's guardian."),
        tradePrice: 75,
        attackDamage: 15,
        speedAttack: 2,
        durability: 30,
        new CriticalDamage(criticalProbability: 10, extraDamage: 10)
    );

    public static readonly AttackItem FaraelCursedScythe = new(
        ItemRarity.Epic,
        new ItemName("Farael's cursed scythe"),
        new ItemDescription("The legendary scythe of the ancient god Farael, said to be cursed and fragile, allowing only a few uses. It delivers devastatingly powerful strikes, but its dark reputation keeps merchants from trading it."),
        tradePrice: 0,
        attackDamage: 70,
        speedAttack: 3,
        durability: 3,
        new CriticalDamage(criticalProbability: 0, extraDamage: 0)
    );



    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { WoodenStick, SharpStone, WoodenBludgeon, OldStoneSword, StoneAxe,
                                        KnightSword, IronDaggers, IronSpear, BlacksmithsHammer, Mace,
                                        DaggerSwampBeast, WilliamKinonSword, SacredForestBranch, FaraelCursedScythe
          });   
    }
}
