using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


// Specific class for attack item to attack enemies
public class AttackItem : Item
{
    private readonly int AttackDamage;
    private readonly int SpeedAttack;
    private readonly int Durability;

    // Default constructor
    public AttackItem(ItemName name, ItemDescription description, int attackDamage, int speedAttack, int durability)
        : base(name, description)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
    }

    // Restore constructor
    public AttackItem(Guid id, ItemName name, ItemDescription description, int attackDamage, int speedAttack, int durability)
        : base(id, name, description)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
    }

    // getters
    public int GetAttackDamage() => AttackDamage;

    public int GetSpeedAttack() => SpeedAttack ;

    public int GetDurability() => Durability;

    // To string
    public override string ToString()
    {
        return $"{GetName()} attack item({GetGuid()}): " + $"AttackDamage={AttackDamage}, SpeedAttack={SpeedAttack }, durability={Durability}";
    }
}