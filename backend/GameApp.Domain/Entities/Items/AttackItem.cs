using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Combat;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


// Specific class for attack item to attack enemies
public class AttackItem : Item
{
    private readonly int AttackDamage;
    private readonly int SpeedAttack;
    private readonly int Durability;

    private readonly CriticalDamage CriticalDamage;

    // Default constructor
    public AttackItem(ItemRarity rarity, ItemName name, ItemDescription description, ItemIcon icon, int tradePrice, int attackDamage, int speedAttack, int durability, CriticalDamage criticalDamage)
        : base(rarity, name, description, icon, tradePrice)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
        CriticalDamage = criticalDamage;
    }

    // Restore constructor
    public AttackItem(Guid id, ItemRarity rarity, ItemName name, ItemDescription description, ItemIcon icon, int tradePrice,  int attackDamage, int speedAttack, int durability, CriticalDamage criticalDamage)
        : base(id, rarity, name, description, icon, tradePrice)
    {
        AttackDamage = attackDamage;
        SpeedAttack  = speedAttack;
        Durability = durability;
        CriticalDamage = criticalDamage;
    }

    // Getters
    public int GetAttackDamage() => AttackDamage;
    public int GetSpeedAttack() => SpeedAttack ;
    public int GetDurability() => Durability;
    public CriticalDamage GetCriticalDamage() => CriticalDamage;

    // Setters
    public AttackItem SetAttackDamage(int newAttackDamage) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetIcon(), GetTradePrice(), newAttackDamage, GetSpeedAttack(), GetDurability(), GetCriticalDamage()); 
    public AttackItem SetSpeedAttack(int newSpeedAttack) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetIcon(), GetTradePrice(), GetAttackDamage(), newSpeedAttack, GetDurability(), GetCriticalDamage()); 
    public AttackItem SetDurability(int newDurability) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetIcon(), GetTradePrice(), GetAttackDamage(), GetSpeedAttack(), newDurability, GetCriticalDamage()); 
    public AttackItem SetPrice(int newTradePrice) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetIcon(), newTradePrice, GetAttackDamage(), GetSpeedAttack(), GetDurability(), GetCriticalDamage()); 
    public AttackItem SetCriticalDamage(CriticalDamage newCriticalDamage) => new AttackItem(GetGuid(), GetRarity(), GetName(), GetDescription(), GetIcon(), GetTradePrice(), GetAttackDamage(), GetSpeedAttack(), GetDurability(), newCriticalDamage); 


    // To string
    public override string ToString()
    {
        return $"{GetName()} attack item({GetGuid()}, Difficulty {GetRarity()}): " + $"AttackDamage={AttackDamage}, SpeedAttack={SpeedAttack }, durability={Durability}, critical={CriticalDamage}, TradePrice={GetTradePrice()}";
    }
}