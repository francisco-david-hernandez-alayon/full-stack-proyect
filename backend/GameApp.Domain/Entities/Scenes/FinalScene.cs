using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Domain.Entities.Scenes;

// Class for final scene of a game
public class FinalScene : Scene
{

    // Constructor
    public FinalScene(SceneName name, SceneDescription description, Biome biome)
    : base(name, description, biome)
    {
    }

    // Restore Constructor
    public FinalScene(Guid id, SceneName name, SceneDescription description, Biome biome)
    : base(id, name, description, biome)
    {
    }

    // Setters 
    public FinalScene SetSceneName(SceneName newName) =>
    new FinalScene(GetGuid(), newName, GetDescription(), GetBiome());

    public FinalScene SetSceneDescription(SceneDescription newDescription) =>
    new FinalScene(GetGuid(), GetName(), newDescription, GetBiome());

    public FinalScene SetBiome(Biome newBiome) =>
    new FinalScene(GetGuid(), GetName(), GetDescription(), newBiome);

    // To string
    public override string ToString()
    {
        return $"{GetName()} Final Scene({GetGuid()}): " +
               $"Description={GetDescription()}, Biome={GetBiome()}, ";
    }

}