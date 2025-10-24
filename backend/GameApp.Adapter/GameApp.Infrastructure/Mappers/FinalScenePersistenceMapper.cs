using System.Text.Json;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class FinalScenePersistenceMapper
{
    public static FinalScenePersistenceModel ToPersistenceModel(NothingHappensScene scene)
    {
        var model = new FinalScenePersistenceModel
        {
            Name = scene.GetName().ToString(),
            Description = scene.GetDescription().ToString(),
            Biome = scene.GetBiome().ToString(),
        };
        return model;
    }

    public static NothingHappensScene ToDomain(FinalScenePersistenceModel model)
    {
        var name = new SceneName(model.Name);
        var description = new SceneDescription(model.Description);
        var biome = Enum.TryParse<Biome>(model.Biome, out var parsedBiome) ? parsedBiome : Biome.unknown;

        return new NothingHappensScene(name, description, biome);
    }
}
