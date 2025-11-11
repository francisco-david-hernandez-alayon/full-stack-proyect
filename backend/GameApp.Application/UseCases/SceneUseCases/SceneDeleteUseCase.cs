using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneDeleteUseCase
{
    public Task<Scene?> DeleteSceneAsync(Guid id);
}