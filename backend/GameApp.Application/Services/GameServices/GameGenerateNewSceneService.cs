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






    //-----------------------------------------------------------------------------GENERATE-SCENE-ALGORITHM---------------------------------------------------------------------------//

    public static T GetRandomByWeight<T>(IEnumerable<KeyValuePair<T, int>> weights)
    where T : notnull
    {
        var totalWeight = weights.Sum(w => w.Value);
        if (totalWeight <= 0)
            throw new ArgumentException("Total weight must be greater than zero.");

        var roll = Random.Shared.Next(totalWeight);
        var cumulative = 0;

        foreach (var (key, weight) in weights)
        {
            cumulative += weight;
            if (roll < cumulative)
                return key;
        }

        throw new InvalidOperationException("Weighted selection failed.");
    }

    private SceneType GetRandomSceneTypeByBiome(Biome biome)
    {
        Dictionary<SceneType, int> biomeProbabilities = SceneProbabilitiesByBiome.Probabilities[biome];
        return GetRandomByWeight(biomeProbabilities);
    }

    private Scene GetRandomSceneFromListScenes(List<Scene> scenes, GameDifficulty difficulty)
    {
        Dictionary<SceneGoodness, int> sceneGoodnessWeights = SceneGoodnessWeights.Weights[difficulty];
        List<KeyValuePair<Scene, int>> sceneProbabilities = new List<KeyValuePair<Scene, int>>();

        foreach (var scene in scenes)
        {
            // Get the goodness of the scene
            SceneGoodness sceneGoodness;

            switch (scene)
            {
                case NothingHappensScene nothingScene:
                    sceneGoodness = SceneGoodness.Normal;
                    break;

                case ChangeBiomeScene changeScene:
                    sceneGoodness = SceneGoodness.Normal;
                    break;

                case ItemScene itemScene:

                    switch (itemScene.GetRewardItem().GetRarity())
                    {
                        case ItemRarity.Common:
                            sceneGoodness = SceneGoodness.Normal;
                            break;
                        case ItemRarity.Rare:
                            sceneGoodness = SceneGoodness.Good;
                            break;
                        case ItemRarity.Epic:
                            sceneGoodness = SceneGoodness.VeryGood;
                            break;
                        default:
                            sceneGoodness = SceneGoodness.Normal;
                            break;
                    }
                    break;

                case EnemyScene enemyScene:
                    switch (enemyScene.GetEnemy().GetDifficulty())
                    {
                        case EnemyDifficulty.Easy:
                            sceneGoodness = SceneGoodness.Normal;
                            break;
                        case EnemyDifficulty.Normal:
                            sceneGoodness = SceneGoodness.Bad;
                            break;
                        case EnemyDifficulty.Hard:
                            sceneGoodness = SceneGoodness.Bad;
                            break;
                        case EnemyDifficulty.Boss:
                            sceneGoodness = SceneGoodness.VeryBad;
                            break;
                        default:
                            sceneGoodness = SceneGoodness.Normal;
                            break;
                    }
                    break;

                case TradeScene tradeScene:
                    ItemRarity mayorRarity = ItemRarity.Common;

                    // Get item of mayor rarity
                    foreach (var item in tradeScene.GetMerchantItemsOffer())
                    {
                        if (mayorRarity == ItemRarity.Common)
                        {
                            if (item.GetRarity() == ItemRarity.Rare || item.GetRarity() == ItemRarity.Epic)
                            {
                                mayorRarity = item.GetRarity();
                            }

                        }
                        else if (mayorRarity == ItemRarity.Rare)
                        {
                            if (item.GetRarity() == ItemRarity.Epic)
                            {
                                mayorRarity = item.GetRarity();
                            }

                        }
                        else  // an item has epic rarity, so there's no need to keep searching for rarities to obtain the highest rarity
                        {
                            break;
                        }
                    }

                    // Select godness of scene form item rarity
                    switch (mayorRarity)
                    {
                        case ItemRarity.Common:
                            sceneGoodness = SceneGoodness.Normal;
                            break;
                        case ItemRarity.Rare:
                            sceneGoodness = SceneGoodness.Good;
                            break;
                        case ItemRarity.Epic:
                            sceneGoodness = SceneGoodness.VeryGood;
                            break;
                        default:
                            sceneGoodness = SceneGoodness.Normal;
                            break;
                    }
                    break;

                default:
                    sceneGoodness = SceneGoodness.Normal;
                    break;
            }


            // Add the scene with its weight and goodness
            var weight = sceneGoodnessWeights[sceneGoodness];
            sceneProbabilities.Add(
                new KeyValuePair<Scene, int>(scene, weight)
            );
        }

        Scene sceneGenerated = GetRandomByWeight(sceneProbabilities);


        Console.WriteLine("Scene probabilities: ");
        foreach (var kvp in sceneProbabilities)
        {
            Console.WriteLine($"--> Scene: {kvp.Key.GetType().Name} {kvp.Key.GetName()}, Weight: {kvp.Value})");
        }
        Console.WriteLine("Scene generated: " + sceneGenerated);

        return sceneGenerated;
    }



    private async Task<Scene> GenerateScene(Biome currentBiome, GameDifficulty difficulty)
    {
        // 1- Get Type of scene generated
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
        if (!scenesList.Any()) // If theres no scene in the list 
        {
            scenesList = (await _repoScene.FetchAllByTypeAndBiome(
                null,
                SceneType.ChangeBiome
            )).ToList();
        }

        // 2- Pick random scene of scenesList
        Scene randomScene = GetRandomSceneFromListScenes(scenesList, difficulty);

        // 3- Return scene
        return randomScene;
    }






    //-----------------------------------------------------------------------------MAIN-FUNCTION---------------------------------------------------------------------------//
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
            Game? gameFinished = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetDifficulty(), game.GetCharacter(), game.GetNumberScenesToFinish(),
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
                Scene randomScene = await GenerateScene(sceneSelected.GetBiome(), game.GetDifficulty());
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
        Game? gameSaved = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetDifficulty(), game.GetCharacter(), game.GetNumberScenesToFinish(),
        game.GetCompletedScenes(), game.GetFinalScene(), game.GetCurrentScenes(), game.GetCurrentUserAction(), GameStatus.GameInProgress, game.GetCurrentEnemy());

        return gameSaved;
    }

}