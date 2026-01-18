using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Berserker Character entity
public class BerserkerCharacter : Character
{
    private static readonly CharacterName CharacterName = new CharacterName("Berserker");
    private static readonly int DefaultMaxHealthPoints = 200;
    private static readonly int DefaultMaxFoodPoints = 60;
    private static readonly int DefaultMaxInventorySlots = 4;
    private static readonly int DefaultStartingMoney = 0;
    private static readonly int DefaultAttackSpeed = 3;
    private static readonly int DefaultAttackDamage = 10;


    // Character Ability
    private static readonly int KillsNeededToGetAbility = 5;
    private static readonly int AbilityCure = 50;
    private readonly int CurrentKills;
    


    // Default constructor
    public BerserkerCharacter()
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage)
    {
        CurrentKills = 0;
    }

    // Restore constructor
    public BerserkerCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, List<Item> inventoryList, int currentKills)
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage,
                currentHealthPoints, currentFoodPoints, currentMoney, inventoryList)
    {
        CurrentKills = currentKills;
    }

    protected override Character CloneCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, IReadOnlyList<Item> inventoryList)
    {
        List<Item> inventoryNewList = new List<Item>(inventoryList);
        return new BerserkerCharacter(currentHealthPoints, currentFoodPoints, currentMoney, inventoryNewList, CurrentKills);
    }

    // getter
    public int GetKillsToGetAbility() => KillsNeededToGetAbility;
    public int GetAbilityCure() => AbilityCure;
    public int GetKills() => CurrentKills;

    // setter
    public BerserkerCharacter SetKills(int newKills) => new BerserkerCharacter(GetCurrentHealthPoints(), GetCurrentFoodPoints(), GetCurrentMoney(), new List<Item>(GetInventoryList()), newKills);
    

    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", GetInventoryList().Select(i => i?.ToString() ?? "Empty"));
        return $"{GetName().GetName()} Berserker character(atq={GetAttackDamage()}, spd={GetAttackSpeed()}): " +
               $"HP={GetCurrentHealthPoints}/{GetMaxHealthPoints()}, Food={GetCurrentFoodPoints()}/{GetMaxFoodPoints()}, " +
               $"InventorySlots={GetMaxInventorySlots()}, Money={GetCurrentMoney()}, Inventory=[{inventoryStr}] Kills=[{CurrentKills}/{KillsNeededToGetAbility}]";
    }
}
