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


        // NOTHING HAPPENS SCENES
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Thick Mist on Swamp"),
            new SceneDescription("A dense fog surrounds you, muffling every sound. You advance slowly, feeling watched, but nothing reveals itself."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Rotten Waters on Swamp"),
            new SceneDescription("You walk through shallow, foul-smelling waters. The ground shifts beneath your feet, yet nothing rises to challenge you."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Whispers in the Reeds on Swamp"),
            new SceneDescription("The reeds sway as if whispering your name. You stop and listen, but the voices fade, leaving only silence."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Abandoned Marsh Path on Swamp"),
            new SceneDescription("You follow a narrow path of mud and broken wood. Signs of past travelers remain, but none are still alive."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Still Waters on Swamp"),
            new SceneDescription("The swamp becomes unnervingly calm. The water is completely still, reflecting the dark sky as you move on unharmed."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Distant Roars on Swamp"),
            new SceneDescription("A ferocious roar echoes through the swamp, followed by desperate human screams shouting that the monster has come. Minutes pass in tense silence, and suddenly everything fades as if it never happened."),
            biome
        ));



        // ITEM SCENES – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Berries on Swamp Roots"),
            new SceneDescription("Near the twisted roots of a half-submerged tree, you spot a cluster of dark berries growing unnaturally close to the murky water. They seem edible, despite the foul surroundings."),
            biome,
            AtributteItemsAdders.Berry
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Healing Herbs in the Marsh"),
            new SceneDescription("Between pools of stagnant water, you recognize healing herbs struggling to grow in the damp soil. Their strong scent suggests they still retain their medicinal properties."),
            biome,
            AtributteItemsAdders.HealingHerbs
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Potion from a Drowned Corpse"),
            new SceneDescription("A bloated corpse floats near the surface of the swamp. Searching it carefully, you find a health potion still sealed and surprisingly intact."),
            biome,
            AtributteItemsAdders.HealthPotion
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Abandoned Boat Supplies"),
            new SceneDescription("An old, half-sunken boat rests among the reeds. Inside, you discover a pot of lamb stew, preserved just enough to still be edible."),
            biome,
            AtributteItemsAdders.LambStew
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Forgotten Swamp Provisions"),
            new SceneDescription("Among scattered crates near a collapsed wooden platform, you find a cheesecake wrapped in cloth. It looks out of place, but hunger makes you consider keeping it."),
            biome,
            AtributteItemsAdders.CheeseCake
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Cursed Fruit of the Swamp"),
            new SceneDescription("The area is filled with corpses, deep bite marks, and dried blood—an unsettling sight. Amid the decay, you notice a small flower bearing a round, dark fruit. Despite its appearance, it smells strangely pleasant, and you take it, sensing it may be useful."),
            biome,
            AtributteItemsAdders.CursedFruit
        ));



        // ITEM SCENES – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Wooden Bludgeon on Swamp"),
            new SceneDescription("A thick wooden club rests half-submerged in the murky water. Though simple, it looks sturdy enough to use in combat."),
            biome,
            AttackItemsAdders.WoodenBludgeon
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Stone Axe on Swamp"),
            new SceneDescription("Partially hidden in the reeds, a stone axe lies abandoned. Its blade is chipped, but it could still deal a heavy blow."),
            biome,
            AttackItemsAdders.StoneAxe
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Knight Sword on Swamp"),
            new SceneDescription("A knight's sword has been left on a moss-covered log, its steel dulled by the swamp waters. It still retains its balanced design for combat."),
            biome,
            AttackItemsAdders.KnightSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Iron Daggers on Swamp"),
            new SceneDescription("A pair of iron daggers lie on a decaying wooden platform. They are small, swift, and deadly in the right hands."),
            biome,
            AttackItemsAdders.IronDaggers
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Iron Spear on Swamp"),
            new SceneDescription("Leaning against a swamp tree, a long iron spear shows signs of wear. Its reach makes it powerful, though handling it requires care."),
            biome,
            AttackItemsAdders.IronSpear
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Dagger of the Swamp Beast"),
            new SceneDescription("You notice a corpse floating in the blood-stained water. Emerging just as you pass, it reveals a strange dagger forged from the claw of an unknown swamp creature. Its speed and strength feel almost unnatural."),
            biome,
            AttackItemsAdders.DaggerSwampBeast
        ));



        // ENEMY SCENES
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Swamp Slime Emergence on Swamp"),
            new SceneDescription("A small, green slime oozes out from the murky waters, jiggling as it advances toward you."),
            biome,
            EnemysAdder.Slime
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Hidden Goblin on Swamp"),
            new SceneDescription("A goblin emerges from behind twisted roots and reeds, grinning as it prepares to ambush you."),
            biome,
            EnemysAdder.Goblin
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Bandit in the Fog on Swamp"),
            new SceneDescription("A bandit steps silently out of the thick swamp mist, brandishing a dagger with malicious intent."),
            biome,
            EnemysAdder.Bandit
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Possessed Skeleton Rising on Swamp"),
            new SceneDescription("From a patch of dark, decayed soil, a skeleton possessed by some unknown force rises to defend its territory."),
            biome,
            EnemysAdder.PossessedSkeleton
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Swamp Caiman from the Water on Swamp"),
            new SceneDescription("Suddenly, a large swamp caiman bursts from the water, its eyes fixed on you with predatory intent."),
            biome,
            EnemysAdder.SwampCaiman
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Swamp Caiman Ambush on Swamp"),
            new SceneDescription("The mud trembles as a swamp caiman emerges from the ground near the water's edge, ready to strike."),
            biome,
            EnemysAdder.SwampCaiman
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Royal Knight Patrol on Swamp"),
            new SceneDescription("A royal knight appears, but after witnessing countless deaths in this swamp, he seems driven mad. With a wild scream of 'Die, beast of the swamp!' he charges at you without hesitation."),
            biome,
            EnemysAdder.RoyalKnight
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Red Dagger Assassin on Swamp"),
            new SceneDescription("From the shadows of the reeds, a hooded assassin with a red dagger watches your every move, preparing to strike."),
            biome,
            EnemysAdder.RedDaggerAssassin
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Stone Golem Guard on Swamp"),
            new SceneDescription("A massive stone golem emerges from a mound of mud and roots, its heavy steps shaking the ground as it advances."),
            biome,
            EnemysAdder.StoneGolem
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Giant Spider Lurking on Swamp"),
            new SceneDescription("You notice movement across the swamp canopy. A giant spider descends silently, its legs clicking ominously as it targets you."),
            biome,
            EnemysAdder.GiantSpider
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Wyvern Patrol on Swamp"),
            new SceneDescription("The distant roar of a wyvern echoes across the swamp. Soon, its massive form swoops overhead, shadowing your path."),
            biome,
            EnemysAdder.Wyvern
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Swamp Beast Attack on Swamp"),
            new SceneDescription("Something moves unnaturally fast through the thick swamp. As you advance, the smell of blood and death grows. Its eyes lock onto yours, and it strikes before you can blink."),
            biome,
            EnemysAdder.SwampBeast
        ));



        // TRADE SCENES
        scenesToAdd.Add(new TradeScene(
            new SceneName("Wary Merchant on Swamp"),
            new SceneDescription("You spot a cautious merchant wading through the murky waters. He offers some basic supplies, wary of the dangers lurking in the swamp."),
            biome,
            merchantMoneyToSpent: 10,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Berry,
                AttackItemsAdders.KnightSword,
            },
            profitMerchantMargin: 1
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Hermit Trader on Swamp"),
            new SceneDescription("A hermit appears near a muddy bank, selling goods salvaged from the swamp. He seems oddly comfortable in this dangerous environment."),
            biome,
            merchantMoneyToSpent: 30,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Bread,
                AtributteItemsAdders.HealthPotion,
                AttackItemsAdders.IronSpear,
            },
            profitMerchantMargin: 3
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Dark Trafficker Encounter on Swamp"),
            new SceneDescription("A hooded figure emerges from the reeds, claiming to be part of the Dark Traffickers. He offers rare and valuable items, but warns not to ask about their origin."),
            biome,
            merchantMoneyToSpent: 50,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Apple,
                AtributteItemsAdders.CheeseCake,
                AtributteItemsAdders.HealthPotion,
                AttackItemsAdders.BlacksmithsHammer,
                AttackItemsAdders.Mace,
            },
            profitMerchantMargin: 5
        ));



        scenesToAdd.Add(FinalScene);

        scenes.AddRange(scenesToAdd);
    }
}