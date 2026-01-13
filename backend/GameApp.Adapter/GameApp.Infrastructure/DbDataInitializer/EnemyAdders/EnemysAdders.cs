using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Combat;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;

public class EnemysAdder : IEnemysAdder
{
    // EASY
    public static readonly Enemy Slime =
       new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Slime"),
            healthPoints: 25,
            attackDamage: 2,
            speedAttack: 2,
            new CriticalDamage(criticalProbability: 5, extraDamage: 2),
            rewardMoney: 5
       );

    public static readonly Enemy GiantRat =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Giant rat"),
            healthPoints: 30,
            attackDamage: 3,
            speedAttack: 2,
            new CriticalDamage(criticalProbability: 5, extraDamage: 2),
            rewardMoney: 7
    );

    public static readonly Enemy Wolf =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Wolf"),
            healthPoints: 40,
            attackDamage: 4,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 5, extraDamage: 3),
            rewardMoney: 14
    );

    public static readonly Enemy Scorpion =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Scorpion"),
            healthPoints: 15,
            attackDamage: 1,
            speedAttack: 1,
            new CriticalDamage(criticalProbability: 25, extraDamage: 29),
            rewardMoney: 7
    );

    public static readonly Enemy Goblin =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Goblin"),
            healthPoints: 40,
            attackDamage: 3,
            speedAttack: 4,
            new CriticalDamage(criticalProbability: 5, extraDamage: 10),
            rewardMoney: 15
        );
    
    public static readonly Enemy Bandit =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Bandit"),
            healthPoints: 50,
            attackDamage: 7,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 10, extraDamage: 5),
            rewardMoney: 20
    );

    public static readonly Enemy PossessedSkeleton =
        new Enemy(
            EnemyDifficulty.Easy,
            new EnemyName("Possessed Skeleton"),
            healthPoints: 70,
            attackDamage: 3,
            speedAttack: 1,
            new CriticalDamage(criticalProbability: 5, extraDamage: 7),
            rewardMoney: 20
        );

    

    


    // NORMAL
    public static readonly Enemy Thieve =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Thieve"),
            healthPoints: 50,
            attackDamage: 10,
            speedAttack: 5,
            new CriticalDamage(criticalProbability: 25, extraDamage: 15),
            rewardMoney: 30
    );

    public static readonly Enemy Sandcrawler =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Sandcrawler"),
            healthPoints: 40,
            attackDamage: 15,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 10, extraDamage: 10),
            rewardMoney: 30
    );

    public static readonly Enemy SwampCaiman =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Swamp caiman"),
            healthPoints: 55,
            attackDamage: 12,
            speedAttack: 4,
            new CriticalDamage(criticalProbability: 5, extraDamage: 3),
            rewardMoney: 35
    );
    
    public static readonly Enemy Bear =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Bear"),
            healthPoints: 80,
            attackDamage: 10,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 5, extraDamage: 3),
            rewardMoney: 37
    );

    public static readonly Enemy RoyalKnight =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Royal knight"),
            healthPoints: 70,
            attackDamage: 10,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 10, extraDamage: 5),
            rewardMoney: 35
    );

    public static readonly Enemy RedDaggerAssassin =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Red Dagger Assassin"),
            healthPoints: 60,
            attackDamage: 10,
            speedAttack: 5,
            new CriticalDamage(criticalProbability: 50, extraDamage: 10),
            rewardMoney: 40
    );

    public static readonly Enemy StoneGolem =
        new Enemy(
            EnemyDifficulty.Normal,
            new EnemyName("Stone Golem"),
            healthPoints: 100,
            attackDamage: 10,
            speedAttack: 1,
            new CriticalDamage(criticalProbability: 10, extraDamage: 5),
            rewardMoney: 50
    );



    // HARD
    public static readonly Enemy EliteGuard =
        new Enemy(
            EnemyDifficulty.Hard,
            new EnemyName("Elite Guard"),
            healthPoints: 100,
            attackDamage: 20,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 5, extraDamage: 5),
            rewardMoney: 70
    );

    public static readonly Enemy ForestStalker =
        new Enemy(
            EnemyDifficulty.Hard,
            new EnemyName("Forest Stalker"),
            healthPoints: 65,
            attackDamage: 30,
            speedAttack: 5,
            new CriticalDamage(criticalProbability: 20, extraDamage: 10),
            rewardMoney: 75
    );


    public static readonly Enemy GiantSandworm =
        new Enemy(
            EnemyDifficulty.Hard,
            new EnemyName("Giant Sandworm"),
            healthPoints: 140,
            attackDamage: 15,
            speedAttack: 3,
            new CriticalDamage(criticalProbability: 10, extraDamage: 10),
            rewardMoney: 80
        );
    
    public static readonly Enemy GiantSpider =
        new Enemy(
            EnemyDifficulty.Hard,
            new EnemyName("Giant spider"),
            healthPoints: 120,
            attackDamage: 20,
            speedAttack: 4,
            new CriticalDamage(criticalProbability: 30, extraDamage: 10),
            rewardMoney: 80
    );

    public static readonly Enemy Wyvern =
        new Enemy(
            EnemyDifficulty.Hard,
            new EnemyName("Wyvern"),
            healthPoints: 150,
            attackDamage: 18,
            speedAttack: 5,
            new CriticalDamage(criticalProbability: 10, extraDamage: 10),
            rewardMoney: 100
    );



    // BOSS
    public static readonly Enemy SwampBeast =
        new Enemy(
            EnemyDifficulty.Boss,
            new EnemyName("Swamp Beast"),
            healthPoints: 140,
            attackDamage: 15,
            speedAttack: 7,
            new CriticalDamage(criticalProbability: 40, extraDamage: 15),
            rewardMoney: 140
    );

    public static readonly Enemy WilliamKinonGhost =
        new Enemy(
            EnemyDifficulty.Boss,
            new EnemyName("Ghost of William Kinon"),
            healthPoints: 160,
            attackDamage: 25,
            speedAttack: 4,
            new CriticalDamage(criticalProbability: 10, extraDamage: 15),
            rewardMoney: 150
    );

    public static readonly Enemy SacredForestGuardian =
            new Enemy(
                EnemyDifficulty.Boss,
                new EnemyName("Guardian of the Sacred Forest"),
                healthPoints: 220,
                attackDamage: 20,
                speedAttack: 3,
                new CriticalDamage(criticalProbability: 10, extraDamage: 5),
                rewardMoney: 160
        );

    public static readonly Enemy FaraelCurse =
            new Enemy(
                EnemyDifficulty.Boss,
                new EnemyName("Curse of Farael"),
                healthPoints: 100,
                attackDamage: 40,
                speedAttack: 5,
                new CriticalDamage(criticalProbability: 0, extraDamage: 0),
                rewardMoney: 170
        );



    public static void AddEnemys(List<Enemy> enemys)
    {
        enemys.AddRange(new List<Enemy>
        {
            Slime, GiantRat, Wolf, Scorpion, Goblin, Bandit, PossessedSkeleton,
            Thieve, Sandcrawler, SwampCaiman, Bear, RoyalKnight, RedDaggerAssassin, StoneGolem,
            EliteGuard, ForestStalker, GiantSandworm, GiantSpider, Wyvern,
            SwampBeast, WilliamKinonGhost, SacredForestGuardian, FaraelCurse
            });
    }

}
