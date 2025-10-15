namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Warrior Character entity
class WarriorCharacter : Character
{
    private static readonly CharacterName _characterName = new CharacterName("Warrior");
    private static readonly int _defaultMaxHealthPoints = 150;
    private static readonly int _defaultMaxFoodPoints = 100;
    private static readonly int _defaultMaxInventorySlots = 5;
    private static readonly int _defaultStartingMoney = 10;

    // Constructor
    public WarriorCharacter()
        : base(_characterName, _defaultMaxHealthPoints, _defaultMaxFoodPoints, _defaultMaxInventorySlots, _defaultStartingMoney)
    {
    }
}

