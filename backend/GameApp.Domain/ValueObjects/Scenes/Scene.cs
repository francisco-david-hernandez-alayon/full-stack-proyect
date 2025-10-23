using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Abtract class for a general scene
public abstract class Scene
{
    public SceneName Name { get; private set; } = default!;
    public SceneDescription Description { get; private set; } = default!;
    public Biome Biome { get; private set; }

    // constructor EF
    protected Scene() { }

    // Constructor
    public Scene(SceneName name, SceneDescription description, Biome biome)
    {
        Name = name;
        Description = description;
        Biome = biome;
    }

    // Getter
    public SceneName GetName() => Name;
    public SceneDescription GetDescription() => Description;
    public Biome GetBiome() => Biome;


}