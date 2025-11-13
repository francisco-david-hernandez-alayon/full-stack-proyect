using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Enumerates;
using GameApp.Infrastructure.Models;

namespace GameApp.Infrastructure.Mappers;

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
                doc.RewardItem = ItemDocumentMapper.ToDocument(itemScene.GetRewardItem());
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

    public static Scene ToDomain(SceneDocument doc)
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
                        : ItemDocumentMapper.ToDomain(doc.RewardItem)
                ),

            SceneType.EnterDungeon =>
                new EnterDungeonScene(doc.Id, name, description, doc.Biome,
                    doc.PossibleScenes?.Select(ToDomain).ToList() ?? new List<Scene>()),

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
}
