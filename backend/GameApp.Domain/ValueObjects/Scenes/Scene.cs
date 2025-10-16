using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Abtract class for a general scene
public abstract class Scene
{
    protected readonly SceneName _name;
    protected readonly SceneDescription _description;
    protected readonly Biomes _biome;

    // Constructor
    public Scene(SceneName name, SceneDescription description, Biomes biome)
    {
        _name = name;
        _description = description;
        _biome = biome;
    }

    // Getter
    public SceneName GetName() => _name;
    public SceneDescription GetDescription() => _description;
    public Biomes GetBiomes() => _biome;


}