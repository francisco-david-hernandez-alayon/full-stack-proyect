using GameApp.Domain.Entities;
using GameApp.Infrastructure.Models;

namespace GameApp.Infrastructure.Mappers;

public static class GameDocumentMapper
{
    public static GameDocument ToDocument(Game game)
    {
        return new GameDocument
        {
            Id = game.GetGuid(),
            Character = CharacterDocumentMapper.ToDocument(game.GetCharacter()),
            NumberScenesToFinish = game.GetNumberScenesToFinish(),
            CompletedScenes = game.GetCompletedScenes().Select(SceneDocumentMapper.ToDocument).ToList(),
            CurrentScenes = game.GetCurrentScenes().Select(SceneDocumentMapper.ToDocument).ToList(),
            FinalScene = FinalSceneDocumentMapper.ToDocument(game.GetFinalScene())
        };
    }

    public static Game ToDomain(GameDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        var character = CharacterDocumentMapper.ToDomain(doc.Character);
        var completedScenes = doc.CompletedScenes.Select(SceneDocumentMapper.ToDomain).ToList();
        var currentScenes = doc.CurrentScenes.Select(SceneDocumentMapper.ToDomain).ToList();
        var finalScene = FinalSceneDocumentMapper.ToDomain(doc.FinalScene);

        return new Game(
            doc.Id,
            character,
            doc.NumberScenesToFinish,
            completedScenes,
            finalScene,
            currentScenes
        );
    }

}
