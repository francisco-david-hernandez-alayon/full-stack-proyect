namespace GameApp.Infrastructure.Data.Models;

public class ScenePersistenceModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Biome { get; set; } = default!;
    public string SceneType { get; set; } = default!;

    // Optional propierties
    public string? BiomeToChange { get; set; }
    public string? EnemyJson { get; set; }
    public string? PossibleScenesJson { get; set; }
    public string? RewardItemJson { get; set; }
    public string? CharacterItemsOfferJson { get; set; }
    public int? CharacterMoneyOffer { get; set; }
    public string? MerchantItemsOfferJson { get; set; }
    public int? MerchantMoneyOffer { get; set; }
}
