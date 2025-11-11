using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.SceneUseCases;

public interface SceneGetUseCase
{
    public Task<Scene?> GetSceneAsync(Guid id);
    
    public Task<IEnumerable<Scene>> GetAllScenesAsync();
}