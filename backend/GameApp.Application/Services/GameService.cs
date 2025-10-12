using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services;

public class GameService
{
    private readonly IGameRepository _repo;
    public GameService(IGameRepository repo) => _repo = repo;

    public Task<IEnumerable<Game>> GetAllGamesAsync() => _repo.GetAllAsync();
    public Task AddGameAsync(Game game) => _repo.AddAsync(game);
}
