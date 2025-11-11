using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where the biome changes in the biome atribute
public class ChangeBiomeScene : Scene
{

    // Constructor
    public ChangeBiomeScene(SceneName name, SceneDescription description, Biome biome)
        : base(name, description, biome)
    {
    }

    // Restore Constructor
    public ChangeBiomeScene(Guid id, SceneName name, SceneDescription description, Biome biome)
        : base(id, name, description, biome)
    {
    }

    // To string
    public override string ToString() =>
        $"ChangeBiomeScene({GetGuid()}): {GetName()} - {GetDescription()}, BiomeToChange={GetBiome()}";
}
