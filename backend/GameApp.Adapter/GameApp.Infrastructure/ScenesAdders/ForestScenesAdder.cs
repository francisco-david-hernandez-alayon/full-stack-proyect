using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Host.scenes;

public class ForestScenesAdder : IScenesAdder
{

    private static Biome getBiome()
    {
        return Biome.forest;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();
        
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Nothing Happens Forest 1"),
            new SceneDescription("You walk for a while, but nothing unusual happens in the forest."),
            biome
        ));

        scenes.AddRange(scenesToAdd);
    }
}