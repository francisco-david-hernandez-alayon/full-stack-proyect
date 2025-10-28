using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// class for a scene where you enter a dungeon that can randomly generate a scene
public class EnterDungeonScene : Scene
{

    private static readonly Random _random = new Random();
    private readonly List<Scene> PossibleScenes;

    // Constructor
    public EnterDungeonScene(SceneName name, SceneDescription description, Biome biome, List<Scene> possibleScenes)
    : base(name, description, biome)
    {
        PossibleScenes = possibleScenes;
    }

    // Getter
    public List<Scene> GetPossibleScenes() => new List<Scene>(PossibleScenes);

    // Setter
    public EnterDungeonScene SetPossibleScenes(List<Scene> newPossibleScenes) => new EnterDungeonScene(GetName(), GetDescription(), GetBiome(), newPossibleScenes);

    // Generate Random Scene
    public Scene GenerateRandomScene()
    {
        int randomPosScene = _random.Next(PossibleScenes.Count);

        Scene scene = PossibleScenes[randomPosScene];

        return scene;
    }

    // To string
    public override string ToString()
    {
        string scenes = string.Join(", ", PossibleScenes.Select(s => s.GetName().ToString()));
        return $"EnterDungeonScene: {GetName()} - {GetBiome()}\nDescription: {GetDescription()}\nPossible Scenes: [{scenes}]";
    }

}