using GameApp.Application.UseCases.EnemyUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.EnemyServices;


public class EnemyCreateService : EnemyCreateUseCase
{
    private readonly IEnemyRepository _repo;

    public EnemyCreateService(IEnemyRepository repo) => _repo = repo;

    public async Task<Enemy?> CreateEnemy(Enemy Enemy)
    {
        // Enemy name must be unique in the collection
        var existingEnemy = await _repo.FetchByName(Enemy.GetName());
        if (existingEnemy is not null)
        {
            Console.WriteLine($"Enemy name {Enemy.GetName()} exist");
            return null;
        }
        return await _repo.SaveAsync(Enemy);
    }
}