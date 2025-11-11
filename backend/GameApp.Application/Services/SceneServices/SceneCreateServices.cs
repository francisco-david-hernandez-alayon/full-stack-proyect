using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
namespace GameApp.Application.Services.SceneServices;

public class SceneCreateService : SceneCreateUseCase
{
    private readonly ISceneRepository _repo;

    public SceneCreateService(ISceneRepository repo) => _repo = repo;

    public async Task<Scene?> CreateSceneAsync(Scene scene)
    {
        return await _repo.SaveAsync(scene);
    }
}