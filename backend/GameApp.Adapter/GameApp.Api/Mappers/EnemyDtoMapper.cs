using GameApp.Api.dtos;
using GameApp.Api.Enumerates;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Api.Mappers;

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
            HealthPoints = enemy.GetHealtPoints(),
            DamageAttack = enemy.GetDamageAttack(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetMoneyReward(),
        };
    }

}
