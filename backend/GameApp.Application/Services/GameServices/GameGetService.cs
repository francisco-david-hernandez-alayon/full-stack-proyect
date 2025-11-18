using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.GameServices;

public class GameGetService : GameGetUseCase
{
    private IGameRepository _repo;

    public GameGetService(IGameRepository repo)
    {
        _repo = repo;
    }

    public async Task<Game?> GetGame(Guid id)
    {
        return await _repo.FetchByIdAsync(id);
    }

    public async Task<IEnumerable<Game>> GetAllGames()
    {
        return await _repo.FetchAllAsync();
    }
}
