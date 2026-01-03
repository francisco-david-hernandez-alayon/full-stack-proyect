using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameCreateUseCase
{
    public Task<Game?> CreateGame(GameDifficulty difficulty, Character character, int numberScenesToFinish, FinalScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions);
}