namespace GameApp.Infrastructure.Data.Models;

public class EnemyPersistenceModel
{
    public string Name { get; set; } = default!;
    public int HealthPoints { get; set; }
    public int AttackDamage { get; set; }
    public int SpeedAttack { get; set; }
    public int RewardMoney { get; set; }
}
