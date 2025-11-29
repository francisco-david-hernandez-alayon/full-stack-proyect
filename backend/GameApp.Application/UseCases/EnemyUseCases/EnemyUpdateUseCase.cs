using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.EnemyUseCases;

public interface EnemyUpdateUseCase
{
    public Task<Enemy?> UpdateEnemy(Guid id, Enemy Enemy);
}