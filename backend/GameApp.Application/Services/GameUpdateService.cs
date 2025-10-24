using GameApp.Application.UseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.Services;

public class GameUpdateService : GameUpdateUseCase
{
    private readonly IGameRepository _repo;

    public GameUpdateService(IGameRepository repo) => _repo = repo;

    public async Task<Game?> UpdateGameAsync(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene)
    {
        var game = await _repo.FetchByIdAsync(id);
        if (game is null)
        {
            Console.WriteLine($"Game to update with id {id} not found."); 
            return null;
        }

        Game updatedGame = game.UpdateGame(character, numberScenesToFinish, completedScenes, finalScene);
        return await _repo.UpdateAsync(updatedGame);
    }
}
