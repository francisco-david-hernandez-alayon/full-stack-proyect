using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Abtract class for a general scene
public abstract class Scene
{
    private readonly SceneName Name;
    private readonly SceneDescription Description;
    private readonly Biome Biome;

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