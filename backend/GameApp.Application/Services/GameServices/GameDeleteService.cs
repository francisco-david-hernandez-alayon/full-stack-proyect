using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.GameServices;

public class GameDeleteService : GameDeleteUseCase
{
    private readonly IGameRepository _repo;

    public GameDeleteService(IGameRepository repo) => _repo = repo;

    public async Task<Game?> DeleteGameAsync(Guid id)
    {
        return await _repo.DeleteAsync(id);
    }
}