using System.Text.Json;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class ScenePersistenceMapper
{
    public static ScenePersistenceModel ToPersistenceModel(Scene scene)
    {
        var model = new ScenePersistenceModel
        {
            Name = scene.GetName().ToString(),
            Description = scene.GetDescription().ToString(),
            Biome = scene.GetBiome().ToString(),
            SceneType = scene.GetType().Name
        };

        switch (scene)
        {
            case ChangeBiomeScene c:
                model.BiomeToChange = c.BiomeToChange.ToString();
                break;

            case EnemyScene e:
                model.EnemyJson = JsonSerializer.Serialize(EnemyPersistenceMapper.ToPersistenceModel(e.Enemy));
                break;

            case EnterDungeonScene d:
                model.PossibleScenesJson = JsonSerializer.Serialize(d.PossibleScenes.Select(ToPersistenceModel).ToList());
                break;

            case ItemScene i:
                model.RewardItemJson = JsonSerializer.Serialize(ItemPersistenceMapper.ToPersistenceModel(i.RewardItem));
                break;

            case TradeScene t:
                model.CharacterItemsOfferJson = JsonSerializer.Serialize(t.CharacterItemsOffer.Select(ItemPersistenceMapper.ToPersistenceModel).ToList());
                model.CharacterMoneyOffer = t.CharacterMoneyOffer;
                model.MerchantItemsOfferJson = JsonSerializer.Serialize(t.MerchantItemsOffer.Select(ItemPersistenceMapper.ToPersistenceModel).ToList());
                model.MerchantMoneyOffer = t.MerchantMoneyOffer;
                break;
        }

        return model;
    }

    public static Scene ToDomain(ScenePersistenceModel model)
    {
        var name = new SceneName(model.Name);
        var description = new SceneDescription(model.Description);
        var biome = Enum.TryParse<Biome>(model.Biome, out var parsedBiome) ? parsedBiome : Biome.unknown;

        return model.SceneType switch
        {
            nameof(ChangeBiomeScene) =>
                new ChangeBiomeScene(name, description, biome,
                    Enum.TryParse<Biome>(model.BiomeToChange, out var biomeToChange)
                        ? biomeToChange
                        : Biome.unknown),

            nameof(EnemyScene) =>
                new EnemyScene(name, description, biome,
                    EnemyPersistenceMapper.ToDomain(JsonSerializer.Deserialize<EnemyPersistenceModel>(model.EnemyJson)!)),

            nameof(EnterDungeonScene) =>
                new EnterDungeonScene(name, description, biome,
                    JsonSerializer.Deserialize<List<ScenePersistenceModel>>(model.PossibleScenesJson)!
                        .Select(ToDomain)
                        .ToList()),

            nameof(ItemScene) =>
                new ItemScene(name, description, biome,
                    ItemPersistenceMapper.ToDomain(JsonSerializer.Deserialize<ItemPersistenceModel>(model.RewardItemJson)!)),

            nameof(TradeScene) =>
                new TradeScene(
                    name, description, biome,
                    JsonSerializer.Deserialize<List<ItemPersistenceModel>>(model.CharacterItemsOfferJson)!
                        .Select(ItemPersistenceMapper.ToDomain)
                        .ToList(),
                    model.CharacterMoneyOffer ?? 0,
                    JsonSerializer.Deserialize<List<ItemPersistenceModel>>(model.MerchantItemsOfferJson)!
                        .Select(ItemPersistenceMapper.ToDomain)
                        .ToList(),
                    model.MerchantMoneyOffer ?? 0
                ),

            _ => new NothingHappensScene(name, description, biome)
        };
    }
}
