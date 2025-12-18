using GameApp.Adapter.Api.dtos.ScenesDto;
using GameApp.Application.Enumerates;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Api.Mappers;

public static class SceneDtoMapper
{
    public static Scene ToDomain(SceneResponseDto dto)
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
            SceneType.NothingHappens => new NothingHappensScene(dto.Id, sceneName, sceneDescription, biome),

            SceneType.ChangeBiome =>
                new ChangeBiomeScene(dto.Id, sceneName, sceneDescription, biome),

            SceneType.Enemy =>
                new EnemyScene(dto.Id, sceneName, sceneDescription, biome,
                    dto.Enemy is null
                        ? throw new ArgumentNullException(nameof(dto.Enemy), "Enemy is required for EnemyScene")
                        : EnemyDtoMapper.ToDomain(dto.Enemy)
                ),

            SceneType.Item =>
                new ItemScene(dto.Id, sceneName, sceneDescription, biome,
                    dto.RewardItem is null
                        ? throw new ArgumentNullException(nameof(dto.RewardItem), "RewardItem is required for ItemScene")
                        : ItemDtoMapper.ToDomain(dto.RewardItem)
                ),


            SceneType.Trade =>
                new TradeScene(
                    dto.Id,
                    sceneName,
                    sceneDescription,
                    biome,
                    dto.MerchantMoneyToSpent ?? throw new ArgumentNullException(nameof(dto.MerchantMoneyToSpent),
                        "MerchantMoneyToSpent is required for TradeScene"),
                    dto.MerchantItemsOffer?.Select(ItemDtoMapper.ToDomain).ToList() ?? new(),
                    dto.ProfitMerchantMargin ?? throw new ArgumentNullException(nameof(dto.ProfitMerchantMargin),
                        "ProfitMerchantMargin is required for TradeScene")
                ),


            _ => throw new ArgumentException($"Unsupported SceneType type: {dto.SceneType}")
        };
    }

    public static Scene ToDomainFromCreateRequest(SceneCreateRequestDto dto)
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
                new ChangeBiomeScene(sceneName, sceneDescription, biome),

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


            SceneType.Trade =>
                new TradeScene(
                    sceneName,
                    sceneDescription,
                    biome,
                    dto.MerchantMoneyToSpent ?? throw new ArgumentNullException(nameof(dto.MerchantMoneyToSpent),
                        "MerchantMoneyToSpent is required for TradeScene"),
                    dto.MerchantItemsOffer?.Select(ItemDtoMapper.ToDomain).ToList() ?? new(),
                    dto.ProfitMerchantMargin ?? throw new ArgumentNullException(nameof(dto.ProfitMerchantMargin),
                        "ProfitMerchantMargin is required for TradeScene")
                ),


            _ => throw new ArgumentException($"Unsupported SceneType type: {dto.SceneType}")
        };
    }

    public static Scene ToDomainFromUpdateRequest(SceneUpdateRequestDto dto)
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

        Console.WriteLine("Scene: '" + sceneName + ", " + sceneDescription + ", " + biome + ", " + dto.SceneType + "\n");

        return dto.SceneType switch
        {
            SceneType.NothingHappens => new NothingHappensScene(sceneName, sceneDescription, biome),

            SceneType.ChangeBiome =>
                new ChangeBiomeScene(sceneName, sceneDescription, biome),

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

            SceneType.Trade =>
                new TradeScene(
                    sceneName,
                    sceneDescription,
                    biome,
                    dto.MerchantMoneyToSpent ?? throw new ArgumentNullException(nameof(dto.MerchantMoneyToSpent),
                        "MerchantMoneyToSpent is required for TradeScene"),
                    dto.MerchantItemsOffer?.Select(ItemDtoMapper.ToDomain).ToList() ?? new(),
                    dto.ProfitMerchantMargin ?? throw new ArgumentNullException(nameof(dto.ProfitMerchantMargin),
                        "ProfitMerchantMargin is required for TradeScene")
                ),

            _ => throw new ArgumentException($"Unsupported SceneType type: {dto.SceneType}")
        };
    }


    public static SceneResponseDto ToDto(Scene scene)
    {
        if (scene == null)
            throw new ArgumentNullException(nameof(scene));

        SceneResponseDto dto = new SceneResponseDto
        {
            Id = scene.GetGuid(),
            Name = scene.GetName().GetName(),
            Description = scene.GetDescription().GetDescription(),
            Biome = scene.GetBiome()
        };

        switch (scene)
        {
            case NothingHappensScene:
                dto.SceneType = SceneType.NothingHappens;
                break;

            case ChangeBiomeScene changeBiome:
                dto.SceneType = SceneType.ChangeBiome;
                break;

            case EnemyScene enemyScene:
                dto.SceneType = SceneType.Enemy;
                dto.Enemy = EnemyDtoMapper.ToDto(enemyScene.GetEnemy());
                break;

            case ItemScene itemScene:
                dto.SceneType = SceneType.Item;
                dto.RewardItem = ItemDtoMapper.ToDto(itemScene.GetRewardItem());
                break;

            case TradeScene trade:
                dto.SceneType = SceneType.Trade;
                dto.MerchantMoneyToSpent = trade.GetMerchantMoneyToSpent();
                dto.MerchantItemsOffer = trade.GetMerchantItemsOffer()
                                              .Select(ItemDtoMapper.ToDto)
                                              .ToList();
                dto.ProfitMerchantMargin = trade.GetProfitMerchantMargin();
                break;


            default:
                dto.SceneType = SceneType.None;
                break;
        }

        return dto;
    }

    public static List<SceneResponseDto> ToDtoList(IEnumerable<Scene> scenes)
    {
        return scenes.Select(ToDto).ToList();
    }

}