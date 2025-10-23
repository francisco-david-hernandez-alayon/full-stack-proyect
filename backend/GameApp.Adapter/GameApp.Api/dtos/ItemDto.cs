using GameApp.Api.Enumerates;

namespace GameApp.Api.dtos;

public class ItemDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ItemType ItemType { get; set; } = default!; 

    // optional depending on the type of item:
    // AtributeItem
    public int? HealthPointsReceived { get; set; }
    public int? FoodPointsReceived { get; set; }

    // AttackItem
    public int? AttackDamage { get; set; }
    public int? SpeedAttack { get; set; }
    public int? Durability { get; set; }
}
