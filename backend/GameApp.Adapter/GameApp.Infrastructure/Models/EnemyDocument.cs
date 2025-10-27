namespace GameApp.Infrastructure.Models;

public class EnemyDocument
{
    public string Name { get; set; } = default!;
    public int HealthPoints { get; set; }
    public int DamageAttack { get; set; }
    public int SpeedAttack { get; set; }
    public int MoneyReward { get; set; }
}
