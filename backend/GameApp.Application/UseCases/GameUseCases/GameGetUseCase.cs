using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameGetUseCase
{
    public Task<Game?> GetGameAsync(Guid id);
    
    public Task<IEnumerable<Game>> GetAllGamesAsync();
}