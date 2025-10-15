namespace GameApp.Domain.ValueObjects.Items;


// Specific class for attack item to attack enemies
class AttackItem : Item
{
    private readonly int _attackDamage;

    private readonly int _speedAttack;

    private readonly int _durability;

    // constructor
    public AttackItem(ItemName name, ItemDescription description, int attackDamage, int speedAttack, int durability)
        : base(name, description)
    {
        _attackDamage = attackDamage;
        _speedAttack = speedAttack;
        _durability = durability;
    }
    
    // getters
    public int GetAttackDamage() => _attackDamage;

    public int GetSpeedAttack() => _speedAttack;

    public int GetDurability() => _durability;

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} attack item: " + $"AttackDamage={_attackDamage}, SpeedAttack={_speedAttack}, durability={_durability}";
    }
}