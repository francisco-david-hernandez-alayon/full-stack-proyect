using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Adapter.Infrastructure.Models;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class EnemyDocumentMapper
{
    public static EnemyDocument ToDocument(Enemy enemy)
    {
        return new EnemyDocument
        {
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetRewardMoney()
        };
    }

    public static Enemy ToDomain(EnemyDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        return new Enemy(
            new EnemyName(doc.Name),
            doc.HealthPoints,
            doc.DamageAttack,
            doc.SpeedAttack,
            doc.MoneyReward
        );
    }


    public static EnemyDocument? ToDocumentPosibleNull(Enemy? enemy)
    {
        if (enemy is null)
            return null;

        return new EnemyDocument
        {
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetRewardMoney()
        };
    }

    public static Enemy? ToDomainPosibleNull(EnemyDocument? doc)
    {
        if (doc is null)
            return null;

        return new Enemy(
            new EnemyName(doc.Name),
            doc.HealthPoints,
            doc.DamageAttack,
            doc.SpeedAttack,
            doc.MoneyReward
        );
    }

}
