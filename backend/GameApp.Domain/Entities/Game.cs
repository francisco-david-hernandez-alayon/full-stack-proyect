using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using System;
using System.Collections.Generic;

namespace GameApp.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    private readonly Character _character;
    private readonly int _numberScenesToFinish;
    private readonly List<Scene> _listCompletedScenes;
    private readonly Scene _finalScene;

    // Required for EF Core
    private Game()
    {
        Id = Guid.NewGuid();
        _character = null!;
        _listCompletedScenes = new List<Scene>();
        _finalScene = null!;
    }

    // Default constructor
    public Game(Character character, int numberScenesToFinish, Scene finalScene)
    {
        Id = Guid.NewGuid();
        _character = character;
        _numberScenesToFinish = numberScenesToFinish;
        _finalScene = finalScene;
        _listCompletedScenes = new List<Scene>();
    }

    // Restore constructor
    public Game(Guid id, Character character, int numberScenesToFinish, List<Scene> completedScenes, Scene finalScene)
    {
        Id = id;
        _character = character;
        _numberScenesToFinish = numberScenesToFinish;
        _listCompletedScenes = new List<Scene>(completedScenes);
        _finalScene = finalScene;
    }

    // Getters
    public Guid GetGuid() => Id;
    public Character GetCharacter() => _character;
    public int GetNumberScenesToFinish() => _numberScenesToFinish;
    public List<Scene> GetCompletedScenes() => new List<Scene>(_listCompletedScenes);
    public Scene GetFinalScene() => _finalScene;

    // Setters
    public Game SetCharacter(Character newCharacter) =>
        new Game(Id, newCharacter, _numberScenesToFinish, _listCompletedScenes, _finalScene);

    public Game SetNumberScenesToFinish(int newNumberScenesToFinish) =>
        new Game(Id, _character, newNumberScenesToFinish, _listCompletedScenes, _finalScene);

    public Game AddCompletedScene(Scene newScene)
    {
        var newList = new List<Scene>(_listCompletedScenes) { newScene };
        return new Game(Id, _character, _numberScenesToFinish, newList, _finalScene);
    }

    public Game RemoveLastCompletedScene()
    {
        if (_listCompletedScenes.Count == 0) return this;
        var newList = new List<Scene>(_listCompletedScenes);
        newList.RemoveAt(newList.Count - 1);
        return new Game(Id, _character, _numberScenesToFinish, newList, _finalScene);
    }

    public Game SetFinalScene(Scene newFinalScene) =>
        new Game(Id, _character, _numberScenesToFinish, _listCompletedScenes, newFinalScene);


    public Game UpdateGame(Character newCharacter, int newNumberScenesToFinish, List<Scene> newCompletedScenes, Scene newFinalScene) =>
    new Game(Id, newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene);

    // To string
    public override string ToString()
    {
        string completedScenesStr = string.Join(", ", _listCompletedScenes.ConvertAll(s => s.GetName().ToString()));
        return $"Game {Id}: Character={_character.GetName()}, NumberScenesToFinish={_numberScenesToFinish}, " +
               $"CompletedScenes=[{completedScenesStr}], FinalScene={_finalScene?.GetName()}";
    }
}
