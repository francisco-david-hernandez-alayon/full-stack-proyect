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
            CompletedScenes = game.GetCompletedScenes().Select(g => g.GetName().GetName()).ToList(),
            CurrentScenes = game.GetCurrentScenes().Select(g => g.GetName().GetName()).ToList(),
            CurrentUserActions = game.GetCurrentUserAction(),
            FinalScene = game.GetFinalScene().GetName().GetName(),
            CurrentEnemy = EnemyDocumentMapper.ToDocumentPosibleNull(game.GetCurrentEnemy()),   // could be null
            EnemyHealthPoints = game.GetCurrentEnemy()?.GetHealthPoints()  // store enemy hp
        };
    }

    public async static Task<Game> ToDomainAsync(GameDocument doc, ISceneRepository sceneRepository, IItemRepository itemRepository, IEnemyRepository enemyRepository)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        Character character = await CharacterDocumentMapper.ToDomainAsync(doc.Character, itemRepository);

        List<Scene> completedScenes = (await Task.WhenAll(
            doc.CompletedScenes.Select(d => GetSceneByName(new SceneName(d), sceneRepository))
        )).ToList();

        List<Scene> currentScenes = (await Task.WhenAll(
            doc.CurrentScenes.Select(d => GetSceneByName(new SceneName(d), sceneRepository))
        )).ToList();


        List<UserAction> currentUserAction = doc.CurrentUserActions.ToList();
        NothingHappensScene finalScene = await GetFinalSceneByName(new SceneName(doc.FinalScene), sceneRepository);
        Enemy? currentEnemy = EnemyDocumentMapper.ToDomainPosibleNull(doc.CurrentEnemy);
        if (currentEnemy != null)
        {
            currentEnemy = currentEnemy.SetHealthPoints(doc.EnemyHealthPoints ?? 0);
        }


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

    // GET SCENES FOR OTHER COLLECTIONS
    private static async Task<Scene> GetSceneByName(SceneName name, ISceneRepository sceneRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Scene? scene = await sceneRepository.FetchByName(name);
        if (scene == null)
            throw new InvalidOperationException($"Scene '{name.GetName()}' not found.");

        return scene;
    }

    private static async Task<NothingHappensScene> GetFinalSceneByName(SceneName name, ISceneRepository sceneRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Scene? scene = await sceneRepository.FetchByName(name);
        if (scene == null)
            throw new InvalidOperationException($"Final Scene '{name.GetName()}' not found.");

        if (scene is NothingHappensScene finalScene)
        {
            return finalScene;
        }
        else
        {
            return new NothingHappensScene(new SceneName("Final Scene test"), new SceneDescription("Final description"), Biome.unknown);
        }

    }


}
