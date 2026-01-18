using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Characters;

// Concrete class for Explorer Character entity
public class ExplorerCharacter : Character
{
    private static readonly CharacterName CharacterName = new CharacterName("Explorer");
    private static readonly int DefaultMaxHealthPoints = 100;
    private static readonly int DefaultMaxFoodPoints = 140;
    private static readonly int DefaultMaxInventorySlots = 7;
    private static readonly int DefaultStartingMoney = 20;
    private static readonly int DefaultAttackSpeed = 2;
    private static readonly int DefaultAttackDamage = 3;


    // Character Ability
    private static readonly int NothingHappensScenesNeededToGetAbility = 3;
    private static readonly int ProbabilityOfRareItem = 15;
    private readonly int CurrentNothingHappensScenesVisited;
    


    // Default constructor
    public ExplorerCharacter()
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage)
    {
        CurrentNothingHappensScenesVisited = 0;
    }

    // Restore constructor
    public ExplorerCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, List<Item> inventoryList, int currentNothingHappensScenesVisited)
        : base(CharacterName, DefaultMaxHealthPoints, DefaultMaxFoodPoints, DefaultMaxInventorySlots, DefaultStartingMoney, DefaultAttackSpeed, DefaultAttackDamage,
                currentHealthPoints, currentFoodPoints, currentMoney, inventoryList)
    {
        CurrentNothingHappensScenesVisited = currentNothingHappensScenesVisited;
    }

    protected override Character CloneCharacter(int currentHealthPoints, int currentFoodPoints, int currentMoney, IReadOnlyList<Item> inventoryList)
    {
        List<Item> inventoryNewList = new List<Item>(inventoryList);
        return new ExplorerCharacter(currentHealthPoints, currentFoodPoints, currentMoney, inventoryNewList, CurrentNothingHappensScenesVisited);
    }

    // getter
    public int GetNothingHappensScenesToGetAbility() => NothingHappensScenesNeededToGetAbility;
    public int GetProbabilityOfRareItem() => ProbabilityOfRareItem;
    public int GetNothingHappensScenesVisited() => CurrentNothingHappensScenesVisited;

    // setter
    public ExplorerCharacter SetCurrentNothingHappensScenes(int currentNothingHappensScenes) => new ExplorerCharacter(GetCurrentHealthPoints(), GetCurrentFoodPoints(), GetCurrentMoney(), new List<Item>(GetInventoryList()), currentNothingHappensScenes);
    public ExplorerCharacter AddCurrentNothingHappensScenes()
    {
        int newValue = Math.Min(
            CurrentNothingHappensScenesVisited + 1,
            NothingHappensScenesNeededToGetAbility
        );

        return new ExplorerCharacter(
            GetCurrentHealthPoints(),
            GetCurrentFoodPoints(),
            GetCurrentMoney(),
            new List<Item>(GetInventoryList()),
            newValue
        );
    }

    // To string
    public override string ToString()
    {
        string inventoryStr = string.Join(", ", GetInventoryList().Select(i => i?.ToString() ?? "Empty"));
        return $"{GetName().GetName()} Explorer character(atq={GetAttackDamage()}, spd={GetAttackSpeed()}): " +
               $"HP={GetCurrentHealthPoints}/{GetMaxHealthPoints()}, Food={GetCurrentFoodPoints()}/{GetMaxFoodPoints()}, " +
               $"InventorySlots={GetMaxInventorySlots()}, Money={GetCurrentMoney()}, Inventory=[{inventoryStr}] currentNothingHappensScenes=[{CurrentNothingHappensScenesVisited}/{NothingHappensScenesNeededToGetAbility}]";
    }
}
