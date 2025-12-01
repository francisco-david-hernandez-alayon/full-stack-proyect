namespace GameApp.Adapter.Api.dtos.EnemysDtos;

public class EnemyUpdateRequestDto
{
    public string Name { get; set; } = default!;
    public int HealthPoints { get; set; }
    public int DamageAttack { get; set; }
    public int SpeedAttack { get; set; }
    public int MoneyReward { get; set; }
}
