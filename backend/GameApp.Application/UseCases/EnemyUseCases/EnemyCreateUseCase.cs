using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.EnemyUseCases;

public interface EnemyCreateUseCase
{
    public Task<Enemy?> CreateEnemy(Enemy Enemy);
}