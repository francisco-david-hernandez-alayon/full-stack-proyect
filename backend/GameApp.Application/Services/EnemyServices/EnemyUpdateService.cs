using GameApp.Application.UseCases.EnemyUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.EnemyServices;

public class EnemyUpdateService : EnemyUpdateUseCase
{
    private readonly IEnemyRepository _repo;

    public EnemyUpdateService(IEnemyRepository repo) => _repo = repo;


    public async Task<Enemy?> UpdateEnemy(Guid id, Enemy Enemy)
    {
        var existingEnemy = await _repo.FetchByIdAsync(id);
        if (existingEnemy is null)
        {
            Console.WriteLine($"Enemy to update with id {id} not found.");
            return null;
        }

        // If the Enemy name is going to change
        if (!existingEnemy.GetName().Equals(Enemy.GetName()))
        {
            var EnemyWithSameName = await _repo.FetchByName(Enemy.GetName());
            if (EnemyWithSameName is not null)  // Enemy name must be unique in the collection
            {
                Console.WriteLine($"Enemy with name '{Enemy.GetName()}' already exists. Cannot update Enemy");
                return null;
            }
        }

        return await _repo.UpdateAsync(id, Enemy);
    }
}