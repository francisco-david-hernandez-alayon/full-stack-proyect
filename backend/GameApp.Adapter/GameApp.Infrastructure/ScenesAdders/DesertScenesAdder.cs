using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;

namespace GameApp.Host.scenes;

public class DesertScenesAdder : IScenesAdder
{

    private static Biome getBiome()
    {
        return Biome.desert;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();




        scenes.AddRange(scenesToAdd);
    }
}