using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class GamePersistenceMapper
{
    public static GamePersistenceModel ToPersistenceModel(Game game)
    {
        return new GamePersistenceModel
        {
            Id = game.GetGuid(),
            Character = CharacterPersistenceMapper.ToPersistenceModel(game.GetCharacter()),
            NumberScenesToFinish = game.GetNumberScenesToFinish(),
            CompletedScenes = game.GetCompletedScenes()
                                  .Select(ScenePersistenceMapper.ToPersistenceModel)
                                  .ToList(),
            FinalScene = FinalScenePersistenceMapper.ToPersistenceModel(game.GetFinalScene())
        };
    }

    public static Game ToDomain(GamePersistenceModel model)
    {
        if (model.Character == null)
            throw new InvalidOperationException($"Game {model.Id} has no character assigned");


        Character character = CharacterPersistenceMapper.ToDomain(model.Character);

        List<Scene> completedScenes = model.CompletedScenes
            .Select(ScenePersistenceMapper.ToDomain)
            .ToList();

        NothingHappensScene finalScene = FinalScenePersistenceMapper.ToDomain(model.FinalScene);

        return new Game(model.Id, character, model.NumberScenesToFinish, completedScenes, finalScene);
    }
}
