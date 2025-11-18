using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneCreateUseCase
{
    public Task<Scene?> CreateScene(Scene scene);
}