using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;

public class EnemysAdder : IEnemysAdder
{
    private static readonly Enemy _slime =
       new Enemy(
           new EnemyName("Slime"),
           healthPoints: 20,
           attackDamage: 3,
           speedAttack: 2,
           rewardMoney: 5
       );

    private static readonly Enemy _goblin =
        new Enemy(
            new EnemyName("Goblin"),
            healthPoints: 35,
            attackDamage: 6,
            speedAttack: 3,
            rewardMoney: 10
        );

    private static readonly Enemy _skeleton =
        new Enemy(
            new EnemyName("Skeleton"),
            healthPoints: 50,
            attackDamage: 8,
            speedAttack: 4,
            rewardMoney: 15
        );

    private static readonly Enemy _orcWarrior =
        new Enemy(
            new EnemyName("Orc Warrior"),
            healthPoints: 85,
            attackDamage: 12,
            speedAttack: 3,
            rewardMoney: 25
        );

    private static readonly Enemy _darkWolf =
        new Enemy(
            new EnemyName("Dark Wolf"),
            healthPoints: 60,
            attackDamage: 10,
            speedAttack: 5,
            rewardMoney: 20
        );


    // Getters
    public static Enemy Slime => _slime;
    public static Enemy Goblin => _goblin;
    public static Enemy Skeleton => _skeleton;
    public static Enemy OrcWarrior => _orcWarrior;
    public static Enemy DarkWolf => _darkWolf;


    public static void AddEnemys(List<Enemy> enemys)
    {
        enemys.AddRange(new List<Enemy>
        {
            _slime,
            _goblin,
            _skeleton,
            _orcWarrior,
            _darkWolf
        });
    }

}
