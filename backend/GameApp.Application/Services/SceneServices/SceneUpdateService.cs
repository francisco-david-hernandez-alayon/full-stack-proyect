using GameApp.Application.UseCases.SceneUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Application.Services.SceneServices;

public class SceneUpdateService : SceneUpdateUseCase
{
    private readonly ISceneRepository _repo;

    public SceneUpdateService(ISceneRepository repo) => _repo = repo;

    public async Task<Scene?> UpdateSceneAsync(Guid id, Scene scene)
    {
        var Scene = await _repo.FetchByIdAsync(id);
        if (Scene is null)
        {
            Console.WriteLine($"Scene to update with id {id} not found."); 
            return null;
        }
        return await _repo.UpdateAsync(id, scene);
    }
}
