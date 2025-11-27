using GameApp.Adapter.Api.dtos;
using GameApp.Adapter.Api.dtos.OthersDto;
using GameApp.Adapter.Api.Enumerates;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Api.Mappers;

public static class EnemyDtoMapper
{
    public static Enemy ToDomain(EnemyDto dto)
    {
        // Check nullability
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));

        return new Enemy(new EnemyName(dto.Name), dto.HealthPoints, dto.DamageAttack, dto.SpeedAttack, dto.MoneyReward);
    }


    public static EnemyDto ToDto(Enemy enemy)
    {
        return new EnemyDto
        {
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetRewardMoney(),
        };
    }


    public static Enemy? ToDomainPosibleNull(EnemyDto? dto)
    {
        if (dto is null)
            return null;

        if (dto.Name is null)
            throw new ArgumentNullException(nameof(dto.Name));

        return new Enemy(
            new EnemyName(dto.Name),
            dto.HealthPoints,
            dto.DamageAttack,
            dto.SpeedAttack,
            dto.MoneyReward
        );
    }

    public static EnemyDto? ToDtoPosibleNull(Enemy? enemy)
    {
        if (enemy is null)
            return null;

        return new EnemyDto
        {
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetRewardMoney(),
        };
    }

}
