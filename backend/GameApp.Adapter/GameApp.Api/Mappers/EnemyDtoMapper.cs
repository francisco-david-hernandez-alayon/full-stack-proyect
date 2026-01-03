using GameApp.Adapter.Api.dtos;
using GameApp.Adapter.Api.dtos.EnemysDtos;
using GameApp.Adapter.Api.dtos.OthersDto;
using GameApp.Application.Enumerates;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Api.Mappers;

public static class EnemyDtoMapper
{
    public static Enemy ToDomain(EnemyResponseDto dto)
    {
        // Check nullability
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));

        return new Enemy(dto.Id, dto.Difficulty, new EnemyName(dto.Name), dto.HealthPoints, dto.DamageAttack, dto.SpeedAttack, dto.MoneyReward);
    }

    public static Enemy ToDomainFromCreateRequest(EnemyCreateRequestDto dto)
    {
        return new Enemy(
            dto.Difficulty,
            new EnemyName(dto.Name),
            dto.HealthPoints,
            dto.DamageAttack,
            dto.SpeedAttack,
            dto.MoneyReward
        );
    }

    public static Enemy ToDomainFromUpdateRequest(EnemyUpdateRequestDto dto)
    {
        return new Enemy(
            dto.Difficulty, 
            new EnemyName(dto.Name),
            dto.HealthPoints,
            dto.DamageAttack,
            dto.SpeedAttack,
            dto.MoneyReward
        );
    }



    public static EnemyResponseDto ToDto(Enemy enemy)
    {
        return new EnemyResponseDto
        {
            Id = enemy.GetGuid(),
            Difficulty = enemy.GetDifficulty(),
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetRewardMoney(),
        };
    }


    public static Enemy? ToDomainPosibleNull(EnemyResponseDto? dto)
    {
        if (dto is null)
            return null;

        if (dto.Name is null)
            throw new ArgumentNullException(nameof(dto.Name));

        return new Enemy(
            dto.Id,
            dto.Difficulty, 
            new EnemyName(dto.Name),
            dto.HealthPoints,
            dto.DamageAttack,
            dto.SpeedAttack,
            dto.MoneyReward
        );
    }

    public static EnemyResponseDto? ToDtoPosibleNull(Enemy? enemy)
    {
        if (enemy is null)
            return null;

        return new EnemyResponseDto
        {
            Id = enemy.GetGuid(),
            Difficulty = enemy.GetDifficulty(),
            Name = enemy.GetName().GetName(),
            HealthPoints = enemy.GetHealthPoints(),
            DamageAttack = enemy.GetAttackDamage(),
            SpeedAttack = enemy.GetSpeedAttack(),
            MoneyReward = enemy.GetRewardMoney(),
        };
    }

    public static List<EnemyResponseDto> ToDtoList(IEnumerable<Enemy> enemys)
    {
        return enemys.Select(ToDto).ToList();
    }

}
