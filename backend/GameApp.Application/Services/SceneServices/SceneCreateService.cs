using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Repositories;
namespace GameApp.Application.Services.SceneServices;

public class SceneCreateService : SceneCreateUseCase
{
    private readonly ISceneRepository _repo;

    public SceneCreateService(ISceneRepository repo) => _repo = repo;

    public async Task<Scene?> CreateScene(Scene scene)
    {
        // scene name must be unique in the collection
        var existingScene = await _repo.FetchByName(scene.GetName());
        if (existingScene is not null)
        {
            Console.WriteLine($"Scene name {scene.GetName()} exist");
            return null;
        }
        return await _repo.SaveAsync(scene);
    }
}