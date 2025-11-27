using GameApp.Domain.Entities.Scenes;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneUpdateUseCase
{
    public Task<Scene?> UpdateScene(Guid id, Scene scene);
}