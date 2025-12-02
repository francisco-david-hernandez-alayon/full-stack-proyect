using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Domain.Entities;

// Class for an enemy
public class Enemy
{
    private readonly Guid Id;
    private readonly EnemyName Name;
    private readonly int HealthPoints;
    private readonly int AttackDamage;
    private readonly int SpeedAttack;
    private readonly int RewardMoney;


    // Default constructor
    public Enemy(EnemyName name, int healthPoints, int attackDamage, int speedAttack, int rewardMoney)
    {
        Id = Guid.NewGuid();
        Name = name;
        HealthPoints = healthPoints;
        AttackDamage = attackDamage;
        SpeedAttack = speedAttack;
        RewardMoney = rewardMoney;
    }

    // Restore constructor
    public Enemy(Guid id, EnemyName name, int healthPoints, int attackDamage, int speedAttack, int rewardMoney)
    {
        Id = id;
        Name = name;
        HealthPoints = healthPoints;
        AttackDamage = attackDamage;
        SpeedAttack = speedAttack;
        RewardMoney = rewardMoney;
    }

    // Getters
    public Guid GetGuid() => Id;
    public EnemyName GetName() => Name;
    public int GetHealthPoints() => HealthPoints;
    public int GetAttackDamage() => AttackDamage;
    public int GetSpeedAttack() => SpeedAttack;
    public int GetRewardMoney() => RewardMoney;

    // Setters
    public Enemy SetName(EnemyName newName) => new Enemy(GetGuid(), newName, HealthPoints, AttackDamage, SpeedAttack, RewardMoney);
    public Enemy SetHealthPoints(int newHealthPoints) => new Enemy(GetGuid(), Name, newHealthPoints, AttackDamage, SpeedAttack, RewardMoney);
    public Enemy SetAttackDamage(int newAttackDamage) => new Enemy(GetGuid(), Name, HealthPoints, newAttackDamage, SpeedAttack, RewardMoney);
    public Enemy SetSpeedAttack(int newSpeedAttack) => new Enemy(GetGuid(), Name, HealthPoints, AttackDamage, newSpeedAttack, RewardMoney);
    public Enemy SetRewardMoney(int newRewardMoney) => new Enemy(GetGuid(), Name, HealthPoints, AttackDamage, SpeedAttack, newRewardMoney);
    public Enemy ReceiveDamage(int damage)
    {
        int newHealthPoints = HealthPoints - damage;

        if (newHealthPoints < 0)
        {
            newHealthPoints = 0;
        }

        return new Enemy(Name, newHealthPoints, AttackDamage, SpeedAttack, RewardMoney);
    }

    // To string
    public override string ToString()
    {
        return $"{Name.GetName()} Enemy: " +
               $"HealthPoints={HealthPoints}, " +
               $"AttackDamage={AttackDamage}, " +
               $"SpeedAttack={SpeedAttack}, " +
               $"RewardMoney={RewardMoney}";
    }

}