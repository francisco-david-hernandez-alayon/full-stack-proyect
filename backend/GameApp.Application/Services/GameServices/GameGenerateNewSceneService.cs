using GameApp.Domain.Entities;
using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Repositories;
using GameApp.Domain.Entities.Scenes;

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

        // Search scenes selected and add to completed scenes
        Scene? sceneSelected = game.GetCurrentScenes()
            .FirstOrDefault(s => s.GetGuid() == idSceneSelected);

        if (sceneSelected == null)
            throw new InvalidOperationException($"Scene with ID {idSceneSelected} not found in current scenes.");

        game = game.AddCompletedScene(sceneSelected);


        // Generate new scene
        var allScenes = (await _repoScene.FetchAllAsync()).ToList();

        if (allScenes.Count == 0)
            throw new InvalidOperationException("No scenes available in repository.");

        var random = new Random();
        Scene newScene = allScenes[random.Next(allScenes.Count)];

        Console.WriteLine($"Generated scene: {newScene.GetGuid()} - {newScene.GetName().GetName()} - {newScene.GetDescription().GetDescription()} - Biome: {newScene.GetBiome()}");


        game = game.SetCurrentScenes(new List<Scene> { newScene });

        // save in repo
        Game? gameSaved = await _gameUpdateService.UpdateGame(game.GetGuid(), game.GetCharacter(), game.GetNumberScenesToFinish(), 
        game.GetCompletedScenes(), game.GetFinalScene(), game.GetCurrentScenes(), game.GetCurrentUserAction(), game.GetCurrentEnemy());

        return gameSaved;
    }

}