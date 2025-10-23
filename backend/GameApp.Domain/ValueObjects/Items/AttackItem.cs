namespace GameApp.Domain.ValueObjects.Items;


// Specific class for attack item to attack enemies
public class AttackItem : Item
{
    public int AttackDamage { get; private set; }
    public int SpeedAttack { get; private set; }
    public int Durability { get; private set; }

    // constructor
    public AttackItem(ItemName name, ItemDescription description, int attackDamage, int speedAttack, int durability)
        : base(name, description)
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
        return $"{GetName()} attack item: " + $"AttackDamage={AttackDamage}, SpeedAttack={SpeedAttack }, durability={Durability}";
    }
}