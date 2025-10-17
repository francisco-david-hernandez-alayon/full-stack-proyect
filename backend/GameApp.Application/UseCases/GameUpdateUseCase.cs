using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.UseCases;

public interface GameUpdateUseCase
{
    public Task<Game?> UpdateGameAsync(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, Scene finalScene);
}