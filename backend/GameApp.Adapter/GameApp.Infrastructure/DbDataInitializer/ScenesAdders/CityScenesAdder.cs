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
        
        
        // NOTHING HAPPENS SCENES
        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Quiet Street on City"),
            new SceneDescription("You walk down a narrow city street. Merchants and townsfolk go about their business, but nothing out of the ordinary happens."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Empty Market Alley on City"),
            new SceneDescription("Passing through an empty market alley, you see abandoned stalls and hear only the distant chatter of the city. No events disturb your path."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Cobblestone Square on City"),
            new SceneDescription("A wide cobblestone square opens before you, lined with old buildings. People pass by, but your journey remains uneventful."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Sunlit Courtyard on City"),
            new SceneDescription("A quiet courtyard basks in the afternoon sun. Children play nearby and merchants clean their shops, yet nothing significant occurs."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Rooftop View on City"),
            new SceneDescription("From a small stairway, you reach a rooftop overlooking the city. The streets below bustle with life, but your path continues without interruption."),
            biome
        ));

        scenesToAdd.Add(new NothingHappensScene(
            new SceneName("Whispers of the Cemetery on City"),
            new SceneDescription("As you walk past a narrow alley, you overhear someone telling a story about a ghost that appeared in the cemetery. The conversation ends abruptly, leaving only silence and curiosity behind."),
            biome
        ));




        // ITEM SCENE – Attribute Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Rotten Meat on City"),
            new SceneDescription("While exploring an abandoned alley, you notice a piece of meat left in a discarded crate. It looks questionable, but still edible."),
            biome,
            AtributteItemsAdders.RottenMeat
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Leftover Bread on City"),
            new SceneDescription("A friendly baker waves you over and, seeing you wandering the streets, hands you a loaf of bread that he has in excess."),
            biome,
            AtributteItemsAdders.Bread
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Found Bread on City"),
            new SceneDescription("While passing through a narrow alley, you spot a loaf of bread lying on the ground. It seems someone dropped it in haste, and you decide to take it."),
            biome,
            AtributteItemsAdders.Bread
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Cooked Meat on City"),
            new SceneDescription("A street vendor thanks you for helping an old woman carry her parcels. In gratitude, they hand you a piece of cooked meat."),
            biome,
            AtributteItemsAdders.CookedMeat
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Strong Beer on City"),
            new SceneDescription("You give directions to a lost traveler who asks about a distant tavern. In thanks, he hands you a mug of strong beer, smiling warmly before hurrying off."),
            biome,
            AtributteItemsAdders.StrongBeer
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Cheesecake on City"),
            new SceneDescription("Someone rushes past you, spilling some of their belongings. Among the chaos, a small cheesecake lands at your feet, and you decide to take it."),
            biome,
            AtributteItemsAdders.CheeseCake
        ));

        

        // ITEM SCENE – Attack Item
        scenesToAdd.Add(new ItemScene(
            new SceneName("Wooden Stick on City"),
            new SceneDescription("A simple wooden stick lies abandoned near a trash heap. Though ordinary, it could serve as a makeshift weapon."),
            biome,
            AttackItemsAdders.WoodenStick
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Wooden Bludgeon on City"),
            new SceneDescription("A thick wooden club rests behind a marketplace stall. It looks heavy and capable of delivering a strong blow."),
            biome,
            AttackItemsAdders.WoodenBludgeon
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Old Stone Sword on City"),
            new SceneDescription("Leaning against a broken cart, an old stone sword catches your eye. Its edge is worn, but it could still be useful in combat."),
            biome,
            AttackItemsAdders.OldStoneSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Knight Sword on City"),
            new SceneDescription("Passing behind a soldier's barracks, you notice swords being gathered. You consider taking one without being noticed, weighing the risk carefully."),
            biome,
            AttackItemsAdders.KnightSword
        ));

        scenesToAdd.Add(new ItemScene(
            new SceneName("Iron Daggers on City"),
            new SceneDescription("On a dimly lit alley table, a set of iron daggers lie forgotten. Sleek and sharp, they seem ready for a swift strike."),
            biome,
            AttackItemsAdders.IronDaggers
        ));



        // ENEMY SCENE
        scenesToAdd.Add(new EnemyScene(
            new SceneName("Giant Rat Problem on City"),
            new SceneDescription("Someone approaches you, asking for help to deal with the rats infesting their kitchen."),
            biome,
            EnemysAdder.GiantRat
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Alley Rat Attack on City"),
            new SceneDescription("You step into a narrow alley and a giant rat leaps out to attack you."),
            biome,
            EnemysAdder.GiantRat
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Bandit Ambush on City"),
            new SceneDescription("A bandit steps out from the shadows, brandishing a knife and demanding your valuables."),
            biome,
            EnemysAdder.Bandit
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Nighttime Robbery on City"),
            new SceneDescription("While walking at night, a thief suddenly tries to rob you in a poorly lit street."),
            biome,
            EnemysAdder.Thieve
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Chased Thief on City"),
            new SceneDescription("During the day, you notice someone has stolen from you. You chase them down an alley, and they are forced to fight as there's no escape."),
            biome,
            EnemysAdder.Thieve
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Drunken Knight Attack on City"),
            new SceneDescription("You accidentally bump into a royal knight who is clearly drunk. He ignores your apologies and attacks without hesitation."),
            biome,
            EnemysAdder.RoyalKnight
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Elite Guard Confrontation on City"),
            new SceneDescription("Shouting 'Halt! You are under arrest!' an elite royal guard confronts you, claiming you are accused of murdering a duke. You try to explain, but the guard insists you come with them, hinting at the dangerous enemies you've made."),
            biome,
            EnemysAdder.EliteGuard
        ));

        scenesToAdd.Add(new EnemyScene(
            new SceneName("Ghost of William Kinon on City"),
            new SceneDescription("You arrive at the city cemetery, slightly tipsy from the tavern. Stumbling into a grave, you notice it belongs to the greatest knight of these lands, William Kinon. Suddenly, a voice behind you whispers, 'I will not let you leave alive after defiling my legacy.'"),
            biome,
            EnemysAdder.WilliamKinonGhost
        ));



        // TRADE SCENE
        scenesToAdd.Add(new TradeScene(
            new SceneName("Poor Vendor on City"),
            new SceneDescription("A humble street vendor waves you over. His wares are limited, but he offers some food and a simple wooden stick."),
            biome,
            merchantMoneyToSpent: 10,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.RottenMeat,
                AttackItemsAdders.WoodenStick,
            },
            profitMerchantMargin: 1
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Butcher on City"),
            new SceneDescription("A local butcher invites you to see his fresh cuts. He offers a variety of meats, including cooked pieces and a hearty lamb stew."),
            biome,
            merchantMoneyToSpent: 20,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.RottenMeat,
                AtributteItemsAdders.CookedMeat,
                AtributteItemsAdders.CookedMeat,
                AtributteItemsAdders.LambStew,
            },
            profitMerchantMargin: 3
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Blacksmith on City"),
            new SceneDescription("A skilled blacksmith shows you his selection of swords, daggers, and spears, forged to perfection and ready for any battle."),
            biome,
            merchantMoneyToSpent: 35,
            merchantItemsOffer: new List<Item>
            {
                AttackItemsAdders.OldStoneSword,
                AttackItemsAdders.KnightSword,
                AttackItemsAdders.IronDaggers,
                AttackItemsAdders.IronSpear,
            },
            profitMerchantMargin: 7
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Tavern Offerings on City"),
            new SceneDescription("In a bustling tavern, a cheerful bartender offers you some food and strong beer as you chat with the patrons."),
            biome,
            merchantMoneyToSpent: 0,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.CookedMeat,
                AtributteItemsAdders.StrongBeer,
                AtributteItemsAdders.StrongBeer,
            },
            profitMerchantMargin: 5
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Novice Merchant on City"),
            new SceneDescription("A newly opened merchant, eager but inexperienced, greets you warmly and shows his modest stock of food and basic weapons."),
            biome,
            merchantMoneyToSpent: 25,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.Bread,
                AtributteItemsAdders.HealingHerbs,
                AttackItemsAdders.OldStoneSword,
                AttackItemsAdders.WoodenBludgeon,
            },
            profitMerchantMargin: 3
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Suspicious Peddler on City"),
            new SceneDescription("A streetwise peddler with slick manners tries to sell you goods of questionable origin. His charisma is strong, but you sense caution is needed."),
            biome,
            merchantMoneyToSpent: 15,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.RottenMeat,
                AtributteItemsAdders.HealthPotion,
                AttackItemsAdders.OldStoneSword,
                AttackItemsAdders.KnightSword,
            },
            profitMerchantMargin: 15
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Suspicious Alchemist on City"),
            new SceneDescription("In a crumbling shop wedged between new buildings, a friendly but strange alchemist offers you potions and tools that might prove invaluable."),
            biome,
            merchantMoneyToSpent: 10,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.HealthPotion,
                AtributteItemsAdders.VialVitality,
                AttackItemsAdders.BlacksmithsHammer,
            },
            profitMerchantMargin: 10
        ));

        scenesToAdd.Add(new TradeScene(
            new SceneName("Dark Trafficker Encounter on City"),
            new SceneDescription("In a shadowy alley, a hooded figure approaches. When asked who they are, they reply cryptically and offer rare items, hinting that it's better not to question their origins."),
            biome,
            merchantMoneyToSpent: 50,
            merchantItemsOffer: new List<Item>
            {
                AtributteItemsAdders.HealingHerbs,
                AttackItemsAdders.Mace,
                AttackItemsAdders.WilliamKinonSword,
            },
            profitMerchantMargin: 5
        ));



        scenesToAdd.Add(FinalScene);
        
        scenes.AddRange(scenesToAdd);
    }
}