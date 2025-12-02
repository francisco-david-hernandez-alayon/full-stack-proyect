using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Domain.Entities.Scenes;

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

    // Setters 
    public ChangeBiomeScene SetSceneName(SceneName newName) =>
    new ChangeBiomeScene(GetGuid(), newName, GetDescription(), GetBiome());

    public ChangeBiomeScene SetSceneDescription(SceneDescription newDescription) =>
    new ChangeBiomeScene(GetGuid(), GetName(), newDescription, GetBiome());

    public ChangeBiomeScene SetBiome(Biome newBiome) =>
    new ChangeBiomeScene(GetGuid(), GetName(), GetDescription(), newBiome);

    // To string
    public override string ToString() =>
        $"ChangeBiomeScene({GetGuid()}): {GetName()} - {GetDescription()}, BiomeToChange={GetBiome()}";
}
