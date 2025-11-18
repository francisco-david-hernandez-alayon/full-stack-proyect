using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneGetUseCase
{
    public Task<Scene?> GetScene(Guid id);

    public Task<Scene?> GetSceneByName(SceneName name);
    
    public Task<IEnumerable<Scene>> GetAllScenes();
}