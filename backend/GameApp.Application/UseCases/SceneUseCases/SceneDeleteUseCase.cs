using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneDeleteUseCase
{
    public Task<Scene?> DeleteScene(Guid id);
}