using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Repositories;

namespace GameApp.Adapter.Infrastructure.Mappers;

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

    public async static Task<Game> ToDomainAsync(GameDocument doc, IItemRepository itemRepository, IEnemyRepository enemyRepository)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        Character character = CharacterDocumentMapper.ToDomain(doc.Character);

        List<Scene> completedScenes = (await Task.WhenAll(
            doc.CompletedScenes.Select(d => SceneDocumentMapper.ToDomainAsync(d, itemRepository, enemyRepository))
        )).ToList();

        List<Scene> currentScenes = (await Task.WhenAll(
            doc.CurrentScenes.Select(d => SceneDocumentMapper.ToDomainAsync(d, itemRepository, enemyRepository))
        )).ToList();


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
