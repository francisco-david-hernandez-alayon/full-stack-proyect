using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class ForestScenesAdder : IScenesAdder
{
    // FINAL SCENE
    public static readonly FinalScene FinalScene =
    new FinalScene(
        new SceneName("Final Scene Treasure Forest"),
        new SceneDescription("After a long journey, you finally reach the hidden treasure. Your adventure has come to an end, and unimaginable riches now lie before you."),
        getBiome()
    );

    public static readonly NothingHappensScene InitialScene =
    new NothingHappensScene(
        new SceneName("Wake Up in Forest"),
        new SceneDescription("You let yourself fall asleep and when you open your eyes you see the leafy treetops above you"),
        getBiome()
    );


    private static Biome getBiome()
    {
        return Biome.Forest;
    }

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();
        Biome biome = getBiome();


        // NOTHING HAPPENS SCENES
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("A Calm Forest Path"),
            new SceneDescription("You continue along a quiet forest trail. The sounds of birds and rustling leaves surround you, but nothing unusual catches your attention."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Through the Shaded Grove"),
            new SceneDescription("Walking beneath the dense canopy, shadows dance across the forest floor. All seems peaceful, and the forest offers no surprises."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Along the Whispering Trees"),
            new SceneDescription("The wind whispers through the trees as you move forward. You notice the subtle movements of wildlife, but nothing disturbs your path."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Among the Tranquil Woods"),
            new SceneDescription("The forest stretches serenely around you, filled with familiar sights and sounds. For now, your journey passes without incident."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Mist Between the Trees"),
            new SceneDescription("A thin mist weaves between the trees, softening the forest around you. Your steps echo quietly on damp ground, but nothing emerges from the haze."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Old Footprints on Forest Soil"),
            new SceneDescription("You notice old footprints pressed into the forest soil, half-erased by time and rain. Whoever passed through is long gone, leaving the woods silent once more."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Glimpse of Golden Light"),
            new SceneDescription("A faint, almost celestial sound reaches your ears, and you catch sight of a golden glimmer deep among the trees. As you rush forward, you stumble, and the radiant vision vanishes as quickly as it appeared."),
            biome
        ));




        // ITEM SCENES – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("A Juicy Apple on Forest"),
            new SceneDescription("You spot a bright red apple hanging from a low branch, perfect for a quick snack."),
            biome,
            AtributteItemsAdders.Apple
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Handful of Berries on Forest"),
            new SceneDescription("A cluster of ripe berries peeks out from the undergrowth, inviting you to taste them."),
            biome,
            AtributteItemsAdders.Berry
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Healing Herbs on Forest"),
            new SceneDescription("You notice some green herbs with a faint aroma of recovery growing along the forest floor."),
            biome,
            AtributteItemsAdders.HealingHerbs
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Bitter Root on Forest"),
            new SceneDescription("A twisted, bitter root emerges from the soil. Despite its sharp taste, it could restore some energy."),
            biome,
            AtributteItemsAdders.BitterRoot
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Potion Among Remains on Forest"),
            new SceneDescription("Amid the remains of a fallen adventurer, you find a health potion, still intact and ready to use."),
            biome,
            AtributteItemsAdders.HealthPotion
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Golden Apple Beneath the Golden Tree"),
            new SceneDescription("Under the roots of a suspicious yet majestic golden tree, you glimpse a shining apple. Its aura promises great vitality and power."),
            biome,
            AtributteItemsAdders.GoldenApple
        ));





        // ITEM SCENES – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Sharp Branch on Forest"),
            new SceneDescription("You spot a jagged branch on the ground and decide to cut it, taking it with you as a makeshift weapon."),
            biome,
            AttackItemsAdders.WoodenStick
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Sharpened Stone on Forest"),
            new SceneDescription("Among the rocks, you find one with a naturally sharp edge and decide to carve it into a weapon."),
            biome,
            AttackItemsAdders.SharpStone
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Fallen Warrior's Sword on Forest"),
            new SceneDescription("A fallen warrior lies here, and you claim his old stone sword, feeling its weight and history in your hands."),
            biome,
            AttackItemsAdders.OldStoneSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Knight's Sword on Forest"),
            new SceneDescription("A dying knight offers you his sword. Its balance and craftsmanship are evident, promising both reliability and power."),
            biome,
            AttackItemsAdders.KnightSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Broken Spear on Forest"),
            new SceneDescription("In an abandoned house, you find a partially broken spear. Using nearby tools, you repair it, making it ready for combat."),
            biome,
            AttackItemsAdders.IronSpear
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Sacred Branch on Forest"),
            new SceneDescription("A branch glimmers with a mysterious light. Its shape and color hint at the legendary sacred forest, yet somehow it has come into your possession."),
            biome,
            AttackItemsAdders.SacredForestBranch
        ));



        // ENEMY SCENES
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Green Slime on Forest"),
            new SceneDescription("A small green slime leaps toward you from behind the bushes, oozing with mischievous intent."),
            biome,
            EnemysAdder.Slime
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Wolf on Forest"),
            new SceneDescription("A lone wolf emerges from the trees, baring its teeth and preparing to pounce."),
            biome,
            EnemysAdder.Wolf
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Goblin Ambush on Forest"),
            new SceneDescription("You spot a goblin hiding behind a tree, ready to ambush and steal from unsuspecting travelers."),
            biome,
            EnemysAdder.Goblin
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Bandit on Forest"),
            new SceneDescription("A bandit steps out from the shadows, brandishing a rusty dagger and a greedy glint in his eyes."),
            biome,
            EnemysAdder.Bandit
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Possessed Skeleton on Forest"),
            new SceneDescription("You accidentally step on a magical trap among some ruins, awakening a possessed skeleton that fiercely defends its resting place."),
            biome,
            EnemysAdder.PossessedSkeleton
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Bear on Forest"),
            new SceneDescription("A massive bear crashes through the underbrush, growling as it sees you intruding on its territory."),
            biome,
            EnemysAdder.Bear
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Stone Golem on Forest"),
            new SceneDescription("A huge stone golem moves among the trees; its rocky limbs move with surprising speed and strength for its size, but you can't admire it properly as it seems to have you in its sights."),
            biome,
            EnemysAdder.StoneGolem
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Forest Stalker on Forest"),
            new SceneDescription("In the shadows of the night, glowing eyes peer at you from the darkness, following your every move. Your hope that they will disappear vanishes when they suddenly attack."),
            biome,
            EnemysAdder.ForestStalker
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Forest Wyvern on Forest"),
            new SceneDescription("A distant roar shakes the forest. Suddenly, a massive wyvern swoops overhead, landing behind you with a thunderous snort, clearly provoked by your presence."),
            biome,
            EnemysAdder.Wyvern
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Sacred Forest Guardian"),
            new SceneDescription("As you venture deeper, a chilling voice echoes: 'You should not be here...' Something stirs in the shadows, guarding the sacred heart of the forest. You turn quickly, and it stares into your eyes."),
            biome,
            EnemysAdder.SacredForestGuardian
        ));



        // TRADE SCENES
        scenesToAdd.Add(new TradeScene(
            new SceneName("Humble Merchant on Forest"),
            new SceneDescription("An older merchant, appearing modest and with limited goods, offers to sell you some of his wares."),
            biome,
            merchantMoneyToSpent: 10,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Bread,
                AttackItemsAdders.OldStoneSword,
            },
            profitMerchantMargin: 2
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Lumberjack Trader on Forest"),
            new SceneDescription("As you walk, you notice a lumberjack at work. Intrigued by his craft, he offers to sell you some of his tools."),
            biome,
            merchantMoneyToSpent: 20,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Berry,
                AttackItemsAdders.StoneAxe,
                AttackItemsAdders.BlacksmithsHammer,
            },
            profitMerchantMargin: 3
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Lost Noble Merchant on Forest"),
            new SceneDescription("A finely dressed merchant appears lost in the forest. He offers you a discount if you tell him the way back to the city, and shows you his luxurious wares."),
            biome,
            merchantMoneyToSpent: 35,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.CookedMeat,
                AtributteItemsAdders.HealthPotion,
                AttackItemsAdders.OldStoneSword,
                AttackItemsAdders.KnightSword,
            },
            profitMerchantMargin: 5
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Dark Trafficker encounter on Forest"),
            new SceneDescription("A hooded merchant approaches with great interest and offers rare items for sale; from his clothing, one can guess that he belongs to the dark traffickers."),
            biome,
            merchantMoneyToSpent: 50,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.LambStew,
                AttackItemsAdders.Mace,
            },
            profitMerchantMargin: 5
        ));



        scenesToAdd.Add(FinalScene);
        scenesToAdd.Add(InitialScene);

        scenes.AddRange(scenesToAdd);
    }
}