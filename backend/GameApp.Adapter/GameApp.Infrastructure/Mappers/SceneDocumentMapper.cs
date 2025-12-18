using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.Repositories;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.Entities;
using GameApp.Application.Enumerates;

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
                doc.Enemy = enemyScene.GetEnemy().GetName().GetName();
                break;

            case ItemScene itemScene:
                doc.SceneType = SceneType.Item;
                doc.RewardItem = itemScene.GetRewardItem().GetName().GetName();
                break;

            case TradeScene trade:
                doc.SceneType = SceneType.Trade;
                doc.MerchantMoneyToSpent = trade.GetMerchantMoneyToSpent();
                doc.MerchantItemsOffer = trade.GetMerchantItemsOffer()
                                             .Select(ItemDocumentMapper.ToDocument)
                                             .ToList();
                doc.ProfitMerchantMargin = trade.GetProfitMerchantMargin();
                break;


            default:
                doc.SceneType = SceneType.None;
                break;
        }

        return doc;
    }

    public static async Task<Scene> ToDomainAsync(SceneDocument doc, IItemRepository itemRepository, IEnemyRepository enemyRepository)
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
                {
                    Enemy enemy = doc.Enemy is null
                        ? throw new ArgumentNullException(nameof(doc.Enemy))
                        : await GetEnemyByName(new EnemyName(doc.Enemy), enemyRepository);

                    return new EnemyScene(doc.Id, name, description, doc.Biome, enemy);
                }

            case SceneType.Item:
                {
                    Item item = doc.RewardItem is null
                        ? throw new ArgumentNullException(nameof(doc.RewardItem))
                        : await GetItemByName(new ItemName(doc.RewardItem), itemRepository);

                    return new ItemScene(doc.Id, name, description, doc.Biome, item);
                }

            case SceneType.Trade:
                return new TradeScene(
                    doc.Id,
                    name,
                    description,
                    doc.Biome,
                    doc.MerchantMoneyToSpent ?? 0,
                    doc.MerchantItemsOffer?.Select(ItemDocumentMapper.ToDomain).ToList() ?? new(),
                    doc.ProfitMerchantMargin ?? 0);

            default:
                return new NothingHappensScene(doc.Id, name, description, doc.Biome);
        }
    }


    // GET ITEMS FOR OTHER COLLECTIONS
    private static async Task<Item> GetItemByName(ItemName name, IItemRepository itemRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Item? item = await itemRepository.FetchByName(name);
        if (item == null)
            throw new InvalidOperationException($"Item '{name.GetName()}' not found.");

        return item;
    }

    // GET ENEMYS FOR OTHER COLLECTIONS
    private static async Task<Enemy> GetEnemyByName(EnemyName name, IEnemyRepository enemyRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Enemy? enemy = await enemyRepository.FetchByName(name);
        if (enemy == null)
            throw new InvalidOperationException($"Enemy '{name.GetName()}' not found.");

        return enemy;
    }


}
