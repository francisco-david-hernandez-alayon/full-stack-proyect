using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Warrior Character entity
public class WarriorCharacter : Character
{
    private static readonly CharacterName _characterName = new CharacterName("Warrior");
    private static readonly int _defaultMaxHealthPoints = 150;
    private static readonly int _defaultMaxFoodPoints = 100;
    private static readonly int _defaultMaxInventorySlots = 5;
    private static readonly int _defaultStartingMoney = 10;


    // Default constructor
    public WarriorCharacter()
        : base(_characterName, _defaultMaxHealthPoints, _defaultMaxFoodPoints, _defaultMaxInventorySlots, _defaultStartingMoney)
    {
    }

    // Restore constructor
    public WarriorCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, List<Item> inventoryList)
        : base(_characterName, _defaultMaxHealthPoints, _defaultMaxFoodPoints, _defaultMaxInventorySlots, _defaultStartingMoney,
                currentHealthPoints, currentFoodPoints, currentMoney, inventoryList)
    {
    }

    protected override Character CloneWith(int currentHealthPoints, int currentFoodPoints, int currentMoney, IReadOnlyList<Item> inventoryList)
    {
        List<Item> inventoryNewList = new List<Item>(inventoryList);
        return new WarriorCharacter(currentHealthPoints, currentFoodPoints, currentMoney, inventoryNewList);
    }


    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", GetInventoryList().Select(i => i?.ToString() ?? "Empty"));
        return $"{GetName().GetName()} Warrior character: " +
               $"HP={GetCurrentHealthPoints}/{GetMaxHealthPoints()}, Food={GetCurrentFoodPoints()}/{GetMaxFoodPoints()}, " +
               $"InventorySlots={GetMaxInventorySlots()}, Money={GetCurrentMoney()}, Inventory=[{inventoryStr}]";
    }
}
