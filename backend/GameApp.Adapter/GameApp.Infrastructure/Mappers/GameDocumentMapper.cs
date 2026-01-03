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
            Difficulty = game.GetDifficulty(),
            Character = CharacterDocumentMapper.ToDocument(game.GetCharacter()),
            NumberScenesToFinish = game.GetNumberScenesToFinish(),
            CompletedScenes = game.GetCompletedScenes().Select(itemSceneListSceneDocumentMapper.ToItemSceneListDocument).ToList(),
            CurrentScenes = game.GetCurrentScenes().Select(itemSceneListSceneDocumentMapper.ToItemSceneListDocument).ToList(),
            CurrentUserActions = game.GetCurrentUserAction(),
            FinalScene = game.GetFinalScene().GetName().GetName(),
            Status = game.GetGameStatus(),
            CurrentEnemyName = game.GetCurrentEnemy()?.GetName().GetName(),
            CurrentEnemyHealthPoints = game.GetCurrentEnemy()?.GetHealthPoints()  // store enemy hp
        };
    }

    public async static Task<Game> ToDomainAsync(GameDocument doc, ISceneRepository sceneRepository, IItemRepository itemRepository, IEnemyRepository enemyRepository)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        Character character = await CharacterDocumentMapper.ToDomainAsync(doc.Character, itemRepository);

        List<Scene> completedScenes = (await Task.WhenAll(
            doc.CompletedScenes.Select(d =>
                itemSceneListSceneDocumentMapper.ToSceneDomainAsync(d, sceneRepository)
            )
        )).ToList();

        List<Scene> currentScenes = (await Task.WhenAll(
            doc.CurrentScenes.Select(d =>
                itemSceneListSceneDocumentMapper.ToSceneDomainAsync(d, sceneRepository)
            )
        )).ToList();


        List<UserAction> currentUserAction = doc.CurrentUserActions.ToList();
        FinalScene finalScene = await GetFinalSceneByName(new SceneName(doc.FinalScene), sceneRepository);
        Enemy? currentEnemy = null;
        if (doc.CurrentEnemyName != null)
        {
            currentEnemy = await GetEnemyByName(new EnemyName(doc.CurrentEnemyName), enemyRepository);
            if (currentEnemy != null)
            {
                currentEnemy = currentEnemy.SetHealthPoints(doc.CurrentEnemyHealthPoints ?? 0);
            }
        }


        return new Game(
            doc.Id,
            doc.Difficulty,
            character,
            doc.NumberScenesToFinish,
            completedScenes,
            finalScene,
            currentScenes,
            currentUserAction,
            doc.Status,
            currentEnemy
        );
    }

    // GET SCENES FOR OTHER COLLECTIONS
    private static async Task<FinalScene> GetFinalSceneByName(SceneName name, ISceneRepository sceneRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Scene? scene = await sceneRepository.FetchByName(name);
        if (scene == null)
            throw new InvalidOperationException($"Final Scene '{name.GetName()}' not found.");

        if (scene is FinalScene finalScene)
        {
            return finalScene;
        }
        else
        {
            return new FinalScene(new SceneName("Final Scene test"), new SceneDescription("Final description"), Biome.Unknown);
        }

    }

    private static async Task<Enemy> GetEnemyByName(EnemyName name, IEnemyRepository enemyRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Enemy? enemy = await enemyRepository.FetchByName(name);
        if (enemy == null)
            throw new InvalidOperationException($"Enemy '{name.GetName()}' not found.");

        return enemy;
    }


}
