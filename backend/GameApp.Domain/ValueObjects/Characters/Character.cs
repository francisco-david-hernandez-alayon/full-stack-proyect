
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Abstract class for Character value object
public abstract class Character
{
    public CharacterName Name { get; }
    public int MaxHealthPoints { get; }
    public int MaxFoodPoints { get; }
    public int MaxInventorySlots { get; }
    public int StartingMoney { get; }


    // current Character atributes
    public int CurrentHealthPoints { get; }
    public int CurrentFoodPoints { get; }
    public int CurrentMoney { get; }
    public IReadOnlyList<Item> InventoryList { get; }


    // Constructor
    protected Character(CharacterName name, int maxHealthPoints, int maxFoodPoints, int maxInventorySlots, int startingMoney)
    {
        Name = name;
        MaxHealthPoints = maxHealthPoints;
        MaxFoodPoints = maxFoodPoints;
        MaxInventorySlots = maxInventorySlots;
        StartingMoney = startingMoney;

        CurrentHealthPoints = MaxHealthPoints;
        CurrentFoodPoints = MaxFoodPoints;
        CurrentMoney = StartingMoney;
        InventoryList = new List<Item>();
    }

    // Restore Constructor
    protected Character(CharacterName name, int maxHealthPoints, int maxFoodPoints, int maxInventorySlots, int startingMoney,
                        int currentHealthPoints, int currentFoodPoints, int currentMoney, List<Item> inventoryList)
    {
        Name = name;
        MaxHealthPoints = maxHealthPoints;
        MaxFoodPoints = maxFoodPoints;
        MaxInventorySlots = maxInventorySlots;
        StartingMoney = startingMoney;

        CurrentHealthPoints = currentHealthPoints;
        CurrentFoodPoints = currentFoodPoints;
        CurrentMoney = currentMoney;
        InventoryList = inventoryList;
    }

    // Clone method for inmutable setters
    protected abstract Character CloneWith(int currentHealthPoints, int currentFoodPoints, int currentMoney, IReadOnlyList<Item> inventoryList);

    // getters
    public CharacterName GetName()
    {
        return Name;
    }

    public int GetMaxHealthPoints()
    {
        return MaxHealthPoints;
    }

    public int GetMaxFoodPoints()
    {
        return MaxFoodPoints;
    }

    public int GetMaxInventorySlots()
    {
        return MaxInventorySlots;
    }

    public int GetStartingMoney()
    {
        return StartingMoney;
    }

    public int GetCurrentHealthPoints()
    {
        return CurrentHealthPoints;
    }

    public int GetCurrentFoodPoints()
    {
        return CurrentFoodPoints;
    }

    public int GetCurrentMoney()
    {
        return CurrentMoney;
    }

    public IReadOnlyList<Item> GetInventoryList()
    {
        return InventoryList;
    }

    // setters
    public Character AddItemInventory(Item newItem)
    {
        if (InventoryList.Count >= MaxInventorySlots)
            return this;

        var newInventory = new List<Item>(InventoryList) { newItem };
        return CloneWith(CurrentHealthPoints, CurrentFoodPoints, CurrentMoney, newInventory);
    }

    public Character RemoveItemInventory(int index)
    {
        if (index < 0 || index >= InventoryList.Count)
            return this;

        var newInventory = new List<Item>(InventoryList);
        newInventory.RemoveAt(index);
        return CloneWith(CurrentHealthPoints, CurrentFoodPoints, CurrentMoney, newInventory);
    }

    public Character ReceiveDamage(int damage)
    {
        int newHealth = Math.Max(0, CurrentHealthPoints - damage);
        return CloneWith(newHealth, CurrentFoodPoints, CurrentMoney, InventoryList);
    }

    public Character Heal(int amount)
    {
        int newHealth = Math.Min(MaxHealthPoints, CurrentHealthPoints + amount);
        return CloneWith(newHealth, CurrentFoodPoints, CurrentMoney, InventoryList);
    }

    public Character Eat(int amount)
    {
        int newFood = Math.Min(MaxFoodPoints, CurrentFoodPoints + amount);
        return CloneWith(CurrentHealthPoints, newFood, CurrentMoney, InventoryList);
    }

    public Character GetHungry(int amount)
    {
        int newFood = Math.Max(0, CurrentFoodPoints - amount);
        return CloneWith(CurrentHealthPoints, newFood, CurrentMoney, InventoryList);
    }

    public Character EarnMoney(int amount)
    {
        return CloneWith(CurrentHealthPoints, CurrentFoodPoints, CurrentMoney + amount, InventoryList);
    }

    public Character SpendMoney(int amount)
    {
        int newMoney = Math.Max(0, CurrentMoney - amount);
        return CloneWith(CurrentHealthPoints, CurrentFoodPoints, newMoney, InventoryList);
    }

}