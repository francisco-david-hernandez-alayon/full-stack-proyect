using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Models;

namespace GameApp.Infrastructure.Mappers;

public static class FinalSceneDocumentMapper
{
    public static FinalSceneDocument ToDocument(NothingHappensScene scene)
    {
        return new FinalSceneDocument
        {
            Name = scene.Name.Name,
            Description = scene.Description.Description,
            Biome = scene.Biome
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
