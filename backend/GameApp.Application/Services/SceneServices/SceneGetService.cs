using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace SceneApp.Application.Services.SceneServices;

public class SceneGetService : SceneGetUseCase
{
    private ISceneRepository _repo;

    public SceneGetService(ISceneRepository repo)
    {
        _repo = repo;
    }

    public async Task<Scene?> GetSceneAsync(Guid id)
    {
        return await _repo.FetchByIdAsync(id);
    }

    public async Task<IEnumerable<Scene>> GetAllScenesAsync()
    {
        return await _repo.FetchAllAsync();
    }
}
