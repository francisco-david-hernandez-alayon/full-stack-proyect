using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;

public class EnemysAdder : IEnemysAdder
{
    public static readonly Enemy Slime =
       new Enemy(
           new EnemyName("Slime"),
           healthPoints: 20,
           attackDamage: 3,
           speedAttack: 2,
           rewardMoney: 5
       );

    public static readonly Enemy Goblin =
        new Enemy(
            new EnemyName("Goblin"),
            healthPoints: 35,
            attackDamage: 6,
            speedAttack: 3,
            rewardMoney: 10
        );

    public static readonly Enemy Skeleton =
        new Enemy(
            new EnemyName("Skeleton"),
            healthPoints: 50,
            attackDamage: 8,
            speedAttack: 4,
            rewardMoney: 15
        );

    public static readonly Enemy OrcWarrior =
        new Enemy(
            new EnemyName("Orc Warrior"),
            healthPoints: 85,
            attackDamage: 12,
            speedAttack: 3,
            rewardMoney: 25
        );

    public static readonly Enemy DarkWolf =
        new Enemy(
            new EnemyName("Dark Wolf"),
            healthPoints: 60,
            attackDamage: 10,
            speedAttack: 5,
            rewardMoney: 20
        );


    public static readonly Enemy FireImp =
    new Enemy(
        new EnemyName("Fire Imp"),
        healthPoints: 25,
        attackDamage: 5,
        speedAttack: 4,
        rewardMoney: 8
    );

    public static readonly Enemy IceGolem =
        new Enemy(
            new EnemyName("Ice Golem"),
            healthPoints: 90,
            attackDamage: 10,
            speedAttack: 2,
            rewardMoney: 30
        );

    public static readonly Enemy Bandit =
        new Enemy(
            new EnemyName("Bandit"),
            healthPoints: 40,
            attackDamage: 7,
            speedAttack: 4,
            rewardMoney: 12
        );

    public static readonly Enemy DarkMage =
        new Enemy(
            new EnemyName("Dark Mage"),
            healthPoints: 55,
            attackDamage: 12,
            speedAttack: 3,
            rewardMoney: 22
        );

    public static readonly Enemy GiantSpider =
        new Enemy(
            new EnemyName("Giant Spider"),
            healthPoints: 45,
            attackDamage: 6,
            speedAttack: 5,
            rewardMoney: 15
        );

    public static readonly Enemy Vampire =
        new Enemy(
            new EnemyName("Vampire"),
            healthPoints: 70,
            attackDamage: 14,
            speedAttack: 4,
            rewardMoney: 28
        );

    public static readonly Enemy Troll =
        new Enemy(
            new EnemyName("Troll"),
            healthPoints: 100,
            attackDamage: 15,
            speedAttack: 2,
            rewardMoney: 35
        );

    public static readonly Enemy Wraith =
        new Enemy(
            new EnemyName("Wraith"),
            healthPoints: 50,
            attackDamage: 9,
            speedAttack: 6,
            rewardMoney: 20
        );

    public static readonly Enemy Necromancer =
        new Enemy(
            new EnemyName("Necromancer"),
            healthPoints: 60,
            attackDamage: 11,
            speedAttack: 3,
            rewardMoney: 25
        );

    public static readonly Enemy Wyvern =
        new Enemy(
            new EnemyName("Wyvern"),
            healthPoints: 80,
            attackDamage: 16,
            speedAttack: 5,
            rewardMoney: 40
        );


    public static void AddEnemys(List<Enemy> enemys)
    {
        enemys.AddRange(new List<Enemy>
        {
            Slime,
            Goblin,
            Skeleton,
            OrcWarrior,
            DarkWolf,
            FireImp,
            IceGolem,
            Bandit,
            DarkMage,
            GiantSpider,
            Vampire,
            Troll,
            Wraith,
            Necromancer,
            Wyvern
        });
    }

}
