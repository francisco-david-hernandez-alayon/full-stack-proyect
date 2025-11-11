using GameApp.Domain.Entities;

namespace GameApp.Domain.Repositories;

public interface IGameRepository
{
    public abstract Task<IEnumerable<Game>> FetchAllAsync();
    
    public abstract Task<Game?> FetchByIdAsync(Guid id);

    public abstract Task<Game?> DeleteAsync(Guid id);
    
    public abstract Task<Game?> SaveAsync(Game game);

    public abstract Task<Game?> UpdateAsync(Guid id, Game game);
}
