using GameApp.Domain.Enumerates;

namespace GameApp.Domain.ValueObjects.Scenes;

// class for a scene where you enter a dungeon that can randomly generate a scene
public class EnterDungeonScene : Scene
{

    private static readonly Random _random = new Random();
    private readonly List<Scene> _possibleScenes;

    // Constructor
    public EnterDungeonScene(SceneName name, SceneDescription description, Biomes biome, List<Scene> possibleScenes)
    : base(name, description, biome)
    {
        _possibleScenes = possibleScenes;
    }

    // Getter
    public List<Scene> GetPossibleScenes() => new List<Scene>(_possibleScenes);

    // Setter
    public EnterDungeonScene SetPossibleScenes(List<Scene> newPossibleScenes) => new EnterDungeonScene(GetName(), GetDescription(), GetBiomes(), newPossibleScenes);

    // Generate Random Scene
    public Scene GenerateRandomScene()
    {
        int randomPosScene = _random.Next(_possibleScenes.Count);

        Scene scene = _possibleScenes[randomPosScene];

        return scene;
    }

    // To string
    public override string ToString()
    {
        string scenes = string.Join(", ", _possibleScenes.Select(s => s.GetName().ToString()));
        return $"EnterDungeonScene: {GetName()} - {_biome}\nDescription: {GetDescription()}\nPossible Scenes: [{scenes}]";
    }

}