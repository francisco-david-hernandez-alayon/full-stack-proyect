using System.Text.Json.Serialization;
using GameApp.Adapter.Api.Enumerates;

namespace GameApp.Adapter.Api.dtos.ItemsDto;

public class ItemResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ItemType ItemType { get; set; } = default!; 
    public int TradePrice { get; set; } = 0;

    // optional depending on the type of item:
    // AtributeItem
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HealthPointsReceived { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FoodPointsReceived { get; set; }

    // AttackItem
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? AttackDamage { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? SpeedAttack { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Durability { get; set; }
}
