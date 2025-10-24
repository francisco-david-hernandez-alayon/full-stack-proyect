using GameApp.Application.UseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.Services;

public class GameCreateService : GameCreateUseCase
{
    private readonly IGameRepository _repo;

    public GameCreateService(IGameRepository repo) => _repo = repo;

    public async Task<Game?> CreateGameAsync(Character character, int numberScenesToFinish, NothingHappensScene finalScene)
    {
        var game = new Game(character, numberScenesToFinish, finalScene);
        return await _repo.SaveAsync(game);
    }
}