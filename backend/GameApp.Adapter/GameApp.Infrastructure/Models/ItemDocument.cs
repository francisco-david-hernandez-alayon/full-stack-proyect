using GameApp.Infrastructure.Enumerates;

namespace GameApp.Infrastructure.Models;

public class ItemDocument
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ItemType ItemType { get; set; }

    public int? HealthPointsReceived { get; set; }
    public int? FoodPointsReceived { get; set; }

    public int? AttackDamage { get; set; }
    public int? SpeedAttack { get; set; }
    public int? Durability { get; set; }
}
