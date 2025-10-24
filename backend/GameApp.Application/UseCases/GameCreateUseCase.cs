using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.UseCases;

public interface GameCreateUseCase
{
    public Task<Game?> CreateGameAsync(Character character, int numberScenesToFinish, NothingHappensScene finalScene);
}