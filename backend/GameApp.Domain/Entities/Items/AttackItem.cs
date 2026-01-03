using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


// Specific class for attack item to attack enemies
public class AttackItem : Item
{
    private readonly int AttackDamage;
    private readonly int SpeedAttack;
    private readonly int Durability;

    // Default constructor
    public AttackItem(ItemRarity rarity, ItemName name, ItemDescription description, int tradePrice, int attackDamage, int speedAttack, int durability)
        : base(rarity, name, description, tradePrice)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
    }

    // Restore constructor
    public AttackItem(Guid id, ItemRarity rarity, ItemName name, ItemDescription description, int tradePrice,  int attackDamage, int speedAttack, int durability)
        : base(id, rarity, name, description, tradePrice)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
    }

    // getters
    public int GetAttackDamage() => AttackDamage;

    public int GetSpeedAttack() => SpeedAttack ;

    public int GetDurability() => Durability;

    public AttackItem SetAttackDamage(int newAttackDamage) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetTradePrice(), newAttackDamage, GetSpeedAttack(), GetDurability()); 

    public AttackItem SetSpeedAttack(int newSpeedAttack) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetTradePrice(), GetAttackDamage(), newSpeedAttack, GetDurability()); 

    public AttackItem SetDurability(int newDurability) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetTradePrice(), GetAttackDamage(), GetSpeedAttack(), newDurability); 

    public AttackItem SetPrice(int newTradePrice) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), newTradePrice, GetAttackDamage(), GetSpeedAttack(), GetDurability()); 



    // To string
    public override string ToString()
    {
        return $"{GetName()} attack item({GetGuid()}, Difficulty {GetRarity()}): " + $"AttackDamage={AttackDamage}, SpeedAttack={SpeedAttack }, durability={Durability}, TradePrice={GetTradePrice()}";
    }
}