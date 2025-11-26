using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Domain.Entities;

// Abtract entity class for a general scene
public abstract class Scene
{
    private readonly Guid Id;
    private readonly SceneName Name;
    private readonly SceneDescription Description;
    private readonly Biome Biome;

    // constructor EF
    protected Scene() { }

    // Default Constructor
    public Scene(SceneName name, SceneDescription description, Biome biome)
    {
        Id = Guid.NewGuid();

        Name = name;
        Description = description;
        Biome = biome;
    }

    // Restore Constructor
    public Scene(Guid id, SceneName name, SceneDescription description, Biome biome)
    {
        Id = id;
        Name = name;
        Description = description;
        Biome = biome;
    }

    // Getter
    public Guid GetGuid() => Id;
    public SceneName GetName() => Name;
    public SceneDescription GetDescription() => Description;
    public Biome GetBiome() => Biome;


}