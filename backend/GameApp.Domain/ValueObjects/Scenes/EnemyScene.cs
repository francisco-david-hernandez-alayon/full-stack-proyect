using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Enemies;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for a scene where you have to fight an enemy
public class EnemyScene : Scene
{
    public readonly Enemy _enemy;

    // Constructor
    public EnemyScene(SceneName name, SceneDescription description, Biomes biome, Enemy enemy)
    : base(name, description, biome)
    {
        _enemy = enemy;
    }

    // Getter
    public Enemy GetEnemy() => _enemy;

    // Setters 
    public EnemyScene SetSceneName(SceneName newName) =>
    new EnemyScene(newName, GetDescription(), GetBiomes(), _enemy);

    public EnemyScene SetSceneDescription(SceneDescription newDescription) =>
    new EnemyScene(GetName(), newDescription, GetBiomes(), _enemy);

    public EnemyScene SetBiome(Biomes newBiome) =>
    new EnemyScene(GetName(), GetDescription(), newBiome, _enemy);

    public EnemyScene SetEnemy(Enemy newEnemy) =>
    new EnemyScene(GetName(), GetDescription(), GetBiomes(), newEnemy);

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} Enemy Scene: " +
               $"Description={_description}, Biome={_biome}, " +
               $"Enemy={_enemy}";
    }
}