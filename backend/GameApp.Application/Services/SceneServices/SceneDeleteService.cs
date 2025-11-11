using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace SceneApp.Application.Services.SceneServices;

public class SceneDeleteService : SceneDeleteUseCase
{
    private readonly ISceneRepository _repo;

    public SceneDeleteService(ISceneRepository repo) => _repo = repo;

    public async Task<Scene?> DeleteSceneAsync(Guid id)
    {
        return await _repo.DeleteAsync(id);
    }
}