using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Warrior Character entity
public class WarriorCharacter : Character
{
    private static readonly CharacterName CharacterName = new CharacterName("Warrior");
    private static readonly int DefaultMaxHealthPoints = 150;
    private static readonly int DefaultMaxFoodPoints = 100;
    private static readonly int DefaultMaxInventorySlots = 5;
    private static readonly int DefaultStartingMoney = 10;
    private static readonly int DefaultAttackSpeed = 3;
    private static readonly int DefaultAttackDamage = 3;


    // Character Ability
    private static readonly int HitsNeededToGetAbility = 10;
    private static readonly int AbilityDamage = 30;
    private readonly int CurrentHits;
    


    // Default constructor
    public WarriorCharacter()
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage)
    {
        CurrentHits = 0;
    }

    // Restore constructor
    public WarriorCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, List<Item> inventoryList, int currentHits)
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage,
                currentHealthPoints, currentFoodPoints, currentMoney, inventoryList)
    {
        CurrentHits = currentHits;
    }

    protected override Character CloneCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, IReadOnlyList<Item> inventoryList)
    {
        List<Item> inventoryNewList = new List<Item>(inventoryList);
        return new WarriorCharacter(currentHealthPoints, currentFoodPoints, currentMoney, inventoryNewList, CurrentHits);
    }

    // getter
    public int GetHitsToGetAbility() => HitsNeededToGetAbility;
    public int GetAbilityDamage() => AbilityDamage;
    public int GetHits() => CurrentHits;

    // setter
    public WarriorCharacter SetHits(int newHits) => new WarriorCharacter(GetCurrentHealthPoints(), GetCurrentFoodPoints(), GetCurrentMoney(), new List<Item>(GetInventoryList()), newHits);
    

    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", GetInventoryList().Select(i => i?.ToString() ?? "Empty"));
        return $"{GetName().GetName()} Warrior character(atq={GetAttackDamage()}, spd={GetAttackSpeed()}): " +
               $"HP={GetCurrentHealthPoints}/{GetMaxHealthPoints()}, Food={GetCurrentFoodPoints()}/{GetMaxFoodPoints()}, " +
               $"InventorySlots={GetMaxInventorySlots()}, Money={GetCurrentMoney()}, Inventory=[{inventoryStr}] Hits=[{CurrentHits}/{HitsNeededToGetAbility}]";
    }
}
