using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where the biome changes
public class ChangeBiomeScene : Scene
{
    private readonly Biomes _biomeToChange;

    // Constructor
    public ChangeBiomeScene(SceneName name, SceneDescription description, Biomes biome, Biomes biomeToChange)
        : base(name, description, biome)
    {
        _biomeToChange = biomeToChange;
    }

    // Getters
    public Biomes GetBiomeToChange() => _biomeToChange;

    // Setters
    public ChangeBiomeScene SetBiomeToChange(Biomes newBiomeToChange) =>
        new ChangeBiomeScene(GetName(), GetDescription(), GetBiomes(), newBiomeToChange);

    // To string
    public override string ToString() =>
        $"ChangeBiomeScene: {GetName()} - Description={GetDescription()}, CurrentBiome={GetBiomes()}, NewBiome={_biomeToChange}";
}
