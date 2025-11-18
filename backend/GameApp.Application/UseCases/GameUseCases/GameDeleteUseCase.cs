using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameDeleteUseCase
{
    public Task<Game?> DeleteGame(Guid id);
}