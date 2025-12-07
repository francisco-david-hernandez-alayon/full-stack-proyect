using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameUpdateUseCase
{
    public Task<Game?> UpdateGame(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions, GameStatus status, Enemy? currentEnemy);
}