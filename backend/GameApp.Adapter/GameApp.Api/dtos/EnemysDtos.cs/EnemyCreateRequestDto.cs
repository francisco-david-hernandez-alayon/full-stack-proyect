using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Api.dtos.EnemysDtos;

public class EnemyCreateRequestDto
{
    public EnemyDifficulty Difficulty  { get; set; }
    public string Name { get; set; } = default!;
    public int HealthPoints { get; set; }
    public int DamageAttack { get; set; }
    public int SpeedAttack { get; set; }
    public int MoneyReward { get; set; }
}
