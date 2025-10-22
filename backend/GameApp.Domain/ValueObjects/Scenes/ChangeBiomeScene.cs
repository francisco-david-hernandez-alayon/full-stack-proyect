using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where the biome changes
public class ChangeBiomeScene : Scene
{
    public Biomes BiomeToChange { get; private set; }

    // Constructor
    public ChangeBiomeScene(SceneName name, SceneDescription description, Biomes biome, Biomes biomeToChange)
        : base(name, description, biome)
    {
        BiomeToChange = biomeToChange;
    }

    // Getters
    public Biomes GetBiomeToChange() => BiomeToChange;

    // Setters
    public ChangeBiomeScene SetBiomeToChange(Biomes newBiomeToChange) =>
        new ChangeBiomeScene(GetName(), GetDescription(), GetBiome(), newBiomeToChange);

    // To string
    public override string ToString() =>
        $"ChangeBiomeScene: {GetName()} - Description={GetDescription()}, CurrentBiome={GetBiome()}, NewBiome={BiomeToChange}";
}
