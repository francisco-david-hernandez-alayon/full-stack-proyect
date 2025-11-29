using GameApp.Domain.Entities;


namespace GameApp.Application.UseCases.EnemyUseCases;

public interface EnemyDeleteUseCase
{
    public Task<Enemy?> DeleteEnemy(Guid id);
}