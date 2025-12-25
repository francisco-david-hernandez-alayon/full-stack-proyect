using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Items;
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
        return Biome.Forest;
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

        scenesToAdd.Add(new ItemScene(
            new SceneName("Forest attribute item 1"),
            new SceneDescription("While exploring the forest, you find a fresh apple lying near a tree, still good to eat."),
            biome,
            AtributteItemsAdders.Apple
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Forest attribute item 2"),
            new SceneDescription("As you move deeper among the trees, you discover a small health potion hidden in the undergrowth."),
            biome,
            AtributteItemsAdders.HealthPotion
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

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Forest Wyvern"),
            new SceneDescription("A wyvern emerges from the darkness and stares at you."),
            biome,
            EnemysAdder.Wyvern
        ));

        // Trade scene
        scenesToAdd.Add(new TradeScene(
            new SceneName("Forest Merchant Encounter"),
            new SceneDescription("You stumble upon a traveling merchant in the forest. He offers various goods for trade."),
            biome,
            merchantMoneyToSpent: 50, 
            merchantItemsOffer: new List<Item>
            {
                AttackItemsAdders.WoodSword,
                AttackItemsAdders.IronSword,
            },
            profitMerchantMargin: 15 
        ));




        scenesToAdd.Add(FinalSceneTreasureForest);

        scenes.AddRange(scenesToAdd);
    }
}