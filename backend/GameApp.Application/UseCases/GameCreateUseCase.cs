using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.UseCases;

public interface GameCreateUseCase
{
    public Task<Game?> CreateGameAsync(Character character, int numberScenesToFinish, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions);
}