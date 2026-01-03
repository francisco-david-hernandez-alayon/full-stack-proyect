using GameApp.Application.Enumerates;
using GameApp.Domain.Enumerates;

public record SceneProbabilitiesByBiome
{
    public static readonly Dictionary<Biome, Dictionary<SceneType, int>> Probabilities =
    new()
    {
        [Biome.City] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 5 },
            { SceneType.Item, 15 },
            { SceneType.Enemy, 20 },
            { SceneType.Trade, 30 },
            { SceneType.ChangeBiome, 30 }
        },

        [Biome.Forest] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 15 },
            { SceneType.Item, 25 },
            { SceneType.Enemy, 30 },
            { SceneType.Trade, 10 },
            { SceneType.ChangeBiome, 20 }
        },

        [Biome.Desert] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 35 },
            { SceneType.Item, 20 },
            { SceneType.Enemy, 20 },
            { SceneType.Trade, 10 },
            { SceneType.ChangeBiome, 15 }
        },

        [Biome.Swamp] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 10 },
            { SceneType.Item, 15 },
            { SceneType.Enemy, 45 },
            { SceneType.Trade, 10 },
            { SceneType.ChangeBiome, 20 }
        }
    };
}