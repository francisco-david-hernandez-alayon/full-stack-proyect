using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Models;

namespace GameApp.Infrastructure.Mappers;

public static class FinalSceneDocumentMapper
{
    public static FinalSceneDocument ToDocument(NothingHappensScene scene)
    {
        return new FinalSceneDocument
        {
            Name = scene.GetName().GetName(),
            Description = scene.GetDescription().GetDescription(),
            Biome = scene.GetBiome()
        };
    }

    public static NothingHappensScene ToDomain(FinalSceneDocument doc)
    {
        return new NothingHappensScene(
            new SceneName(doc.Name),
            new SceneDescription(doc.Description),
            doc.Biome
        );
    }
}
