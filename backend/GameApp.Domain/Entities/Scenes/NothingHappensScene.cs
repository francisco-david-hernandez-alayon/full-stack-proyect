using GameApp.Domain.Entities;
using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for scene where nothing happens you just move forward
public class NothingHappensScene : Scene
{

    // Constructor
    public NothingHappensScene(SceneName name, SceneDescription description, Biome biome)
    : base(name, description, biome)
    {
    }

    // Restore Constructor
    public NothingHappensScene(Guid id, SceneName name, SceneDescription description, Biome biome)
    : base(id, name, description, biome)
    {
    }

    // Setters 
    public NothingHappensScene SetSceneName(SceneName newName) =>
    new NothingHappensScene(newName, GetDescription(), GetBiome());

    public NothingHappensScene SetSceneDescription(SceneDescription newDescription) =>
    new NothingHappensScene(GetName(), newDescription, GetBiome());

    public NothingHappensScene SetBiome(Biome newBiome) =>
    new NothingHappensScene(GetName(), GetDescription(), newBiome);

    // To string
    public override string ToString()
    {
        return $"{GetName()} NothingHappens Scene({GetGuid()}): " +
               $"Description={GetDescription()}, Biome={GetBiome()}, ";
    }

}