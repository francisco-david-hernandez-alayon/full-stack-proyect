using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class DesertScenesAdder : IScenesAdder
{

    // FINAL SCENE
    public static readonly FinalScene FinalScene =
    new FinalScene(
        new SceneName("Final Scene Desert Oasis"),
        new SceneDescription("You finally reach the desert oasis village and can rest peacefully."),
        getBiome()
    );

    private static Biome getBiome()
    {
        return Biome.Desert;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();

        // Nothing Scene
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Nothing Happens Desert"),
            new SceneDescription("The scorching sun beats down as you cross the dunes, but nothing unusual happens."),
            biome
        ));

        // Item Scene – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Desert Attribute Item"),
            new SceneDescription("Half-buried in the sand, you find some bread that is still edible."),
            biome,
            AtributteItemsAdders.Bread
        ));

        // Item Scene – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Desert Attack Item"),
            new SceneDescription("You find an old dagger stuck in the sand, left behind by a previous traveler."),
            biome,
            AttackItemsAdders.Dagger
        ));

        // Enemy Scene
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Desert Bandit Encounter"),
            new SceneDescription("A ruthless bandit emerges from behind a dune, blocking your path."),
            biome,
            EnemysAdder.Bandit
        ));

        // Trade Scene
        scenesToAdd.Add(new TradeScene(
            new SceneName("Desert Merchant Encounter"),
            new SceneDescription("A desert merchant approaches with a camel, offering supplies for weary travelers."),
            biome,
            merchantMoneyToSpent: 80,
            merchantItemsOffer: new List<Item>
            {
                AttackItemsAdders.IronSword,
                AtributteItemsAdders.HealthPotion,
                AtributteItemsAdders.CheeseCake
            },
            profitMerchantMargin: 4
        ));

        scenesToAdd.Add(FinalScene);

        scenes.AddRange(scenesToAdd);
    }
}