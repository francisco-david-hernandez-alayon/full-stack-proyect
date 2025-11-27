using GameApp.Domain.Entities.Scenes;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneDeleteUseCase
{
    public Task<Scene?> DeleteScene(Guid id);
}