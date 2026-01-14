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

        // NOTHING HAPPENS SCENES
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Endless Dunes on Desert"),
            new SceneDescription("You walk across endless sand dunes under the scorching sun. The heat is suffocating, and nothing but sand surrounds you."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Blazing Heat on Desert"),
            new SceneDescription("The sun beats down relentlessly, draining your strength. The desert stretches silently, offering no sign of life."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("False Oasis on Desert"),
            new SceneDescription("In the distance, you spot what seems to be an oasis. As you approach, it fades away, leaving behind only a dry, lifeless tree."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Illusion of a Temple on Desert"),
            new SceneDescription("Far ahead, you glimpse the silhouette of an ancient temple. Moments later, the vision dissolves, revealing nothing but shifting sand."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Desert Remains on Desert"),
            new SceneDescription("You come across a decomposed corpse, long stripped of belongings. The desert has claimed yet another traveler."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Silent Horizon on Desert"),
            new SceneDescription("The horizon shimmers under the heat, distorting your vision. No movement, no sound—only the vast silence of the desert."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Buried Ruins on Desert"),
            new SceneDescription("Partially buried stones emerge from the sand, hinting at forgotten ruins. After searching for a while, you find nothing of value."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Whispering Wind on Desert"),
            new SceneDescription("The hot wind howls across the dunes, carrying faint whispers that vanish as soon as you stop to listen."),
            biome
        ));



        // ITEM SCENE – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Dead Camel Remains on Desert"),
            new SceneDescription("You find the body of a dead camel, dried by the sun. From its remains, you manage to collect some spoiled meat."),
            biome,
            AtributteItemsAdders.RottenMeat
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Abandoned Saddlebag on Desert"),
            new SceneDescription("A forgotten saddlebag lies half-buried in the sand. Inside, you discover a piece of rotten meat."),
            biome,
            AtributteItemsAdders.RottenMeat
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Fallen Traveler on Desert"),
            new SceneDescription("A traveler, recently claimed by the heat, lies motionless in the sand. Tucked beneath his arm, you find a loaf of bread, still in decent condition."),
            biome,
            AtributteItemsAdders.Bread
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Buried Temple Chest on Desert"),
            new SceneDescription("You uncover the entrance of a buried temple, blocked by sand. Nearby, a small chest contains mostly useless relics, but a health potion rests at the bottom."),
            biome,
            AtributteItemsAdders.HealthPotion
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Collapsed Temple Escape on Desert"),
            new SceneDescription("You accidentally trigger a hidden trap beneath the dunes. After dodging spikes and deadly mechanisms, you reach a valuable shelf holding a mysterious vial. As you take it, the temple begins to collapse, and you narrowly escape."),
            biome,
            AtributteItemsAdders.VialVitality
        ));


        // ITEM SCENE – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Wooden Stick on Desert"),
            new SceneDescription("Half-buried in the sand, you find a dry wooden stick. It is crude, but it could still serve as a weapon."),
            biome,
            AttackItemsAdders.WoodenStick
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Old Stone Sword on Desert"),
            new SceneDescription("You come across a fallen adventurer, missing an arm and his right eye. Beside him lies an old stone sword, worn but usable."),
            biome,
            AttackItemsAdders.OldStoneSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Abandoned Sword on Desert"),
            new SceneDescription("A dead scorpion lies pierced by a sword. After making sure the creature is truly dead, you take the weapon for yourself."),
            biome,
            AttackItemsAdders.OldStoneSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Sharp Stone on Desert"),
            new SceneDescription("Among scattered rocks, you find a sharp stone shaped by the harsh winds of the desert. Simple, but deadly in close combat."),
            biome,
            AttackItemsAdders.SharpStone
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Buried Knight Sword on Desert"),
            new SceneDescription("Only the blade of a sword protrudes from the sand atop a dune. You pull it free, revealing a finely crafted knight sword."),
            biome,
            AttackItemsAdders.KnightSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Stealing Farael's Cursed Scythe"),
            new SceneDescription("Beyond the last great dune, a majestic temple reveals itself. Inside, long since looted, you uncover a hidden chamber where a mummy rests beside a scythe glowing with an unnatural light. You seize the weapon just as the temple begins to collapse, escaping with the scythe alone—and the unsettling feeling that the mummy once belonged to something far greater."),
            biome,
            AttackItemsAdders.FaraelCursedScythe
        ));


        // ENEMY SCENE
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Scorpion Ambush on Desert"),
            new SceneDescription("The sand suddenly shifts beneath your feet as a scorpion bursts out of the ground, ready to strike."),
            biome,
            EnemysAdder.Scorpion
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Scorpion Infestation on Desert"),
            new SceneDescription("From the hollow remains of a corpse, a scorpion crawls out, disturbed by your presence."),
            biome,
            EnemysAdder.Scorpion
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Desert Bandit Trap on Desert"),
            new SceneDescription("A man dismounts from a camel and asks for your help. Moments later, he draws a knife, revealing his true intentions."),
            biome,
            EnemysAdder.Bandit
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Sandcrawler Emergence on Desert"),
            new SceneDescription("In the darkness, you glimpse a tail and sharp teeth. Dismissing it as nothing, you are caught off guard as a sandcrawler erupts from the ground before you."),
            biome,
            EnemysAdder.Sandcrawler
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Red Dagger Ambush on Desert"),
            new SceneDescription("A chest catches your attention, but as you open it, a net is thrown toward you. You dodge just in time as a member of the Red Dagger lunges at you with a blade."),
            biome,
            EnemysAdder.RedDaggerAssassin
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Giant Sandworm on Desert"),
            new SceneDescription("The ground trembles violently as an enormous sandworm emerges, its massive body tearing through the dunes."),
            biome,
            EnemysAdder.GiantSandworm
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Farael's Curse Appears"),
            new SceneDescription("As you rest, a whisper echoes in your mind: 'I will have my revenge...' You later stumble upon the brutally slain bodies of mercenaries. When you attempt to take their gold, a voice hisses, 'You too,' as a malignant spirit manifests before you."),
            biome,
            EnemysAdder.FaraelCurse
        ));



        // TRADE SCENE
        scenesToAdd.Add(new TradeScene(
            new SceneName("Wandering Camel Merchant on Desert"),
            new SceneDescription("You spot a lone traveler riding a camel across the dunes. As you approach, he offers to sell you a few goods he carries for survival in the desert."),
            biome,
            merchantMoneyToSpent: 25,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Apple,
                AtributteItemsAdders.HealingHerbs,
                AttackItemsAdders.OldStoneSword,
            },
            profitMerchantMargin: 2
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Isolated Desert Hermit on Desert"),
            new SceneDescription("You discover a small cabin standing alone in the desert. Its inhabitant is unsettling and clearly unstable, yet he promises surprisingly good deals if you are willing to trade."),
            biome,
            merchantMoneyToSpent: 30,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Bread,
                AtributteItemsAdders.HealthPotion,
                AttackItemsAdders.StoneAxe,
            },
            profitMerchantMargin: 4
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Dark Trafficker encounter on Desert"),
            new SceneDescription("A hooded figure approaches you, claiming to be part of the Dark Traffickers. He agrees to sell valuable items, as long as you do not ask where they came from."),
            biome,
            merchantMoneyToSpent: 50,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.HealingHerbs,
                AtributteItemsAdders.CheeseCake,
                AttackItemsAdders.Mace,
            },
            profitMerchantMargin: 5
        ));


        scenesToAdd.Add(FinalScene);

        scenes.AddRange(scenesToAdd);
    }
}