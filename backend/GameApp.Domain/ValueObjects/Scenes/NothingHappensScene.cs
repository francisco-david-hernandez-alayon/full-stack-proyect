using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where nothing happens you just move forward
public class NothingHappensScene : Scene
{

    // Constructor
    public NothingHappensScene(SceneName name, SceneDescription description, Biomes biome)
    : base(name, description, biome)
    {

    }

    // Setters 
    public NothingHappensScene SetSceneName(SceneName newName) =>
    new NothingHappensScene(newName, GetDescription(), GetBiomes());

    public NothingHappensScene SetSceneDescription(SceneDescription newDescription) =>
    new NothingHappensScene(GetName(), newDescription, GetBiomes());

    public NothingHappensScene SetBiome(Biomes newBiome) =>
    new NothingHappensScene(GetName(), GetDescription(), newBiome);

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} NothingHappens Scene: " +
               $"Description={_description}, Biome={_biome}, ";
    }

}