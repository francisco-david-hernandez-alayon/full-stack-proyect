using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Infrastructure.Models;

namespace GameApp.Infrastructure.Mappers;

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
}
