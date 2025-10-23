using GameApp.Api.dtos;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Api.Mappers;

public static class FinalSceneDtoMapper
{
    public static NothingHappensScene ToDomain(FinalSceneDto dto)
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

        return new NothingHappensScene(sceneName, sceneDescription, biome);
    }


    public static FinalSceneDto ToDto(NothingHappensScene scene)
    {
       if (scene == null)
            throw new ArgumentNullException(nameof(scene));

        FinalSceneDto dto = new FinalSceneDto
        {
            Name = scene.Name.Name,
            Description = scene.Description.Description,
            Biome = scene.Biome
        };

        return dto;
    }

}