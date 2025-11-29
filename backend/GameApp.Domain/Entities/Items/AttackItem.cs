using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


// Specific class for attack item to attack enemies
public class AttackItem : Item
{
    private readonly int AttackDamage;
    private readonly int SpeedAttack;
    private readonly int Durability;

    // Default constructor
    public AttackItem(ItemName name, ItemDescription description, int tradePrice, int attackDamage, int speedAttack, int durability)
        : base(name, description, tradePrice)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
    }

    // Restore constructor
    public AttackItem(Guid id, ItemName name, ItemDescription description, int tradePrice,  int attackDamage, int speedAttack, int durability)
        : base(id, name, description, tradePrice)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
    }

    // getters
    public int GetAttackDamage() => AttackDamage;

    public int GetSpeedAttack() => SpeedAttack ;

    public int GetDurability() => Durability;

    public AttackItem SetAttackDamage(int newAttackDamage) => new AttackItem(GetGuid(), GetName(), GetDescription(), GetTradePrice(), newAttackDamage, GetSpeedAttack(), GetDurability()); 

    public AttackItem SetSpeedAttack(int newSpeedAttack) => new AttackItem(GetGuid(), GetName(), GetDescription(), GetTradePrice(), GetAttackDamage(), newSpeedAttack, GetDurability()); 

    public AttackItem SetDurability(int newDurability) => new AttackItem(GetGuid(), GetName(), GetDescription(), GetTradePrice(), GetAttackDamage(), GetSpeedAttack(), newDurability); 

    public AttackItem SetPrice(int newTradePrice) => new AttackItem(GetGuid(), GetName(), GetDescription(), newTradePrice, GetAttackDamage(), GetSpeedAttack(), GetDurability()); 



    // To string
    public override string ToString()
    {
        return $"{GetName()} attack item({GetGuid()}): " + $"AttackDamage={AttackDamage}, SpeedAttack={SpeedAttack }, durability={Durability}, TradePrice={GetTradePrice()}";
    }
}