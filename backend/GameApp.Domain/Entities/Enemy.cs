using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Combat;
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
    private readonly CriticalDamage CriticalDamage;
    private readonly EnemyDifficulty Difficulty;


    // Default constructor
    public Enemy(EnemyDifficulty difficulty, EnemyName name, int healthPoints, int attackDamage, int speedAttack, CriticalDamage criticalDamage, int rewardMoney)
    {
        Id = Guid.NewGuid();
        Difficulty = difficulty;
        Name = name;
        HealthPoints = healthPoints;
        AttackDamage = attackDamage;
        SpeedAttack = speedAttack;
        CriticalDamage = criticalDamage;
        RewardMoney = rewardMoney;
    }

    // Restore constructor
    public Enemy(Guid id, EnemyDifficulty difficulty, EnemyName name, int healthPoints, int attackDamage, int speedAttack, CriticalDamage criticalDamage, int rewardMoney)
    {
        Id = id;
        Difficulty = difficulty;
        Name = name;
        HealthPoints = healthPoints;
        AttackDamage = attackDamage;
        SpeedAttack = speedAttack;
        CriticalDamage = criticalDamage;
        RewardMoney = rewardMoney;
    }

    // Getters
    public Guid GetGuid() => Id;
    public EnemyDifficulty GetDifficulty() => Difficulty;
    public EnemyName GetName() => Name;
    public int GetHealthPoints() => HealthPoints;
    public int GetAttackDamage() => AttackDamage;
    public int GetSpeedAttack() => SpeedAttack;
    public int GetRewardMoney() => RewardMoney;
    public CriticalDamage GetCriticalDamage() => CriticalDamage;
    

    // Setters
    public Enemy SetDifficulty(EnemyDifficulty newDifficulty) => new Enemy(GetGuid(), newDifficulty, Name, HealthPoints, AttackDamage, SpeedAttack, CriticalDamage, RewardMoney);
    public Enemy SetName(EnemyName newName) => new Enemy(GetGuid(), Difficulty, newName, HealthPoints, AttackDamage, SpeedAttack, CriticalDamage, RewardMoney);
    public Enemy SetHealthPoints(int newHealthPoints) => new Enemy(GetGuid(), Difficulty, Name, newHealthPoints, AttackDamage, SpeedAttack, CriticalDamage, RewardMoney);
    public Enemy SetAttackDamage(int newAttackDamage) => new Enemy(GetGuid(), Difficulty, Name, HealthPoints, newAttackDamage, SpeedAttack, CriticalDamage, RewardMoney);
    public Enemy SetSpeedAttack(int newSpeedAttack) => new Enemy(GetGuid(), Difficulty, Name, HealthPoints, AttackDamage, newSpeedAttack, CriticalDamage, RewardMoney);
    public Enemy SetRewardMoney(int newRewardMoney) => new Enemy(GetGuid(), Difficulty, Name, HealthPoints, AttackDamage, SpeedAttack, CriticalDamage, newRewardMoney);
    public Enemy SetCriticalDamage(CriticalDamage newCriticalDamage) => new Enemy(GetGuid(), Difficulty, Name, HealthPoints, AttackDamage, SpeedAttack, newCriticalDamage, RewardMoney);
    public Enemy ReceiveDamage(int damage)
    {
        int newHealthPoints = HealthPoints - damage;

        if (newHealthPoints < 0)
        {
            newHealthPoints = 0;
        }

        return new Enemy(Difficulty, Name, newHealthPoints, AttackDamage, SpeedAttack, CriticalDamage, RewardMoney);
    }

    // To string
    public override string ToString()
    {
        return $"{Name.GetName()} Enemy(Difficulty {Difficulty}): " +
               $"HealthPoints={HealthPoints}, " +
               $"AttackDamage={AttackDamage}, " +
               $"SpeedAttack={SpeedAttack}, " +
               $"Critical Damage={CriticalDamage}" +
               $"RewardMoney={RewardMoney}";
    }

}