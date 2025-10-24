namespace GameApp.Domain.ValueObjects.Enemies;

// Class for an enemy
public class Enemy
{
    public readonly EnemyName Name;
    public readonly int HealthPoints;
    public readonly int AttackDamage;
    public readonly int SpeedAttack;
    public readonly int RewardMoney;

    // constructor
    public Enemy(EnemyName name, int healthPoints, int attackDamage, int speedAttack, int rewardMoney)
    {
        Name = name;
        HealthPoints = healthPoints;
        AttackDamage = attackDamage;
        SpeedAttack = speedAttack;
        RewardMoney = rewardMoney;
    }

    // Getters
    public EnemyName GetName() => Name;
    public int GetHealthPoints() => HealthPoints;
    public int GetAttackDamage() => AttackDamage;
    public int GetSpeedAttack() => SpeedAttack;
    public int GetRewardMoney() => RewardMoney;

    // Setters
    public Enemy SetName(EnemyName newName) => new Enemy(newName, HealthPoints, AttackDamage, SpeedAttack, RewardMoney);
    public Enemy SetHealthPoints(int newHealthPoints) => new Enemy(Name, newHealthPoints, AttackDamage, SpeedAttack, RewardMoney);
    public Enemy SetAttackDamage(int newAttackDamage) => new Enemy(Name, HealthPoints, newAttackDamage, SpeedAttack, RewardMoney);
    public Enemy SetSpeedAttack(int newSpeedAttack) => new Enemy(Name, HealthPoints, AttackDamage, newSpeedAttack, RewardMoney);
    public Enemy SetRewardMoney(int newRewardMoney) => new Enemy(Name, HealthPoints, AttackDamage, SpeedAttack, newRewardMoney);
    public Enemy ReceiveDamage(int damage) {
        int newHealthPoints = HealthPoints - damage;

        if (newHealthPoints < 0) {
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