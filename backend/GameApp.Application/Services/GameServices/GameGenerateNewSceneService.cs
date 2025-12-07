using GameApp.Domain.Entities;
using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Repositories;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;

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

    public async Task<Game?> GenerateNewSceneToGame(Guid idSceneSelected, Game game)
    {
        if (game == null)
            throw new ArgumentNullException(nameof(game));

        // If game is finished
        if (game.GetCompletedScenes().Count >= game.GetNumberScenesToFinish())
        {
            Game? gameFinished = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetCharacter(), game.GetNumberScenesToFinish(),
            game.GetCompletedScenes(), game.GetFinalScene(), game.GetCurrentScenes(), game.GetCurrentUserAction(), GameStatus.GameWon, game.GetCurrentEnemy());

            return gameFinished;
        }

        // 1- SEARCH SCENES SELECTED AND ADD TO COMPLETED SCENES
        Scene? sceneSelected = game.GetCurrentScenes()
            .FirstOrDefault(s => s.GetGuid() == idSceneSelected);

        if (sceneSelected == null)
            throw new InvalidOperationException($"Scene with ID {idSceneSelected} not found in current scenes.");

        game = game.AddCompletedScene(sceneSelected);


        // 2- GENERATE NEW CURRENT SCENES
        // Get all scenes
        var allScenes = (await _repoScene.FetchAllAsync()).ToList();
        // FALTA TENER EN CUENTA EL BIOMA PARA SOLR GENERAR ESCENAS DEL MISMO BIOMA
        if (allScenes.Count == 0)
            throw new InvalidOperationException("No scenes available in repository.");

        var random = new Random();

        // Generate randomly 1 or 2 scenes 
        int numberOfScenesToGenerate = random.Next(1, 3);
        var newScenes = new List<Scene>();
        for (int i = 0; i < numberOfScenesToGenerate; i++)
        {
            Scene randomScene = allScenes[random.Next(allScenes.Count)];
            newScenes.Add(randomScene);
        }

        game = game.SetCurrentScenes(newScenes);




        // SAVE GAME IN REPOSITORY AND RETURN GAME
        Game? gameSaved = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetCharacter(), game.GetNumberScenesToFinish(),
        game.GetCompletedScenes(), game.GetFinalScene(), game.GetCurrentScenes(), game.GetCurrentUserAction(), GameStatus.GameInProgress, game.GetCurrentEnemy());

        return gameSaved;
    }

}