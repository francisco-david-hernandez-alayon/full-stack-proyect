using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;

public class EnemysAdder : IEnemysAdder
{
    public static readonly Enemy Slime =
       new Enemy(
           new EnemyName("Slime"),
           healthPoints: 30,
           attackDamage: 3,
           speedAttack: 2,
           rewardMoney: 5
       );

    public static readonly Enemy Goblin =
        new Enemy(
            new EnemyName("Goblin"),
            healthPoints: 50,
            attackDamage: 7,
            speedAttack: 4,
            rewardMoney: 10
        );

    public static readonly Enemy Skeleton =
        new Enemy(
            new EnemyName("Skeleton"),
            healthPoints: 70,
            attackDamage: 8,
            speedAttack: 3,
            rewardMoney: 15
        );

    public static readonly Enemy Bandit =
        new Enemy(
            new EnemyName("Bandit"),
            healthPoints: 80,
            attackDamage: 10,
            speedAttack: 2,
            rewardMoney: 20
        );

    public static readonly Enemy Wyvern =
        new Enemy(
            new EnemyName("Wyvern"),
            healthPoints: 100,
            attackDamage: 15,
            speedAttack: 5,
            rewardMoney: 70
        );


    public static void AddEnemys(List<Enemy> enemys)
    {
        enemys.AddRange(new List<Enemy>
        {
            Slime,
            Goblin,
            Skeleton,
            Bandit,
            Wyvern
        });
    }

}
