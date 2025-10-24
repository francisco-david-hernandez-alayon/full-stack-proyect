using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using System;
using System.Collections.Generic;

namespace GameApp.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public Character Character { get; private set; } = default!;
    public int NumberScenesToFinish { get; private set; }
    public List<Scene> ListCompletedScenes { get; private set; } = new();
    public NothingHappensScene FinalScene { get; private set; } = default!;

    // Required for EF Core
    private Game()
    {
        Id = Guid.NewGuid();
        Character = null!;
        ListCompletedScenes = new List<Scene>();
        FinalScene = null!;
    }

    // Default constructor
    public Game(Character character, int numberScenesToFinish, NothingHappensScene finalScene)
    {
        Id = Guid.NewGuid();
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        FinalScene = finalScene;
        ListCompletedScenes = new List<Scene>();
    }

    // Restore constructor
    public Game(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, NothingHappensScene finalScene)
    {
        Id = id;
        Character = character;
        NumberScenesToFinish = numberScenesToFinish;
        ListCompletedScenes = new List<Scene>(completedScenes);
        FinalScene = finalScene;
    }

    // Getters
    public Guid GetGuid() => Id;
    public Character GetCharacter() => Character;
    public int GetNumberScenesToFinish() => NumberScenesToFinish;
    public List<Scene> GetCompletedScenes() => new List<Scene>(ListCompletedScenes);
    public NothingHappensScene GetFinalScene() => FinalScene;

    // Setters
    public Game SetCharacter(Character newCharacter) =>
        new Game(Id, newCharacter, NumberScenesToFinish, ListCompletedScenes, FinalScene);

    public Game SetNumberScenesToFinish(int newNumberScenesToFinish) =>
        new Game(Id, Character, newNumberScenesToFinish, ListCompletedScenes, FinalScene);

    public Game AddCompletedScene(Scene newScene)
    {
        var newList = new List<Scene>(ListCompletedScenes) { newScene };
        return new Game(Id, Character, NumberScenesToFinish, newList, FinalScene);
    }

    public Game RemoveLastCompletedScene()
    {
        if (ListCompletedScenes.Count == 0) return this;
        var newList = new List<Scene>(ListCompletedScenes);
        newList.RemoveAt(newList.Count - 1);
        return new Game(Id, Character, NumberScenesToFinish, newList, FinalScene);
    }

    public Game SetFinalScene(NothingHappensScene newFinalScene) =>
        new Game(Id, Character, NumberScenesToFinish, ListCompletedScenes, newFinalScene);


    public Game UpdateGame(Character newCharacter, int newNumberScenesToFinish, List<Scene> newCompletedScenes, NothingHappensScene newFinalScene) =>
    new Game(Id, newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene);

    // To string
    public override string ToString()
    {
        string completedScenesStr = string.Join(", ", ListCompletedScenes.ConvertAll(s => s.GetName().ToString()));
        return $"Game {Id}: Character={Character.GetName()}, NumberScenesToFinish={NumberScenesToFinish}, " +
               $"CompletedScenes=[{completedScenesStr}], FinalScene={FinalScene?.GetName()}";
    }
}
