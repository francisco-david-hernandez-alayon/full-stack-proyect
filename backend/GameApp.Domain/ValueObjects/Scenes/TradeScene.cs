using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where you trade with a merchant
public class TradeScene : Scene
{
    // Character offer
    private readonly List<Item> _characterItemsOffer;
    private readonly int _characterMoneyOffer;

    // Merchant offer
    private readonly List<Item> _merchantItemsOffer;
    private readonly int _merchantMoneyOffer;

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
        _characterItemsOffer = characterItemsOffer;
        _characterMoneyOffer = characterMoneyOffer;
        _merchantItemsOffer = merchantItemsOffer;
        _merchantMoneyOffer = merchantMoneyOffer;
    }

    // Getters
    public List<Item> GetCharacterItemsOffer() => _characterItemsOffer;
    public int GetCharacterMoneyOffer() => _characterMoneyOffer;
    public List<Item> GetMerchantItemsOffer() => _merchantItemsOffer;
    public int GetMerchantMoneyOffer() => _merchantMoneyOffer;

    // Setters 
    public TradeScene SetSceneName(SceneName newName) =>
        new TradeScene(newName, GetDescription(), GetBiomes(), _characterItemsOffer, _characterMoneyOffer, _merchantItemsOffer, _merchantMoneyOffer);

    public TradeScene SetSceneDescription(SceneDescription newDescription) =>
        new TradeScene(GetName(), newDescription, GetBiomes(), _characterItemsOffer, _characterMoneyOffer, _merchantItemsOffer, _merchantMoneyOffer);

    public TradeScene SetBiome(Biomes newBiome) =>
        new TradeScene(GetName(), GetDescription(), newBiome, _characterItemsOffer, _characterMoneyOffer, _merchantItemsOffer, _merchantMoneyOffer);


    public TradeScene SetCharacterItemsOffer(List<Item> newItemsOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiomes(), newItemsOffer, _characterMoneyOffer, _merchantItemsOffer, _merchantMoneyOffer);

    public TradeScene SetCharacterMoneyOffer(int newMoneyOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiomes(), _characterItemsOffer, newMoneyOffer, _merchantItemsOffer, _merchantMoneyOffer);

    public TradeScene SetMerchantItemsOffer(List<Item> newItemsOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiomes(), _characterItemsOffer, _characterMoneyOffer, newItemsOffer, _merchantMoneyOffer);

    public TradeScene SetMerchantMoneyOffer(int newMoneyOffer) =>
        new TradeScene(GetName(), GetDescription(), GetBiomes(), _characterItemsOffer, _characterMoneyOffer, _merchantItemsOffer, newMoneyOffer);


    // To string
    public override string ToString()
    {
        string characterItems = string.Join(", ", _characterItemsOffer.Select(i => i.ToString()));
        string merchantItems = string.Join(", ", _merchantItemsOffer.Select(i => i.ToString()));

        return $"TradeScene: {GetName()} - {_biome}\n" +
               $"Character Offer: Money={_characterMoneyOffer}, Items=[{characterItems}]\n" +
               $"Merchant Offer: Money={_merchantMoneyOffer}, Items=[{merchantItems}]";
    }
}
