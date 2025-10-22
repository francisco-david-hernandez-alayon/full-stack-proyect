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

    // current atributes  (COULD BE IN CHARACTER ABSTRACT CLASS)
    public int CurrentHealthPoints { get; }
    public int CurrentFoodPoints { get; }
    public int CurrentMoney { get; }
    public IReadOnlyList<Item> InventoryList { get; }



    // Default constructor
    public WarriorCharacter()
        : base(_characterName, _defaultMaxHealthPoints, _defaultMaxFoodPoints, _defaultMaxInventorySlots, _defaultStartingMoney)
    {
        CurrentHealthPoints = _defaultMaxHealthPoints;
        CurrentFoodPoints = _defaultMaxFoodPoints;
        CurrentMoney = _defaultStartingMoney;
        InventoryList = new List<Item>();
    }

    // Restore constructor
    public WarriorCharacter(CharacterName name, int currentHealthPoints, int currentFoodPoints,
                            int maxHealthPoints, int maxFoodPoints, int maxInventorySlots, int currentMoney, List<Item> inventoryList)
        : base(name, maxHealthPoints, maxFoodPoints, maxInventorySlots, currentMoney)
    {
        CurrentHealthPoints = currentHealthPoints;
        CurrentFoodPoints = currentFoodPoints;
        CurrentMoney = currentMoney;
        InventoryList = new List<Item>(inventoryList);
    }


    // getters
    public int GetCurrentHealthPoints() => CurrentHealthPoints;
    public int GetCurrentFoodPoints() => CurrentFoodPoints;
    public int GetCurrentMoney() => CurrentMoney;
    public List<Item> GetInventoryList() => new List<Item>(InventoryList);


    // setters
    public WarriorCharacter AddItemInventory(Item newItem)
    {
        if (InventoryList.Count >= MaxInventorySlots)
            return this; // no empty slot, return unchanged

        List<Item> newInventory = new List<Item>(InventoryList) { newItem };
        return new WarriorCharacter(Name, CurrentHealthPoints, CurrentFoodPoints, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, CurrentMoney, newInventory);
    }


    public WarriorCharacter ReplaceItemInventory(int index, Item newItem)
    {
        if (index < 0 || index >= InventoryList.Count) return this;
        var newInventory = new List<Item>(InventoryList);
        newInventory[index] = newItem;
        return new WarriorCharacter(Name, CurrentHealthPoints, CurrentFoodPoints, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, CurrentMoney, newInventory);
    }

    public WarriorCharacter RemoveItemInventory(int index)
    {
        if (index < 0 || index >= InventoryList.Count) return this; // bad index

        var newInventory = new List<Item>(InventoryList);
        newInventory.RemoveAt(index);
        return new WarriorCharacter(Name, CurrentHealthPoints, CurrentFoodPoints,
                                    MaxHealthPoints, MaxFoodPoints, MaxInventorySlots,
                                    CurrentMoney, newInventory);
    }

    public WarriorCharacter ReceiveDamage(int damage)
    {
        int newHealth = CurrentHealthPoints - damage;
        if (newHealth < 0)
            newHealth = 0;

        return new WarriorCharacter(Name, newHealth, CurrentFoodPoints, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, CurrentMoney, GetInventoryList());
    }

    public WarriorCharacter Heal(int amount)
    {
        int newHealth = CurrentHealthPoints + amount;
        if (newHealth > MaxHealthPoints)
            newHealth = MaxHealthPoints;

        return new WarriorCharacter(Name, newHealth, CurrentFoodPoints, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, CurrentMoney, GetInventoryList());
    }

    public WarriorCharacter Eat(int amount)
    {
        int newFood = CurrentFoodPoints + amount;
        if (newFood > MaxFoodPoints)
            newFood = MaxFoodPoints;

        return new WarriorCharacter(Name, CurrentHealthPoints, newFood, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, CurrentMoney, GetInventoryList());
    }

    public WarriorCharacter GetHungry(int amount)
    {
        int newFood = CurrentFoodPoints - amount;
        if (newFood < 0)
            newFood = 0;

        return new WarriorCharacter(Name, CurrentHealthPoints, newFood, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, CurrentMoney, GetInventoryList());
    }

    public WarriorCharacter EarnMoney(int amount)
    {
        int newMoney = CurrentMoney + amount;

        return new WarriorCharacter(Name, CurrentHealthPoints, CurrentFoodPoints, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, newMoney, GetInventoryList());
    }

    public WarriorCharacter SpendMoney(int amount)
    {
        int newMoney = CurrentMoney - amount;
        if (newMoney < 0)  // You shouldn't be able to pay if you don't have enough money
            newMoney = 0;

        return new WarriorCharacter(Name, CurrentHealthPoints, CurrentFoodPoints, MaxHealthPoints, MaxFoodPoints, MaxInventorySlots, newMoney, GetInventoryList());
    }


    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", InventoryList.Select(i => i?.ToString() ?? "Empty"));
        return $"{Name.GetName()} Warrior character: " +
               $"HP={CurrentHealthPoints}/{MaxHealthPoints}, Food={CurrentFoodPoints}/{MaxFoodPoints}, " +
               $"InventorySlots={MaxInventorySlots}, Money={CurrentMoney}, Inventory=[{inventoryStr}]";
    }
}
