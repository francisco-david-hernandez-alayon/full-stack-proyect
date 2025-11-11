using GameApp.Domain.Enumerates;
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
    private readonly List<UserAction> ListCurrentUserActions;  // all possible actions that the user can perform in the current scenes
    private readonly NothingHappensScene FinalScene;

    ///-------------CREATE ATRIBUTE: CurrentEnemy

    // Required for EF Core
    private Game()
    {
        Id = Guid.NewGuid();
        Character = null!;
        ListCompletedScenes = new List<Scene>();
        ListCurrentScenes = new List<Scene>();
        ListCurrentUserActions = new List<UserAction>();
        FinalScene = null!;
    }

    // Default constructor
    public Game(Character character, int numberScenesToFinish, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions)
    {
        Id = Guid.NewGuid();
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        FinalScene = finalScene;
        ListCompletedScenes = new List<Scene>();
        ListCurrentScenes = listCurrentScenes;
        ListCurrentUserActions = listCurrentUserActions;
    }

    // Restore constructor
    public Game(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions)
    {
        Id = id;
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        ListCompletedScenes = new List<Scene>(completedScenes);
        FinalScene = finalScene;
        ListCurrentScenes = listCurrentScenes;
        ListCurrentUserActions = listCurrentUserActions;
    }

    // Getters
    public Guid GetGuid() => Id;
    public Character GetCharacter() => Character;
    public int GetNumberScenesToFinish() => NumberScenesToFinish;
    public List<Scene> GetCompletedScenes() => new List<Scene>(ListCompletedScenes);
    public NothingHappensScene GetFinalScene() => FinalScene;
    public List<Scene> GetCurrentScenes() => new List<Scene>(ListCurrentScenes);
    public List<UserAction> GetCurrentUserAction() => new List<UserAction>(ListCurrentUserActions);

    // Setters
    public Game SetCharacter(Character newCharacter) =>
        new Game(Id, newCharacter, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions);

    public Game SetNumberScenesToFinish(int newNumberScenesToFinish) =>
        new Game(Id, Character, newNumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions);

    public Game AddCompletedScene(Scene newScene)
    {
        var newList = new List<Scene>(ListCompletedScenes) { newScene };
        return new Game(Id, Character, NumberScenesToFinish, newList, FinalScene, ListCurrentScenes, ListCurrentUserActions);
    }

    public Game RemoveLastCompletedScene()
    {
        if (ListCompletedScenes.Count == 0) return this;
        var newList = new List<Scene>(ListCompletedScenes);
        newList.RemoveAt(newList.Count - 1);
        return new Game(Id, Character, NumberScenesToFinish, newList, FinalScene, ListCurrentScenes, ListCurrentUserActions);
    }

    public Game SetFinalScene(NothingHappensScene newFinalScene) =>
        new Game(Id, Character, NumberScenesToFinish, ListCompletedScenes, newFinalScene, ListCurrentScenes, ListCurrentUserActions);

    public Game SetCurrentScenes(List<Scene> newListCurrentScenes) =>
        new Game(Id, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, newListCurrentScenes, ListCurrentUserActions);
        
    public Game SetCurrentUserActions(List<UserAction> newListCurrentUserActions) =>
        new Game(Id, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, newListCurrentUserActions);



    public Game UpdateGame(Character newCharacter, int newNumberScenesToFinish, List<Scene> newCompletedScenes, NothingHappensScene newFinalScene, List<Scene> newListCurrentScenes, List<UserAction> newlistCurrentUserActions) =>
    new Game(Id, newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene, newListCurrentScenes, newlistCurrentUserActions);

    // To string
    public override string ToString()
    {
        string completedScenesStr = string.Join(", ", ListCompletedScenes.ConvertAll(s => s.GetName().ToString()));
        string currentScenesStr = string.Join(", ", ListCurrentScenes.ConvertAll(s => s.GetName().ToString()));
        string currentUserActionsStr = string.Join(", ", ListCurrentUserActions.ConvertAll(s => s.ToString()));
        return $"Game {Id}: Character={Character.GetName()}, NumberScenesToFinish={NumberScenesToFinish}, " +
               $"CompletedScenes=[{completedScenesStr}], FinalScene={FinalScene?.GetName()}, CurrentScenes=[{currentScenesStr}, CurrentUserAction=[{currentUserActionsStr}]]";
    }
}
