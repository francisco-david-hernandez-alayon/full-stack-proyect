using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameUpdateUseCase
{
    public Task<Game?> UpdateGameAsync(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions, Enemy? currentEnemy);
}