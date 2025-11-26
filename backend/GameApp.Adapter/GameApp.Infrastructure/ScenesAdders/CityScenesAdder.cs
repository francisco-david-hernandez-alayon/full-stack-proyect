using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;

namespace GameApp.Host.scenes;

public class CityScenesAdder : IScenesAdder
{
    
    private static Biome getBiome()
    {
        return Biome.city;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();




        scenes.AddRange(scenesToAdd);
    }
}