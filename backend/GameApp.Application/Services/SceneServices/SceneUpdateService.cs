using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.SceneServices;

public class SceneUpdateService : SceneUpdateUseCase
{
    private readonly ISceneRepository _repo;

    public SceneUpdateService(ISceneRepository repo) => _repo = repo;

    public async Task<Scene?> UpdateSceneAsync(Guid id, Scene scene)
    {
        var existingScene = await _repo.FetchByIdAsync(id);
        if (existingScene is null)
        {
            Console.WriteLine($"Scene to update with id {id} not found.");
            return null;
        }

        // If the scene name is going to change
        if (!existingScene.GetName().Equals(scene.GetName()))
        {
            var sceneWithSameName = await _repo.FetchByName(scene.GetName());
            if (sceneWithSameName is not null)  // scene name must be unique in the collection
            {
                Console.WriteLine($"Scene with name '{scene.GetName()}' already exists. Cannot update scene");
                return null;
            }
        }

        return await _repo.UpdateAsync(id, scene);
    }
}
