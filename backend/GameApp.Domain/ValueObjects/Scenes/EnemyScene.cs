using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for a scene where you have to fight an enemy
public class EnemyScene : Scene
{
    private readonly Enemy Enemy;

    // Constructor
    public EnemyScene(SceneName name, SceneDescription description, Biome biome, Enemy enemy)
    : base(name, description, biome)
    {
        Enemy = enemy;
    }

    // Getter
    public Enemy GetEnemy() => Enemy;

    // Setters 
    public EnemyScene SetSceneName(SceneName newName) =>
    new EnemyScene(newName, GetDescription(), GetBiome(), Enemy);

    public EnemyScene SetSceneDescription(SceneDescription newDescription) =>
    new EnemyScene(GetName(), newDescription, GetBiome(), Enemy);

    public EnemyScene SetBiome(Biome newBiome) =>
    new EnemyScene(GetName(), GetDescription(), newBiome, Enemy);

    public EnemyScene SetEnemy(Enemy newEnemy) =>
    new EnemyScene(GetName(), GetDescription(), GetBiome(), newEnemy);

    // To string
    public override string ToString()
    {
        return $"{GetName()} Enemy Scene: " +
               $"Description={GetDescription()}, Biome={GetBiome()}, " +
               $"Enemy={Enemy}";
    }
}