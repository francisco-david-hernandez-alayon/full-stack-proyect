using GameApp.Application.Enumerates;
using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Scenes;

namespace SceneApp.Application.Services.SceneServices;

public class SceneGetService : SceneGetUseCase
{
    private ISceneRepository _repo;

    public SceneGetService(ISceneRepository repo)
    {
        _repo = repo;
    }

    public async Task<Scene?> GetScene(Guid id)
    {
        return await _repo.FetchByIdAsync(id);
    }

    public async Task<Scene?> GetSceneByName(SceneName name)
    {
        return await _repo.FetchByName(name);
    }

    public async Task<IEnumerable<Scene>> GetAllScenes()
    {
        return await _repo.FetchAllAsync();
    }

    public async Task<IEnumerable<FinalScene>> GetAllFinalScenes()
    {
        return await _repo.FetchAllFinalScenes();
    }
}
