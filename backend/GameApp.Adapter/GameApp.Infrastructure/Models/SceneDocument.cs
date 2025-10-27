using GameApp.Domain.Enumerates;
using GameApp.Infrastructure.Enumerates;

namespace GameApp.Infrastructure.Models;

public class SceneDocument
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; }
    public SceneType SceneType { get; set; }

    public Biome? BiomeToChange { get; set; }
    public EnemyDocument? Enemy { get; set; }
    public List<SceneDocument>? PossibleScenes { get; set; }
    public ItemDocument? RewardItem { get; set; }

    public List<ItemDocument>? CharacterItemsOffer { get; set; }
    public int? CharacterMoneyOffer { get; set; }
    public List<ItemDocument>? MerchantItemsOffer { get; set; }
    public int? MerchantMoneyOffer { get; set; }
}
