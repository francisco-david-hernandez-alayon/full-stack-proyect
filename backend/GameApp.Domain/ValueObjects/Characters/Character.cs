
namespace GameApp.Domain.ValueObjects.Characters;

// Abstract class for Character entity
public abstract class Character
{
    // character general properties
    private readonly Guid _id;
    private readonly CharacterName _name;
    private readonly int _maxHealthPoints;
    private readonly int _maxFoodPoints;
    private readonly int _maxInventorySlots;


    // Constructor
    protected Character(CharacterName name, int maxHealthPoints, int maxFoodPoints, int maxInventorySlots)
    {
        _id = Guid.NewGuid();
        _name = name;
        _maxHealthPoints = maxHealthPoints;
        _maxFoodPoints = maxFoodPoints;
        _maxInventorySlots = maxInventorySlots;
    }

    // Getters
    public Guid GetId() => _id;
    public CharacterName GetName() => _name;
    public int GetMaxHealthPoints() => _maxHealthPoints;
    public int GetMaxFoodPoints() => _maxFoodPoints;
    public int GetMaxInventorySlots() => _maxInventorySlots;

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} character (ID: {_id}): " +
               $"MaxHP={_maxHealthPoints}, MaxFood={_maxFoodPoints}, MaxInventorySlots={_maxInventorySlots}";
    }

}