using GameApp.Application.UseCases.EnemyUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.EnemyServices;

public class EnemyDeleteService : EnemyDeleteUseCase
{
    private readonly IEnemyRepository _repo;

    public EnemyDeleteService(IEnemyRepository repo) => _repo = repo;

    public async Task<Enemy?> DeleteEnemy(Guid id)
    {
        return await _repo.DeleteAsync(id);
    }
}