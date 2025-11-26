using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;

namespace GameApp.Host.scenes;

public class SwampScenesAdder : IScenesAdder
{

    private static Biome getBiome()
    {
        return Biome.swamp;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();




        scenes.AddRange(scenesToAdd);
    }
}