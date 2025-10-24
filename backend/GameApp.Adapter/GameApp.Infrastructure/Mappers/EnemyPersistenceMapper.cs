using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class EnemyPersistenceMapper
{
    public static EnemyPersistenceModel ToPersistenceModel(Enemy enemy)
    {
        return new EnemyPersistenceModel
        {
            Name = enemy.Name.ToString(),
            HealthPoints = enemy.HealthPoints,
            AttackDamage = enemy.AttackDamage,
            SpeedAttack = enemy.SpeedAttack,
            RewardMoney = enemy.RewardMoney,
        };
    }

    public static Enemy ToDomain(EnemyPersistenceModel model)
    {
        EnemyName name = new EnemyName(model.Name);
        int healthPoints = model.HealthPoints;
        int attackDamage = model.AttackDamage;
        int speedAttack = model.SpeedAttack;
        int rewardMoney = model.RewardMoney;

        return new Enemy(name, healthPoints, attackDamage, speedAttack, rewardMoney);

    }
}
