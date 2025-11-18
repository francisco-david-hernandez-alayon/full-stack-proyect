using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameGetUseCase
{
    public Task<Game?> GetGame(Guid id);
    
    public Task<IEnumerable<Game>> GetAllGames();
}