using GameApp.Domain.Entities.Items;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Domain.Entities.Scenes;

// Class for scene where you trade with a merchant
public class TradeScene : Scene
{
    private readonly int MerchantMoneyToSpent;
    private readonly List<Item> MerchantItemsOffer;
    private readonly int ProfitMerchantMargin;

    public TradeScene(
        SceneName name,
        SceneDescription description,
        Biome biome,
        int merchantMoneyToSpent,
        List<Item> merchantItemsOffer,
        int profitMerchantMargin
    ) : base(name, description, biome)
    {
        MerchantMoneyToSpent = merchantMoneyToSpent;
        MerchantItemsOffer = merchantItemsOffer;
        ProfitMerchantMargin = profitMerchantMargin;
    }

    public TradeScene(
        Guid id,
        SceneName name,
        SceneDescription description,
        Biome biome,
        int merchantMoneyToSpent,
        List<Item> merchantItemsOffer,
        int profitMerchantMargin
    ) : base(id, name, description, biome)
    {
        MerchantMoneyToSpent = merchantMoneyToSpent;
        MerchantItemsOffer = merchantItemsOffer;
        ProfitMerchantMargin = profitMerchantMargin;
    }

    public int GetMerchantMoneyToSpent() => MerchantMoneyToSpent;
    public List<Item> GetMerchantItemsOffer() => MerchantItemsOffer;
    public int GetProfitMerchantMargin() => ProfitMerchantMargin;

    public TradeScene SetSceneName(SceneName newName) =>
        new TradeScene(newName, GetDescription(), GetBiome(), MerchantMoneyToSpent, MerchantItemsOffer, ProfitMerchantMargin);

    public TradeScene SetSceneDescription(SceneDescription newDescription) =>
        new TradeScene(GetName(), newDescription, GetBiome(), MerchantMoneyToSpent, MerchantItemsOffer, ProfitMerchantMargin);

    public TradeScene SetBiome(Biome newBiome) =>
        new TradeScene(GetName(), GetDescription(), newBiome, MerchantMoneyToSpent, MerchantItemsOffer, ProfitMerchantMargin);

    public TradeScene SetMerchantMoneyToSpent(int newMerchantMoneyToSpent) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), newMerchantMoneyToSpent, MerchantItemsOffer, ProfitMerchantMargin);

    public TradeScene SetMerchantItemsOffer(List<Item> newMerchantItems) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), MerchantMoneyToSpent, newMerchantItems, ProfitMerchantMargin);

    public TradeScene SetProfitMerchantMargin(int newMargin) =>
        new TradeScene(GetName(), GetDescription(), GetBiome(), MerchantMoneyToSpent, MerchantItemsOffer, newMargin);

    public override string ToString()
    {
        string merchantItems = string.Join(", ", MerchantItemsOffer.Select(i => i.ToString()));

        return $"TradeScene({GetGuid()}): {GetName()} - {GetBiome()}\n" +
               $"Merchant Money To Spend: {MerchantMoneyToSpent}\n" +
               $"Merchant Profit Margin: {ProfitMerchantMargin}\n" +
               $"Merchant Items Offer: [{merchantItems}]";
    }
}
