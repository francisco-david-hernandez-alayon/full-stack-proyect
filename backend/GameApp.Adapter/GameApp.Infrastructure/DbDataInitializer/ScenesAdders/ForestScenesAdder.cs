using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class ForestScenesAdder : IScenesAdder
{
    // FINAL SCENE FOREST
    private static readonly NothingHappensScene _finalSceneTreasureForest =
    new NothingHappensScene(
        new SceneName("Final Scene Treasure Forest"),
        new SceneDescription("After a long journey, you finally reach the hidden treasure. Your adventure has come to an end, and unimaginable riches now lie before you."),
        getBiome()
    );

    public static NothingHappensScene FinalSceneTreasureForest => _finalSceneTreasureForest;


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
            new SceneName("Forest attack item 1"),
            new SceneDescription("While exploring the forest, you stumble upon a wooden sword lying on the ground."),
            biome,
            AttackItemsAdders.WoodSword
        ));


        // Enemy Scene 
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Forest Slime Encounter"),
            new SceneDescription("A small green slime jumps toward you from behind the bushes."),
            biome,
            EnemysAdder.Slime
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Forest Goblin Ambush"),
            new SceneDescription("A sneaky goblin appears from the shadows and prepares to attack."),
            biome,
            EnemysAdder.Goblin
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Forest Skeleton Warrior"),
            new SceneDescription("A skeleton warrior rises from the ground, rattling its old bones."),
            biome,
            EnemysAdder.Skeleton
        ));



        scenesToAdd.Add(FinalSceneTreasureForest);

        scenes.AddRange(scenesToAdd);
    }
}