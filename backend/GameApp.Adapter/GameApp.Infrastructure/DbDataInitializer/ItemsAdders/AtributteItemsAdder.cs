using GameApp.Domain.Entities.Items;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

public class AtributteItemsAdders : IItemsAdder
{
    // COMMMON
    public static readonly AtributeItem RottenMeat = new(
        ItemRarity.Common,
        new ItemName("Rotten Meat"),
        new ItemDescription("A spoiled piece of meat that may stave off hunger but harms your health."),
        ItemIcon.RottenMeat,
        tradePrice: 1,
        healthPointsReceived: -5,
        foodPointsReceived: 20
    );

    public static readonly AtributeItem Berry = new(
        ItemRarity.Common,
        new ItemName("Berries"),
        new ItemDescription("A handful of wild berries that look very appetizing and healthy."),
        ItemIcon.Cherry,
        tradePrice: 2,
        healthPointsReceived: 5,
        foodPointsReceived: 20
    );

    public static readonly AtributeItem Bread = new(
        ItemRarity.Common,
        new ItemName("Bread"),
        new ItemDescription("A simple loaf of bread, filling enough to satisfy basic hunger."),
        ItemIcon.Bread,
        tradePrice: 4,
        healthPointsReceived: 0,
        foodPointsReceived: 40
    );

    public static readonly AtributeItem Apple = new(
        ItemRarity.Common,
        new ItemName("Apple"),
        new ItemDescription("A fresh and nutritious apple, commonly consumed as a light meal, although it also provides a small amount of life."),
        ItemIcon.Apple,
        tradePrice: 4,
        healthPointsReceived: 10,
        foodPointsReceived: 30
    );

    public static readonly AtributeItem CookedMeat = new(
        ItemRarity.Common,
        new ItemName("Cooked Meat"),
        new ItemDescription("A well-cooked piece of meat, warm and satisfying."),
        ItemIcon.Ham,
        tradePrice: 5,
        healthPointsReceived: 0,
        foodPointsReceived: 55
    );

    public static readonly AtributeItem HealingHerbs = new(
        ItemRarity.Common,
        new ItemName("Healing Herbs"),
        new ItemDescription("A small bundle of medicinal herbs, used to restore minor wounds."),
        ItemIcon.Salad,
        tradePrice: 5,
        healthPointsReceived: 30,
        foodPointsReceived: 0
    );

   

    // RARE
    public static readonly AtributeItem BitterRoot = new(
        ItemRarity.Rare,
        new ItemName("Bitter Root"),
        new ItemDescription("Bitter root freshly pulled from the ground, this root looks healthy but will generate a ferocious appetite."),
        ItemIcon.Root,
        tradePrice: 10,
        healthPointsReceived: 40,
        foodPointsReceived: -15
    );

    public static readonly AtributeItem StrongBeer = new(
        ItemRarity.Rare,
        new ItemName("Strong Beer"),
        new ItemDescription("A potent beer that fills the stomach and helps to forget sorrows, but that affects the health of the person who drinks it."),
        ItemIcon.Beer,
        tradePrice: 14,
        healthPointsReceived: -20,
        foodPointsReceived: 65
    );

    public static readonly AtributeItem HealthPotion = new(
        ItemRarity.Rare,
        new ItemName("Health potion"),
        new ItemDescription("A magical potion that restores a significant amount of health. Perfect for healing wounds and recovering from battle quickly."),
        ItemIcon.Health,
        tradePrice: 15,
        healthPointsReceived: 50,
        foodPointsReceived: 0
    );
    
    public static readonly AtributeItem LambStew = new(
        ItemRarity.Rare,
        new ItemName("Lamb Stew"),
        new ItemDescription("A hearty stew of tender lamb and vegetables that restores a great deal of hunger and provides some health."),
        ItemIcon.Beef,
        tradePrice: 20,
        healthPointsReceived: 20,
        foodPointsReceived: 60
    );

    public static readonly AtributeItem CheeseCake = new(
        ItemRarity.Rare,
        new ItemName("CheeseCake"),
        new ItemDescription("A rich and creamy cheesecake, satisfying hunger and providing a boost of health."),
        ItemIcon.Cake,
        tradePrice: 22,
        healthPointsReceived: 30,
        foodPointsReceived: 55
    );

    


    // EPIC
    public static readonly AtributeItem CursedFruit = new(
        ItemRarity.Epic,
        new ItemName("Cursed Fruit"),
        new ItemDescription("Legends say it grows where countless have fallen in battle. Consuming it grants the eater both health and sustenance from the fallen, though merchants rarely trade it due to the fear it inspires."),
        ItemIcon.Cherry,
        tradePrice: 0,
        healthPointsReceived: 60,
        foodPointsReceived: 60
    );

    public static readonly AtributeItem VialVitality = new(
        ItemRarity.Epic,
        new ItemName("Vial of Vitality"),
        new ItemDescription("A mysterious glass bottle containing a highly healing red liquid; its origin and potential side effects are unknown, but its value is evident at first glance."),
        ItemIcon.Cup,
        tradePrice: 50,
        healthPointsReceived: 100,
        foodPointsReceived: 0
    );

    public static readonly AtributeItem GoldenApple = new(
        ItemRarity.Epic,
        new ItemName("Golden Apple"),
        new ItemDescription("A legendary golden apple said to grow on a mystical golden tree. It restores a great deal of hunger and heals the body, though its true origin is shrouded in legend."),
        ItemIcon.Apple,
        tradePrice: 60,
        healthPointsReceived: 25,
        foodPointsReceived: 80
    );

    


    public static void AddItems(List<Item> items)
    {
        items.AddRange(new List<Item> { RottenMeat, Berry, Bread, Apple, CookedMeat, HealingHerbs, 
                                        BitterRoot, HealthPotion, StrongBeer, CheeseCake, LambStew,
                                        CursedFruit, GoldenApple, VialVitality

        });
    }
}
