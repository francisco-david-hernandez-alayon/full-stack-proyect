using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.ValueObjects.Scenes;
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
            CurrentUserActions = game.GetCurrentUserAction(),
            FinalScene = FinalSceneDocumentMapper.ToDocument(game.GetFinalScene()),
            CurrentEnemy = EnemyDocumentMapper.ToDocumentPosibleNull(game.GetCurrentEnemy())   // could be null
        };
    }

    public static Game ToDomain(GameDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        Character character = CharacterDocumentMapper.ToDomain(doc.Character);
        List<Scene> completedScenes = doc.CompletedScenes.Select(SceneDocumentMapper.ToDomain).ToList();
        List<Scene> currentScenes = doc.CurrentScenes.Select(SceneDocumentMapper.ToDomain).ToList();
        List<UserAction> currentUserAction = doc.CurrentUserActions.ToList();
        NothingHappensScene finalScene = FinalSceneDocumentMapper.ToDomain(doc.FinalScene);
        Enemy? currentEnemy = EnemyDocumentMapper.ToDomainPosibleNull(doc.CurrentEnemy);

        return new Game(
            doc.Id,
            character,
            doc.NumberScenesToFinish,
            completedScenes,
            finalScene,
            currentScenes,
            currentUserAction,
            currentEnemy
        );
    }

}
