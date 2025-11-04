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

    // To string
    public override string ToString() =>
        $"ChangeBiomeScene: {GetName()} - Description={GetDescription()}, BiomeToChange={GetBiome()}";
}
