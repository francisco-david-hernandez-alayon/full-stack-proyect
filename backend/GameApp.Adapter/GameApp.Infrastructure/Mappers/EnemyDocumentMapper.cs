using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class EnemyDocumentMapper
{
    public static EnemyDocument ToDocument(Enemy enemy)
    {
        return new EnemyDocument
        {
            Id = enemy.GetGuid(),
            Difficulty = enemy.GetDifficulty(),
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            CriticalDamage = CriticalDamageDocumentMapper.ToDocument(enemy.GetCriticalDamage()),
            MoneyReward = enemy.GetRewardMoney()
        };
    }

    public static Enemy ToDomain(EnemyDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        return new Enemy(
            doc.Id,
            doc.Difficulty,
            new EnemyName(doc.Name),
            doc.HealthPoints,
            doc.DamageAttack,
            doc.SpeedAttack,
            CriticalDamageDocumentMapper.ToDomain(doc.CriticalDamage ?? new CriticalDamageDocument()),
            doc.MoneyReward
        );
    }


    public static EnemyDocument? ToDocumentPosibleNull(Enemy? enemy)
    {
        if (enemy is null)
            return null;

        return ToDocument(enemy);
    }

    public static Enemy? ToDomainPosibleNull(EnemyDocument? doc)
    {
        if (doc is null)
            return null;

        return ToDomain(doc);
    }

}
