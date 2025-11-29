using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Domain.Repositories;

public interface IEnemyRepository
{
    public abstract Task<IEnumerable<Enemy>> FetchAllAsync();

    public abstract Task<Enemy?> FetchByIdAsync(Guid id);

    public abstract Task<Enemy?> FetchByName(EnemyName name);

    public abstract Task<Enemy?> DeleteAsync(Guid id);
    
    public abstract Task<Enemy?> SaveAsync(Enemy Enemy);

    public abstract Task<Enemy?> UpdateAsync(Guid id, Enemy Enemy);

    public abstract Task SeedAsync();
}
