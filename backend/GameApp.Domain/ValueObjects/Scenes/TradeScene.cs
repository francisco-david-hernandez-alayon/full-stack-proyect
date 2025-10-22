using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where you trade with a merchant
public class TradeScene : Scene
{
    // Character offer
    public List<Item> CharacterItemsOffer { get; private set; } = new();
    public int CharacterMoneyOffer { get; private set; }


    // Merchant offer
    public List<Item> MerchantItemsOffer { get; private set; } = new();
    public int MerchantMoneyOffer { get; private set; }


    // Constructor
    public TradeScene(
        SceneName name,
        SceneDescription description,
        Biomes biome,
        List<Item> characterItemsOffer,
        int characterMoneyOffer,
        List<Item> merchantItemsOffer,
        int merchantMoneyOffer
    ) : base(name, description, biome)
    {
        CharacterItemsOffer = characterItemsOffer;
        CharacterMoneyOffer = characterMoneyOffer;
        MerchantItemsOffer = merchantItemsOffer;
        MerchantMoneyOffer = merchantMoneyOffer;
    }

    // Getters
    public List<Item> GetCharacterItemsOffer() => CharacterItemsOffer;
    public int GetCharacterMoneyOffer() => CharacterMoneyOffer;
    public List<Item> GetMerchantItemsOffer() => MerchantItemsOffer;
    public int GetMerchantMoneyOffer() => MerchantMoneyOffer;

    // Setters 
    public TradeScene SetSceneName(SceneName newName) =>
        new TradeScene(newName, GetDescription(), GetBiome(), CharacterItemsOffer, CharacterMoneyOffer, MerchantItemsOffer, MerchantMoneyOffer);

    public TradeScene SetSceneDescription(SceneDescription newDescription) =>
        new TradeScene(GetName(), newDescription, GetBiome(), CharacterItemsOffer, CharacterMoneyOffer, MerchantItemsOffer, MerchantMoneyOffer);

    public TradeScene SetBiome(Biomes newBiome) =>
        new TradeScene(GetName(), GetDescription(), newBiome, CharacterItemsOffer, CharacterMoneyOffer, MerchantItemsOffer, MerchantMoneyOffer);


    public TradeScene SetCharacterItemsOffer(List<Item> newItemsOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), newItemsOffer, CharacterMoneyOffer, MerchantItemsOffer, MerchantMoneyOffer);

    public TradeScene SetCharacterMoneyOffer(int newMoneyOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), CharacterItemsOffer, newMoneyOffer, MerchantItemsOffer, MerchantMoneyOffer);

    public TradeScene SetMerchantItemsOffer(List<Item> newItemsOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), CharacterItemsOffer, CharacterMoneyOffer, newItemsOffer, MerchantMoneyOffer);

    public TradeScene SetMerchantMoneyOffer(int newMoneyOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), CharacterItemsOffer, CharacterMoneyOffer, MerchantItemsOffer, newMoneyOffer);


    // To string
    public override string ToString()
    {
        string characterItems = string.Join(", ", CharacterItemsOffer.Select(i => i.ToString()));
        string merchantItems = string.Join(", ", MerchantItemsOffer.Select(i => i.ToString()));

        return $"TradeScene: {GetName()} - {GetBiome()}\n" +
               $"Character Offer: Money={CharacterMoneyOffer}, Items=[{characterItems}]\n" +
               $"Merchant Offer: Money={MerchantMoneyOffer}, Items=[{merchantItems}]";
    }
}
