using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

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


        // Item Scene
        scenesToAdd.Add(new ItemScene(
            new SceneName("Forest Encounter 1"),
            new SceneDescription("While exploring the forest, you stumble upon a wooden sword lying on the ground."),
            biome,
            AttackItemsAdders.WoodSword
        ));


        scenes.AddRange(scenesToAdd);
    }
}