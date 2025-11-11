using GameApp.Domain.Entities;

namespace GameApp.Domain.Repositories;

public interface ISceneRepository
{
    public abstract Task<IEnumerable<Scene>> FetchAllAsync();
    
    public abstract Task<Scene?> FetchByIdAsync(Guid id);

    public abstract Task<Scene?> DeleteAsync(Guid id);
    
    public abstract Task<Scene?> SaveAsync(Scene scene);

    public abstract Task<Scene?> UpdateAsync(Guid id, Scene scene);
}
