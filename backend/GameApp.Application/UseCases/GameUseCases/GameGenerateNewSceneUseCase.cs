using GameApp.Domain.Entities;

namespace GameApp.Application.UseCases.GameUseCases;

public interface GameGenerateNewSceneUseCase
{
    public Task<Game?> GenerateNewSceneToGame(Guid idSceneSelected, Game game);
}