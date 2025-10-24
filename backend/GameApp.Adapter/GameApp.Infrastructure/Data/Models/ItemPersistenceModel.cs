namespace GameApp.Infrastructure.Data.Models;

public class ItemPersistenceModel
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ItemType { get; set; } = default!;

    // Optional propierties
    public int? AttackDamage { get; set; }
    public int? SpeedAttack { get; set; }
    public int? Durability { get; set; }

    public int? HealthPointsReceived { get; set; }
    public int? FoodPointsReceived { get; set; }
}
