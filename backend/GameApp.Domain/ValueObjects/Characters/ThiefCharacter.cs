using GameApp.Domain.Entities.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Thief Character entity
public class ThiefCharacter : Character
{
    private static readonly CharacterName CharacterName = new CharacterName("Thief");
    private static readonly int DefaultMaxHealthPoints = 120;
    private static readonly int DefaultMaxFoodPoints = 90;
    private static readonly int DefaultMaxInventorySlots = 6;
    private static readonly int DefaultStartingMoney = 30;
    private static readonly int DefaultAttackSpeed = 4;
    private static readonly int DefaultAttackDamage = 4;


    // Character Ability
    private static readonly int ExtraMoneyWhenKillEnemy = 5;
    


    // Default constructor
    public ThiefCharacter()
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage)
    {
    }

    // Restore constructor
    public ThiefCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, List<Item> inventoryList)
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage,
                currentHealthPoints, currentFoodPoints, currentMoney, inventoryList)
    {
    }

    protected override Character CloneCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, IReadOnlyList<Item> inventoryList)
    {
        List<Item> inventoryNewList = new List<Item>(inventoryList);
        return new ThiefCharacter(currentHealthPoints, currentFoodPoints, currentMoney, inventoryNewList);
    }

    // getter
    public int GetExtraMoneyWhenKillEnemy() => ExtraMoneyWhenKillEnemy;
    

    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", GetInventoryList().Select(i => i?.ToString() ?? "Empty"));
        return $"{GetName().GetName()} Thief character(atq={GetAttackDamage()}, spd={GetAttackSpeed()}): " +
               $"HP={GetCurrentHealthPoints}/{GetMaxHealthPoints()}, Food={GetCurrentFoodPoints()}/{GetMaxFoodPoints()}, " +
               $"InventorySlots={GetMaxInventorySlots()}, Money={GetCurrentMoney()}, Inventory=[{inventoryStr}] ExtraMoneyWhenKill=[{ExtraMoneyWhenKillEnemy}]";
    }
}
