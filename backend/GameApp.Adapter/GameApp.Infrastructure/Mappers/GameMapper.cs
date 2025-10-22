using System.Text.Json;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class GameMapper
{
    public static GameDataModel ToDataModel(Game game)
    {
        return new GameDataModel
        {
            Id = game.GetGuid(),
            CharacterJson = JsonSerializer.Serialize(game.GetCharacter()),
            NumberScenesToFinish = game.GetNumberScenesToFinish(),
            CompletedScenesJson = JsonSerializer.Serialize(game.GetCompletedScenes()),
            FinalSceneJson = JsonSerializer.Serialize(game.GetFinalScene())
        };
    }

    public static Game ToDomain(GameDataModel model)
    {
        var character = JsonSerializer.Deserialize<Character>(model.CharacterJson)!;
        var completedScenes = JsonSerializer.Deserialize<List<Scene>>(model.CompletedScenesJson)!;
        var finalScene = JsonSerializer.Deserialize<Scene>(model.FinalSceneJson)!;

        return new Game(model.Id, character, model.NumberScenesToFinish, completedScenes, finalScene);
    }
}
