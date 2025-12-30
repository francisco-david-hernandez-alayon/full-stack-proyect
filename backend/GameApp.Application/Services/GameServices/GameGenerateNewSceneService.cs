using GameApp.Domain.Entities;
using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Repositories;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Application.Enumerates;

namespace GameApp.Application.Services.GameServices;

public class GameGenerateNewSceneService : GameGenerateNewSceneUseCase
{

    private readonly IGameRepository _repoGame;
    private readonly ISceneRepository _repoScene;
    private readonly GameUpdateService _gameUpdateService;

    public GameGenerateNewSceneService(IGameRepository repoGame, ISceneRepository repoScene, GameUpdateService gameUpdateService)
    {
        _repoGame = repoGame;
        _repoScene = repoScene;
        _gameUpdateService = gameUpdateService;
    }


    private static readonly Dictionary<Biome, Dictionary<SceneType, int>> SceneProbabilitiesByBiome =
    new()
    {
        [Biome.City] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 5 },
            { SceneType.Item, 15 },
            { SceneType.Enemy, 20 },
            { SceneType.Trade, 30 },
            { SceneType.ChangeBiome, 30 }
        },

        [Biome.Forest] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 15 },
            { SceneType.Item, 25 },
            { SceneType.Enemy, 30 },
            { SceneType.Trade, 10 },
            { SceneType.ChangeBiome, 20 }
        },

        [Biome.Desert] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 35 },
            { SceneType.Item, 20 },
            { SceneType.Enemy, 20 },
            { SceneType.Trade, 10 },
            { SceneType.ChangeBiome, 15 }
        },

        [Biome.Swamp] = new Dictionary<SceneType, int>
        {
            { SceneType.NothingHappens, 10 },
            { SceneType.Item, 15 },
            { SceneType.Enemy, 45 },
            { SceneType.Trade, 10 },
            { SceneType.ChangeBiome, 20 }
        }
    };

    private SceneType GetRandomSceneTypeByBiome(Biome biome)
    {
        var probabilities = SceneProbabilitiesByBiome[biome];
        var totalWeight = probabilities.Values.Sum();

        var roll = Random.Shared.Next(0, totalWeight);
        var cumulative = 0;

        foreach (var entry in probabilities)
        {
            cumulative += entry.Value;
            if (roll < cumulative)
                return entry.Key;
        }

        // Fallback
        return SceneType.ChangeBiome;
    }




    private async Task<Scene> GenerateScene(Biome currentBiome)
    {
        // Get Type of scene
        IEnumerable<Scene> candidateScenes;
        var selectedType = GetRandomSceneTypeByBiome(currentBiome);

        if (selectedType == SceneType.ChangeBiome)
        {
            candidateScenes = await _repoScene.FetchAllByTypeAndBiome(null, SceneType.ChangeBiome);  // change biome no needs to have the same biome that current biome
        }
        else
        {
            candidateScenes = await _repoScene.FetchAllByTypeAndBiome(currentBiome, selectedType);
        }

        var scenesList = candidateScenes.ToList();

        // If theres no scene in the list 
        if (!scenesList.Any())
        {
            scenesList = (await _repoScene.FetchAllByTypeAndBiome(
                null,
                SceneType.ChangeBiome
            )).ToList();
        }

        // Pick random scene
        var randomScene = scenesList[Random.Shared.Next(scenesList.Count)];
        return randomScene;
    }


    private Game SetCurrentUserActionsToGame(Game game)
    {
        var userActions = new List<UserAction>();
        var currentScenes = game.GetCurrentScenes();

        // Inventory-based actions
        if (game.GetCharacter().GetInventoryList().Count > 0)
        {
            userActions.Add(UserAction.UseItem);
            userActions.Add(UserAction.DropItem);
        }

        // CurrenScenes-based actions
        if (currentScenes.Count == 1)
        {
            var scene = currentScenes.First();

            switch (scene)
            {
                case FinalScene:
                    userActions.Add(UserAction.MoveForward);
                    break;
                case NothingHappensScene:
                    userActions.Add(UserAction.MoveForward);
                    break;
                case ChangeBiomeScene:
                    userActions.Add(UserAction.MoveForward);
                    break;

                case ItemScene:
                    userActions.Add(UserAction.MoveForward);
                    userActions.Add(UserAction.GetItem);
                    userActions.Add(UserAction.UseCurrentSceneItem);
                    break;

                case TradeScene:
                    userActions.Add(UserAction.MoveForward);
                    userActions.Add(UserAction.BuyItems);
                    userActions.Add(UserAction.SellItems);
                    break;

                case EnemyScene enemyScene:
                    userActions.Add(UserAction.AttackEnemyWithItem);
                    userActions.Add(UserAction.AttackEnemyWithoutItem);
                    game = game.SetCurrentEnemy((scene as EnemyScene).GetEnemy());
                    break;
            }
        }
        else
        {
            userActions.Add(UserAction.MoveForward);
        }

        return game.SetCurrentUserActions(userActions);
    }



    //-----------------------------------------------------------------------------MAIN-FUNCTION--------------------------------------------------------------------//
    public async Task<Game?> GenerateNewSceneToGame(Guid idSceneSelected, Game game)
    {

        int HungryByRound = 5;

        if (game == null)
            throw new ArgumentNullException(nameof(game));

        // 1- CHECK VALIDATIONS
        // If game is finished
        if (game.GetGameStatus() == GameStatus.PlayerDeath || game.GetGameStatus() == GameStatus.GameWon)
        {
            return game;
        }
        if (game.GetCompletedScenes().Count > game.GetNumberScenesToFinish() - 1)
        {
            Game? gameFinished = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetCharacter(), game.GetNumberScenesToFinish(),
            game.GetCompletedScenes(), game.GetFinalScene(), game.GetCurrentScenes(), game.GetCurrentUserAction(), GameStatus.GameWon, game.GetCurrentEnemy());

            return gameFinished;
        }
        // if can move forward
        if (!game.GetCurrentUserAction().Any(userAction => userAction == UserAction.MoveForward))
        {
            return game;
        }


        // 2- SEARCH SCENES SELECTED AND ADD TO COMPLETED SCENES IF THERE IS ONLY ONE CURRENT SCENE
        Scene? sceneSelected = game.GetCurrentScenes()
            .FirstOrDefault(s => s.GetGuid() == idSceneSelected);

        if (sceneSelected == null)
            throw new InvalidOperationException($"Scene with ID {idSceneSelected} not found in current scenes.");

        if (game.GetCurrentScenes().Count == 1)
        {
            game = game.AddCompletedScene(sceneSelected);
        }
        else
        {
            game = game.SetCurrentScenes([sceneSelected]);
            game = SetCurrentUserActionsToGame(game);
            return game;
        }


        // 3- GENERATE NEW CURRENT SCENES AND CURRENT USER ACTIONS
        var newScenes = new List<Scene>();

        if (game.GetCompletedScenes().Count >= game.GetNumberScenesToFinish()) // If user reach last scene
        {
            newScenes = [game.GetFinalScene()];

        }
        else
        {
            // Generate randomly 1 or 2 scenes 
            var random = new Random();
            int numberOfScenesToGenerate = random.Next(1, 3);

            for (int i = 0; i < numberOfScenesToGenerate; i++)
            {
                Scene randomScene = await GenerateScene(sceneSelected.GetBiome());
                newScenes.Add(randomScene);
            }
        }
        game = game.SetCurrentScenes(newScenes);

        game = SetCurrentUserActionsToGame(game);


        // GIVE EFFECTS
        game = game.SetCharacter(game.GetCharacter().GetHungry(HungryByRound));

        if (game.GetCharacter().GetCurrentFoodPoints() <= 0)
        {
            game = game.SetGameStatus(GameStatus.PlayerDeath);
            return game;
        }


        // 5- SAVE GAME IN REPOSITORY AND RETURN GAME
        Game? gameSaved = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetCharacter(), game.GetNumberScenesToFinish(),
        game.GetCompletedScenes(), game.GetFinalScene(), game.GetCurrentScenes(), game.GetCurrentUserAction(), GameStatus.GameInProgress, game.GetCurrentEnemy());

        return gameSaved;
    }

}