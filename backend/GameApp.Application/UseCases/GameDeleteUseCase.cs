using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases;

public interface GameDeleteUseCase
{
    public Task<Game?> DeleteGameAsync(Guid id);
}