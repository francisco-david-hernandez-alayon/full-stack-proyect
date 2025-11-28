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
                if (itemScene.GetRewardItem() is AttackItem attackItem)  // store durability in attack item case
                {
                    doc.attackItemDurability = attackItem.GetDurability();
                }
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

        switch (doc.SceneType)
        {
            case SceneType.NothingHappens:
                return new NothingHappensScene(doc.Id, name, description, doc.Biome);

            case SceneType.ChangeBiome:
                return new ChangeBiomeScene(doc.Id, name, description, doc.Biome);

            case SceneType.Enemy:
                return new EnemyScene(doc.Id, name, description, doc.Biome,
                    doc.Enemy is null
                        ? throw new ArgumentNullException(nameof(doc.Enemy))
                        : EnemyDocumentMapper.ToDomain(doc.Enemy));

            case SceneType.Item:
                {
                    Item item = doc.RewardItem is null
                        ? throw new ArgumentNullException(nameof(doc.RewardItem))
                        : await GetItemByName(new ItemName(doc.RewardItem), itemRepository);

                    if (item is AttackItem attackItem)
                    {
                        item = attackItem.SetDurability(doc.attackItemDurability ?? 0);
                    }

                    return new ItemScene(doc.Id, name, description, doc.Biome, item);
                }

            case SceneType.EnterDungeon:
                return new EnterDungeonScene(
                    doc.Id,
                    name,
                    description,
                    doc.Biome,
                    doc.PossibleScenes != null
                        ? (await Task.WhenAll(doc.PossibleScenes
                            .Select(d => SceneDocumentMapper.ToDomainAsync(d, itemRepository))))
                            .ToList()
                        : new List<Scene>());

            case SceneType.Trade:
                return new TradeScene(
                    doc.Id,
                    name,
                    description,
                    doc.Biome,
                    doc.CharacterItemsOffer?.Select(ItemDocumentMapper.ToDomain).ToList() ?? new(),
                    doc.CharacterMoneyOffer ?? 0,
                    doc.MerchantItemsOffer?.Select(ItemDocumentMapper.ToDomain).ToList() ?? new(),
                    doc.MerchantMoneyOffer ?? 0);

            default:
                return new NothingHappensScene(doc.Id, name, description, doc.Biome);
        }
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
