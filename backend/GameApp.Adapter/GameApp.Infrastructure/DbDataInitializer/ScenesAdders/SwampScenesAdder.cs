using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class SwampScenesAdder : IScenesAdder
{

    // FINAL SCENE
    public static readonly FinalScene FinalScene =
    new FinalScene(
        new SceneName("Final Scene Swamp ring"),
        new SceneDescription("After a viscous puddle you manage to glimpse the corpse of a warrior who carries the very valuable ring that you were looking for."),
        getBiome()
    );

    private static Biome getBiome()
    {
        return Biome.Swamp;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();

        
        // Nothing Scene
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Nothing Happens Swamp"),
            new SceneDescription("You move carefully through the muddy swamp, but nothing stirs around you."),
            biome
        ));


        // Item Scene – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Swamp Attribute Item"),
            new SceneDescription("Near a murky pool, you find an apple that somehow survived the damp environment."),
            biome,
            AtributteItemsAdders.Apple
        ));


        // Item Scene – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Swamp Attack Item 1"),
            new SceneDescription("Half-sunk in the swamp water, you recover a rusty but usable steel axe."),
            biome,
            AttackItemsAdders.SteelAxe
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Swamp Attack Item 2"),
            new SceneDescription("You see an old wooden sword in a puddle"),
            biome,
            AttackItemsAdders.WoodSword
        ));


        // Enemy Scene
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Swamp Skeleton Encounter"),
            new SceneDescription("A skeleton rises from the murky waters, its bones covered in swamp filth."),
            biome,
            EnemysAdder.Skeleton
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Swamp Slime Encounter"),
            new SceneDescription("A slime appears out of nowhere and approaches in a hostile manner."),
            biome,
            EnemysAdder.Slime
        ));


        // Trade Scene
        scenesToAdd.Add(new TradeScene(
            new SceneName("Swamp Merchant Encounter"),
            new SceneDescription("A hooded merchant stands on a wooden platform, selling goods adapted for the swamp."),
            biome,
            merchantMoneyToSpent: 90,
            merchantItemsOffer: new List<Item>
            {
                AttackItemsAdders.Dagger,
                AtributteItemsAdders.HealthPotion,
                AtributteItemsAdders.Bread
            },
            profitMerchantMargin: 4
        ));


        scenesToAdd.Add(FinalScene);

        scenes.AddRange(scenesToAdd);
    }
}