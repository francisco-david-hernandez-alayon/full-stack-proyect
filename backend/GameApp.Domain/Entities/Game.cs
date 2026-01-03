using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Domain.Entities;

public class Game
{
    private readonly Guid Id;
    private readonly GameDifficulty Difficulty;
    private readonly Character Character;
    private readonly int NumberScenesToFinish;
    private readonly List<Scene> ListCompletedScenes;
    private readonly List<Scene> ListCurrentScenes;
    private readonly List<UserAction> ListCurrentUserActions;  // all possible actions that the user can perform in the current scenes
    private readonly FinalScene FinalScene;
    private readonly GameStatus Status;
    private readonly Enemy? CurrentEnemy;  // could be an enemy on current scene

    ///-------------CREATE ATRIBUTE: CurrentEnemy

    // // Required for EF Core
    // private Game()
    // {
    //     Id = Guid.NewGuid();
    //     Character = null!;
    //     ListCompletedScenes = new List<Scene>();
    //     ListCurrentScenes = new List<Scene>();
    //     ListCurrentUserActions = new List<UserAction>();
    //     FinalScene = null!;
    //     Status = GameStatus.GameInProgress;
    // }

    // Default constructor
    public Game(GameDifficulty difficulty, Character character, int numberScenesToFinish, FinalScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions)
    {
        Id = Guid.NewGuid();
        Difficulty = difficulty;
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        FinalScene = finalScene;
        ListCompletedScenes = new List<Scene>();
        ListCurrentScenes = listCurrentScenes;
        ListCurrentUserActions = listCurrentUserActions;
        Status = GameStatus.GameInProgress;
    }

    // Restore constructor
    public Game(Guid id, GameDifficulty difficulty, Character character, int numberScenesToFinish, List<Scene> completedScenes, FinalScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions, GameStatus status, Enemy? currentEnemy)
    {
        Id = id;
        Difficulty = difficulty;
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        ListCompletedScenes = new List<Scene>(completedScenes);
        FinalScene = finalScene;
        ListCurrentScenes = listCurrentScenes;
        ListCurrentUserActions = listCurrentUserActions;
        CurrentEnemy = currentEnemy;
        Status = status;
    }

    // Getters
    public Guid GetGuid() => Id;

    public GameDifficulty GetDifficulty() => Difficulty;
    public Character GetCharacter() => Character;
    public int GetNumberScenesToFinish() => NumberScenesToFinish;
    public List<Scene> GetCompletedScenes() => new List<Scene>(ListCompletedScenes);
    public FinalScene GetFinalScene() => FinalScene;
    public List<Scene> GetCurrentScenes() => new List<Scene>(ListCurrentScenes);
    public List<UserAction> GetCurrentUserAction() => new List<UserAction>(ListCurrentUserActions);
    public GameStatus GetGameStatus() => Status;
    public Enemy? GetCurrentEnemy() => CurrentEnemy;

    // Setters
    public Game SetCharacter(Character newCharacter) =>
        new Game(Id, Difficulty, newCharacter, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);

    public Game SetNumberScenesToFinish(int newNumberScenesToFinish) =>
        new Game(Id, Difficulty, Character, newNumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);

    public Game AddCompletedScene(Scene newScene)
    {
        var newList = new List<Scene>(ListCompletedScenes) { newScene };
        return new Game(Id, Difficulty, Character, NumberScenesToFinish, newList, FinalScene, ListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);
    }

    public Game RemoveLastCompletedScene()
    {
        if (ListCompletedScenes.Count == 0) return this;
        var newList = new List<Scene>(ListCompletedScenes);
        newList.RemoveAt(newList.Count - 1);
        return new Game(Id, Difficulty, Character, NumberScenesToFinish, newList, FinalScene, ListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);
    }

    public Game SetFinalScene(FinalScene newFinalScene) =>
        new Game(Id, Difficulty, Character, NumberScenesToFinish, ListCompletedScenes, newFinalScene, ListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);

    public Game SetCurrentScenes(List<Scene> newListCurrentScenes) =>
        new Game(Id, Difficulty, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, newListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);
        
    public Game SetCurrentUserActions(List<UserAction> newListCurrentUserActions) =>
        new Game(Id, Difficulty, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, newListCurrentUserActions, Status, CurrentEnemy);

    public Game SetCurrentEnemy(Enemy? newCurrentEnemy) =>
        new Game(Id, Difficulty, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions, Status, newCurrentEnemy);
    
    public Game SetGameStatus(GameStatus newStatus) =>
        new Game(Id, Difficulty, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions, newStatus, CurrentEnemy);

    public Game SetDifficulty(GameDifficulty newDifficulty) =>
        new Game(Id, newDifficulty, Character, NumberScenesToFinish, ListCompletedScenes, FinalScene, ListCurrentScenes, ListCurrentUserActions, Status, CurrentEnemy);


    public Game UpdateGame(GameDifficulty newDifficulty, Character newCharacter, int newNumberScenesToFinish, List<Scene> newCompletedScenes, FinalScene newFinalScene, List<Scene> newListCurrentScenes, List<UserAction> newlistCurrentUserActions, GameStatus newStatus, Enemy? newCurrentEnemy) =>
    new Game(Id, newDifficulty, newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene, newListCurrentScenes, newlistCurrentUserActions, newStatus, newCurrentEnemy);

    // To string
    public override string ToString()
    {
        string completedScenesStr = string.Join(", ", ListCompletedScenes.ConvertAll(s => s.GetName().ToString()));
        string currentScenesStr = string.Join(", ", ListCurrentScenes.ConvertAll(s => s.GetName().ToString()));
        string currentUserActionsStr = string.Join(", ", ListCurrentUserActions.ConvertAll(s => s.ToString()));
        return $"Game {Id}(Difficulty:{Difficulty}): Character={Character.GetName()}, NumberScenesToFinish={NumberScenesToFinish}, " +
               $"CompletedScenes=[{completedScenesStr}], FinalScene={FinalScene?.GetName()}, CurrentScenes=[{currentScenesStr}], " + 
               $"CurrentUserAction=[{currentUserActionsStr}], GameStatus={Status}, CurrentEnemy={CurrentEnemy}";
    }
}
