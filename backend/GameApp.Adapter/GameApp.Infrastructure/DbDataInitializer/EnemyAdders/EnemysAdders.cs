using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Combat;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;

public class EnemysAdder : IEnemysAdder
{
    public static readonly Enemy Slime =
       new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Slime"),
            healthPoints: 30,
            attackDamage: 3,
            speedAttack: 2,
            new CriticalDamage(criticalProbability: 5, extraDamage: 5),
            rewardMoney: 5
       );

    public static readonly Enemy Goblin =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Goblin"),
            healthPoints: 50,
            attackDamage: 7,
            speedAttack: 4,
            new CriticalDamage(criticalProbability: 5, extraDamage: 10),
            rewardMoney: 10
        );

    public static readonly Enemy Skeleton =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Skeleton"),
            healthPoints: 70,
            attackDamage: 8,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 5, extraDamage: 5),
            rewardMoney: 15
        );

    public static readonly Enemy Bandit =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Bandit"),
            healthPoints: 80,
            attackDamage: 10,
            speedAttack: 2,
            new CriticalDamage(criticalProbability: 10, extraDamage: 5),
            rewardMoney: 20
        );

    public static readonly Enemy Wyvern =
        new Enemy(
            EnemyDifficulty.Hard,
            new EnemyName("Wyvern"),
            healthPoints: 100,
            attackDamage: 15,
            speedAttack: 5,
            new CriticalDamage(criticalProbability: 10, extraDamage: 15),
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
