

using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Application.UseCases.EnemyUseCases;

public interface EnemyGetUseCase
{
    public Task<Enemy?> GetEnemy(Guid id);

    public Task<Enemy?> GetEnemyByName(EnemyName name);

    public Task<IEnumerable<Enemy>> GetAllEnemys();
}