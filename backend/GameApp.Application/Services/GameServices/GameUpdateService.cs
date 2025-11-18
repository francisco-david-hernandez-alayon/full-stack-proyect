using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.Services.GameServices;

public class GameUpdateService : GameUpdateUseCase
{
    private readonly IGameRepository _repo;

    public GameUpdateService(IGameRepository repo) => _repo = repo;

    public async Task<Game?> UpdateGame(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions, Enemy? currentEnemy)
    {
        var game = await _repo.FetchByIdAsync(id);
        if (game is null)
        {
            Console.WriteLine($"Game to update with id {id} not found."); 
            return null;
        }

        Game updatedGame = game.UpdateGame(character, numberScenesToFinish, completedScenes, finalScene, listCurrentScenes, listCurrentUserActions, currentEnemy);
        return await _repo.UpdateAsync(id, updatedGame);
    }
}
