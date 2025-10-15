
namespace GameApp.Domain.ValueObjects.Characters;

// Abstract class for Character value object
public abstract class Character
{
    protected readonly CharacterName _name;
    protected readonly int _maxHealthPoints;
    protected readonly int _maxFoodPoints;
    protected readonly int _maxInventorySlots;
    protected readonly int _startingMoney;

    // Constructor
    protected Character(CharacterName name, int maxHealthPoints, int maxFoodPoints, int maxInventorySlots, int startingMoney)
    {
        _name = name;
        _maxHealthPoints = maxHealthPoints;
        _maxFoodPoints = maxFoodPoints;
        _maxInventorySlots = maxInventorySlots;
        _startingMoney = startingMoney;
    }

    // Getters
    public CharacterName GetName() => _name;
    public int GetMaxHealthPoints() => _maxHealthPoints;
    public int GetMaxFoodPoints() => _maxFoodPoints;
    public int GetMaxInventorySlots() => _maxInventorySlots;
    public int GetStartingMoney() => _startingMoney;

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} character: " +
               $"MaxHP={_maxHealthPoints}, MaxFood={_maxFoodPoints}, MaxInventorySlots={_maxInventorySlots}, StartingMoney={_startingMoney},";
    }

}