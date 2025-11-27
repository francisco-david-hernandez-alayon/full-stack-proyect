using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Adapter.Infrastructure.Enumerates;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.Repositories;
using GameApp.Domain.Entities.Items;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class SceneDocumentMapper
{
    public static SceneDocument ToDocument(Scene scene)
    {
        var doc = new SceneDocument
        {
            Id = scene.GetGuid(),
            Name = scene.GetName().GetName(),
            Description = scene.GetDescription().GetDescription(),
            Biome = scene.GetBiome()
        };

        switch (scene)
        {
            case NothingHappensScene:
                doc.SceneType = SceneType.NothingHappens;
                break;

            case ChangeBiomeScene changeBiome:
                doc.SceneType = SceneType.ChangeBiome;
                break;

            case EnemyScene enemyScene:
                doc.SceneType = SceneType.Enemy;
                doc.Enemy = EnemyDocumentMapper.ToDocument(enemyScene.GetEnemy());
                break;

            case ItemScene itemScene:
                doc.SceneType = SceneType.Item;
                doc.RewardItem = itemScene.GetRewardItem().GetName().GetName();  // store only item name
                break;

            case EnterDungeonScene dungeon:
                doc.SceneType = SceneType.EnterDungeon;
                doc.PossibleScenes = dungeon.GetPossibleScenes().Select(ToDocument).ToList();
                break;

            case TradeScene trade:
                doc.SceneType = SceneType.Trade;
                doc.CharacterItemsOffer = trade.GetCharacterItemsOffer().Select(ItemDocumentMapper.ToDocument).ToList();
                doc.CharacterMoneyOffer = trade.GetCharacterMoneyOffer();
                doc.MerchantItemsOffer = trade.GetMerchantItemsOffer().Select(ItemDocumentMapper.ToDocument).ToList();
                doc.MerchantMoneyOffer = trade.GetMerchantMoneyOffer();
                break;

            default:
                doc.SceneType = SceneType.None;
                break;
        }

        return doc;
    }

    public static async Task<Scene> ToDomainAsync(SceneDocument doc, IItemRepository itemRepository)
    {
        var name = new SceneName(doc.Name);
        var description = new SceneDescription(doc.Description);

        return doc.SceneType switch
        {
            SceneType.NothingHappens =>
                new NothingHappensScene(doc.Id, name, description, doc.Biome),

            SceneType.ChangeBiome =>
                new ChangeBiomeScene(doc.Id, name, description, doc.Biome),

            SceneType.Enemy =>
                new EnemyScene(doc.Id, name, description, doc.Biome,
                    doc.Enemy is null
                        ? throw new ArgumentNullException(nameof(doc.Enemy))
                        : EnemyDocumentMapper.ToDomain(doc.Enemy)
                ),

            SceneType.Item =>
                new ItemScene(doc.Id, name, description, doc.Biome,
                    doc.RewardItem is null
                        ? throw new ArgumentNullException(nameof(doc.RewardItem))
                        : await GetItemByName(new ItemName(doc.RewardItem!), itemRepository)
                ),

            SceneType.EnterDungeon =>
                new EnterDungeonScene(
                    doc.Id,
                    name,
                    description,
                    doc.Biome,
                    doc.PossibleScenes != null
                        ? (await Task.WhenAll(doc.PossibleScenes.Select(d => SceneDocumentMapper.ToDomainAsync(d, itemRepository)))).ToList()
                        : new List<Scene>()
                ),


            SceneType.Trade =>
                new TradeScene(doc.Id, name, description, doc.Biome,
                    doc.CharacterItemsOffer?.Select(ItemDocumentMapper.ToDomain).ToList() ?? new(),
                    doc.CharacterMoneyOffer ?? 0,
                    doc.MerchantItemsOffer?.Select(ItemDocumentMapper.ToDomain).ToList() ?? new(),
                    doc.MerchantMoneyOffer ?? 0
                ),

            _ => new NothingHappensScene(doc.Id, name, description, doc.Biome)
        };
    }


    private static async Task<Item> GetItemByName(ItemName name, IItemRepository itemRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Item? item = await itemRepository.FetchByName(name);
        if (item == null)
            throw new InvalidOperationException($"Item '{name.GetName()}' not found.");

        return item;
    }


}
