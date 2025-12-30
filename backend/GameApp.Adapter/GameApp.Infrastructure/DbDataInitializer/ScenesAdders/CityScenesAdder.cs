using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class CityScenesAdder : IScenesAdder
{

    // FINAL SCENE
    public static readonly FinalScene FinalScene =
    new FinalScene(
        new SceneName("Final Scene City temle"),
        new SceneDescription("Finally you reach the temple hidden beneath the city, where countless riches await you."),
        getBiome()
    );

    private static Biome getBiome()
    {
        return Biome.City;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();
        // Nothing Scene
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Nothing Happens City"),
            new SceneDescription("You walk through the busy streets of the city, blending in with the crowd."),
            biome
        ));


        // Item Scene – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("City Attribute Item"),
            new SceneDescription("A friendly baker hands you a piece of freshly baked bread."),
            biome,
            AtributteItemsAdders.Bread
        ));


        // Item Scene – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("City Attack Item"),
            new SceneDescription("In a blacksmith's stall, you find a well-balanced iron sword for sale."),
            biome,
            AttackItemsAdders.IronSword
        ));


        // Enemy Scene
        scenesToAdd.Add(new EnemyScene(
            new SceneName("City Bandit Encounter"),
            new SceneDescription("A shady bandit tries to ambush you in a narrow alley."),
            biome,
            EnemysAdder.Bandit
        ));


        // Trade Scene
        scenesToAdd.Add(new TradeScene(
            new SceneName("City Merchant Encounter"),
            new SceneDescription("A city merchant displays a wide variety of goods from across the realm."),
            biome,
            merchantMoneyToSpent: 150,
            merchantItemsOffer: new List<Item>
            {
                AttackItemsAdders.IronSword,
                AttackItemsAdders.Dagger,
                AtributteItemsAdders.HealthPotion,
                AtributteItemsAdders.CheeseCake
            },
            profitMerchantMargin: 6
        ));

        scenesToAdd.Add(FinalScene);
        
        scenes.AddRange(scenesToAdd);
    }
}