
namespace GameApp.Domain.ValueObjects.Characters;

// Abstract class for Character value object
public abstract class Character
{
    public CharacterName Name { get; }
    public int MaxHealthPoints { get; }
    public int MaxFoodPoints { get; }
    public int MaxInventorySlots { get; }
    public int StartingMoney { get; }


    // Constructor
    protected Character(CharacterName name, int maxHealthPoints, int maxFoodPoints, int maxInventorySlots, int startingMoney)
    {
        Name = name;
        MaxHealthPoints = maxHealthPoints;
        MaxFoodPoints = maxFoodPoints;
        MaxInventorySlots = maxInventorySlots;
        StartingMoney = startingMoney;
    }

    // Getters
    public CharacterName GetName() => Name;
    public int GetMaxHealthPoints() => MaxHealthPoints;
    public int GetMaxFoodPoints() => MaxFoodPoints;
    public int GetMaxInventorySlots() => MaxInventorySlots;
    public int GetStartingMoney() => StartingMoney;

}