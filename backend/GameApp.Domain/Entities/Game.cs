using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Domain.Entities;

public class Game
{
    private readonly Guid Id;
    private readonly Character Character;
    private readonly int NumberScenesToFinish;
    private readonly List<Scene> ListCompletedScenes;
    private readonly List<Scene> ListCurrentScenes;
    private readonly NothingHappensScene FinalScene;


    // Required for EF Core
    private Game()
    {
        Id = Guid.NewGuid();
        Character = null!;
        ListCompletedScenes = new List<Scene>();
        ListCurrentScenes = new List<Scene>();
        FinalScene = null!;
    }

    // Default constructor
    public Game(Character character, int numberScenesToFinish, NothingHappensScene finalScene, List<Scene> listCurrentScenes)
    {
        Id = Guid.NewGuid();
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        FinalScene = finalScene;
        ListCompletedScenes = new List<Scene>();
        ListCurrentScenes = listCurrentScenes;
    }

    // Restore constructor
    public Game(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene, List<Scene> listCurrentScenes)
    {
        Id = id;
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        ListCompletedScenes = new List<Scene>(completedScenes);
        FinalScene = finalScene;
        ListCurrentScenes = listCurrentScenes;
    }

    // Getters
    public Guid GetGuid() => Id;
    public Character GetCharacter() => Character;
    public int GetNumberScenesToFinish() => NumberScenesToFinish;
    public List<Scene> GetCompletedScenes() => new List<Scene>(ListCompletedScenes);
    public NothingHappensScene GetFinalScene() => FinalScene;

    public List<Scene> GetCurrentScenes() => new List<Scene>(ListCurrentScenes);

    // Setters
    public Game SetCharacter(Character newCharacter) =>
        new Game(Id, newCharacter, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes);

    public Game SetNumberScenesToFinish(int newNumberScenesToFinish) =>
        new Game(Id, Character, newNumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes);

    public Game AddCompletedScene(Scene newScene)
    {
        var newList = new List<Scene>(ListCompletedScenes) { newScene };
        return new Game(Id, Character, NumberScenesToFinish, newList, FinalScene, ListCurrentScenes);
    }

    public Game RemoveLastCompletedScene()
    {
        if (ListCompletedScenes.Count == 0) return this;
        var newList = new List<Scene>(ListCompletedScenes);
        newList.RemoveAt(newList.Count - 1);
        return new Game(Id, Character, NumberScenesToFinish, newList, FinalScene, ListCurrentScenes);
    }

    public Game SetFinalScene(NothingHappensScene newFinalScene) =>
        new Game(Id, Character, NumberScenesToFinish, ListCompletedScenes, newFinalScene, ListCurrentScenes);
    
    public Game SetCurrentScenes(List<Scene> newListCurrentScenes) =>
        new Game(Id, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, newListCurrentScenes);


    public Game UpdateGame(Character newCharacter, int newNumberScenesToFinish, List<Scene> newCompletedScenes, NothingHappensScene newFinalScene, List<Scene> newListCurrentScenes) =>
    new Game(Id, newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene, newListCurrentScenes);

    // To string
    public override string ToString()
    {
        string completedScenesStr = string.Join(", ", ListCompletedScenes.ConvertAll(s => s.GetName().ToString()));
        string currentScenesStr = string.Join(", ", ListCurrentScenes.ConvertAll(s => s.GetName().ToString()));
        return $"Game {Id}: Character={Character.GetName()}, NumberScenesToFinish={NumberScenesToFinish}, " +
               $"CompletedScenes=[{completedScenesStr}], FinalScene={FinalScene?.GetName()}, CurrentScenes=[{currentScenesStr}]";
    }
}
