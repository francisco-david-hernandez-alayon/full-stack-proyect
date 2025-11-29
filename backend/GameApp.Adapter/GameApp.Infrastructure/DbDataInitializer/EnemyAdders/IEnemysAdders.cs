using GameApp.Domain.Entities;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;

// Interface for Enemys adder to feed initial db
public interface IEnemysAdder
{
    static abstract void AddEnemys(List<Enemy> enemys);
}