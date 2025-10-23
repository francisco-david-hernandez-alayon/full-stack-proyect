using GameApp.Api.dtos;
using GameApp.Api.Enumerates;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Api.Mappers;

public static class SceneDtoMapper
{
    public static Scene ToDomain(SceneDto dto)
    {
        // Check nullability
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));

        if (dto.Description == null)
            throw new ArgumentNullException(nameof(dto.Description));

        SceneName sceneName = new SceneName(dto.Name);
        SceneDescription sceneDescription = new SceneDescription(dto.Description);
        Biome biome = dto.Biome;

        return dto.SceneType switch
        {
            SceneType.NothingHappens => new NothingHappensScene(sceneName, sceneDescription, biome),

            SceneType.ChangeBiome =>
                new ChangeBiomeScene(sceneName, sceneDescription, biome,
                    dto.BiomeToChange ?? throw new ArgumentNullException(nameof(dto.BiomeToChange),
                        "BiomeToChange is required for ChangeBiomeScene")
                ),

            SceneType.Enemy =>
                new EnemyScene(sceneName, sceneDescription, biome,
                    dto.Enemy is null
                        ? throw new ArgumentNullException(nameof(dto.Enemy), "Enemy is required for EnemyScene")
                        : EnemyDtoMapper.ToDomain(dto.Enemy)
                ),

            SceneType.Item =>
                new ItemScene(sceneName, sceneDescription, biome,
                    dto.RewardItem is null
                        ? throw new ArgumentNullException(nameof(dto.RewardItem), "RewardItem is required for ItemScene")
                        : ItemDtoMapper.ToDomain(dto.RewardItem)
                ),

            SceneType.EnterDungeon =>
                new EnterDungeonScene(sceneName, sceneDescription, biome,
                    dto.PossibleScenes?.Select(ToDomain).ToList() ?? new List<Scene>()
                ),

            SceneType.Trade =>
                new TradeScene(sceneName, sceneDescription, biome,
                    dto.CharacterItemsOffer?.Select(ItemDtoMapper.ToDomain).ToList() ?? new(),
                    dto.CharacterMoneyOffer ?? throw new ArgumentNullException(nameof(dto.CharacterMoneyOffer),
                        "CharacterMoneyOffer is required for TradeScene"),
                    dto.MerchantItemsOffer?.Select(ItemDtoMapper.ToDomain).ToList() ?? new(),
                    dto.MerchantMoneyOffer ?? throw new ArgumentNullException(nameof(dto.MerchantMoneyOffer),
                        "MerchantMoneyOffer is required for TradeScene")
                ),

            _ => throw new ArgumentException($"Unsupported SceneType type: {dto.SceneType}")
        };
    }


    public static SceneDto ToDto(Scene scene)
    {
        if (scene == null)
            throw new ArgumentNullException(nameof(scene));

        SceneDto dto = new SceneDto
        {
            Name = scene.Name.Name,
            Description = scene.Description.Description,
            Biome = scene.Biome
        };

        switch (scene)
        {
            case NothingHappensScene:
                dto.SceneType = SceneType.NothingHappens;
                break;

            case ChangeBiomeScene changeBiome:
                dto.SceneType = SceneType.ChangeBiome;
                dto.BiomeToChange = changeBiome.BiomeToChange;
                break;

            case EnemyScene enemyScene:
                dto.SceneType = SceneType.Enemy;
                dto.Enemy = EnemyDtoMapper.ToDto(enemyScene.Enemy);
                break;

            case ItemScene itemScene:
                dto.SceneType = SceneType.Item;
                dto.RewardItem = ItemDtoMapper.ToDto(itemScene.RewardItem);
                break;

            case EnterDungeonScene dungeon:
                dto.SceneType = SceneType.EnterDungeon;
                dto.PossibleScenes = dungeon.PossibleScenes
                    .Select(ToDto)
                    .ToList();
                break;

            case TradeScene trade:
                dto.SceneType = SceneType.Trade;
                dto.CharacterItemsOffer = trade.CharacterItemsOffer
                    .Select(ItemDtoMapper.ToDto)
                    .ToList();
                dto.CharacterMoneyOffer = trade.CharacterMoneyOffer;
                dto.MerchantItemsOffer = trade.MerchantItemsOffer
                    .Select(ItemDtoMapper.ToDto)
                    .ToList();
                dto.MerchantMoneyOffer = trade.MerchantMoneyOffer;
                break;

            default:
                dto.SceneType = SceneType.None;
                break;
        }

        return dto;
    }

}