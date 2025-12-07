using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class DesertScenesAdder : IScenesAdder
{

    private static Biome getBiome()
    {
        return Biome.Desert;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();




        scenes.AddRange(scenesToAdd);
    }
}