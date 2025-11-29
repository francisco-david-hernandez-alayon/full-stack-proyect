using GameApp.Application.UseCases.EnemyUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Application.Services.EnemyServices;


public class EnemyGetService : EnemyGetUseCase
{
    private readonly IEnemyRepository _repo;

    public EnemyGetService(IEnemyRepository repo) => _repo = repo;

    public async Task<Enemy?> GetEnemy(Guid id)
    {
        return await _repo.FetchByIdAsync(id);
    }

    public async Task<Enemy?> GetEnemyByName(EnemyName name)
    {
        return await _repo.FetchByName(name);
    }

    public async Task<IEnumerable<Enemy>> GetAllEnemys()
    {
        return await _repo.FetchAllAsync();
    }
}