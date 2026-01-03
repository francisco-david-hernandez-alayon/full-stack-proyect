using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Application.Services.GameServices;

public class GameCreateService : GameCreateUseCase
{
    private readonly IGameRepository _repo;

    public GameCreateService(IGameRepository repo) => _repo = repo;

    public async Task<Game?> CreateGame(GameDifficulty difficulty, Character character, int numberScenesToFinish, FinalScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions)
    {
        var game = new Game(difficulty, character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions);
        return await _repo.SaveAsync(game);
    }
}