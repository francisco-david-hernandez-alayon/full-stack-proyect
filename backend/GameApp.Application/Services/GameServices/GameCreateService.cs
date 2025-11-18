using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.Services.GameServices;

public class GameCreateService : GameCreateUseCase
{
    private readonly IGameRepository _repo;

    public GameCreateService(IGameRepository repo) => _repo = repo;

    public async Task<Game?> CreateGame(Character character, int numberScenesToFinish, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions)
    {
        var game = new Game(character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions);
        return await _repo.SaveAsync(game);
    }
}