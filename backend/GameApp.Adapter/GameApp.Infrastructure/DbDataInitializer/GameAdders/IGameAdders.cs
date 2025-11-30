using GameApp.Domain.Entities;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.GameAdders;

// Interface for Enemys adder to feed initial db
public interface IGameAdders
{
    static abstract void AddGames(List<Game> games);
}