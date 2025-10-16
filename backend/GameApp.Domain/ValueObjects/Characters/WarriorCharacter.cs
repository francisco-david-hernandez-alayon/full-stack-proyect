using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Warrior Character entity
class WarriorCharacter : Character
{
    private static readonly CharacterName _characterName = new CharacterName("Warrior");
    private static readonly int _defaultMaxHealthPoints = 150;
    private static readonly int _defaultMaxFoodPoints = 100;
    private static readonly int _defaultMaxInventorySlots = 5;
    private static readonly int _defaultStartingMoney = 10;

    // current atributes
    private readonly int _currentHealthPoints;
    private readonly int _currentFoodPoints;
    private readonly int _currentMoney;
    private readonly List<Item> _inventoryList;


    // Default constructor
    public WarriorCharacter()
        : base(_characterName, _defaultMaxHealthPoints, _defaultMaxFoodPoints, _defaultMaxInventorySlots, _defaultStartingMoney)
    {
        _currentHealthPoints = _defaultMaxHealthPoints;
        _currentFoodPoints = _defaultMaxFoodPoints;
        _currentMoney = _defaultStartingMoney;
        _inventoryList = new List<Item>();
    }

    // Restore constructor
    public WarriorCharacter(CharacterName name, int currentHealthPoints, int currentFoodPoints,
                            int maxHealthPoints, int maxFoodPoints, int maxInventorySlots, int currentMoney, List<Item> inventoryList)
        : base(name, maxHealthPoints, maxFoodPoints, maxInventorySlots, currentMoney)
    {
        _currentHealthPoints = currentHealthPoints;
        _currentFoodPoints = currentFoodPoints;
        _currentMoney = currentMoney;
        _inventoryList = new List<Item>(inventoryList);
    }


    // getters
    public int GetCurrentHealthPoints() => _currentHealthPoints;
    public int GetCurrentFoodPoints() => _currentFoodPoints;
    public int GetCurrentMoney() => _currentMoney;
    public List<Item> GetInventoryList() => new List<Item>(_inventoryList);


    // setters
    public WarriorCharacter AddItemInventory(Item newItem)
    {
        if (_inventoryList.Count >= _maxInventorySlots)
            return this; // no empty slot, return unchanged

        List<Item> newInventory = new List<Item>(_inventoryList) { newItem };
        return new WarriorCharacter(_name, _currentHealthPoints, _currentFoodPoints, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, _currentMoney, newInventory);
    }


    public WarriorCharacter ReplaceItemInventory(int index, Item newItem)
    {
        if (index < 0 || index >= _inventoryList.Count) return this;
        var newInventory = new List<Item>(_inventoryList);
        newInventory[index] = newItem;
        return new WarriorCharacter(_name, _currentHealthPoints, _currentFoodPoints, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, _currentMoney, newInventory);
    }

    public WarriorCharacter RemoveItemInventory(int index)
    {
        if (index < 0 || index >= _inventoryList.Count) return this; // bad index
        
        var newInventory = new List<Item>(_inventoryList);
        newInventory.RemoveAt(index); 
        return new WarriorCharacter(_name, _currentHealthPoints, _currentFoodPoints,
                                    _maxHealthPoints, _maxFoodPoints, _maxInventorySlots,
                                    _currentMoney, newInventory);
    }

    public WarriorCharacter ReceiveDamage(int damage)
    {
        int newHealth = _currentHealthPoints - damage;
        if (newHealth < 0)
            newHealth = 0;

        return new WarriorCharacter(_name, newHealth, _currentFoodPoints, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, _currentMoney, _inventoryList);
    }

    public WarriorCharacter Heal(int amount)
    {
        int newHealth = _currentHealthPoints + amount;
        if (newHealth > _maxHealthPoints)
            newHealth = _maxHealthPoints;

        return new WarriorCharacter(_name, newHealth, _currentFoodPoints, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, _currentMoney, _inventoryList);
    }

    public WarriorCharacter Eat(int amount)
    {
        int newFood = _currentFoodPoints + amount;
        if (newFood > _maxFoodPoints)
            newFood = _maxFoodPoints;

        return new WarriorCharacter(_name, _currentHealthPoints, newFood, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, _currentMoney, _inventoryList);
    }

    public WarriorCharacter GetHungry(int amount)
    {
        int newFood = _currentFoodPoints - amount;
        if (newFood < 0)
            newFood = 0;

        return new WarriorCharacter(_name, _currentHealthPoints, newFood, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, _currentMoney, _inventoryList);
    }

    public WarriorCharacter EarnMoney(int amount)
    {
        int newMoney = _currentMoney + amount;

        return new WarriorCharacter(_name, _currentHealthPoints, _currentFoodPoints, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, newMoney, _inventoryList);
    }

    public WarriorCharacter SpendMoney(int amount)
    {
        int newMoney = _currentMoney - amount;
        if (newMoney < 0)  // You shouldn't be able to pay if you don't have enough money
            newMoney = 0;

        return new WarriorCharacter(_name, _currentHealthPoints, _currentFoodPoints, _maxHealthPoints, _maxFoodPoints, _maxInventorySlots, newMoney, _inventoryList);
    }


    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", _inventoryList.Select(i => i?.ToString() ?? "Empty"));
        return $"{_name.GetName()} Warrior character: " +
               $"HP={_currentHealthPoints}/{_maxHealthPoints}, Food={_currentFoodPoints}/{_maxFoodPoints}, " +
               $"InventorySlots={_maxInventorySlots}, Money={_currentMoney}, Inventory=[{inventoryStr}]";
    }
}
