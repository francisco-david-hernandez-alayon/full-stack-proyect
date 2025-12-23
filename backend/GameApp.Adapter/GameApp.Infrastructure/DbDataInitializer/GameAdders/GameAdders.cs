using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.GameAdders;

public interface GameAdders : IGameAdders
{
    public static void AddGames(List<Game> games)
    {
        List<Game> gamesToAdd = new List<Game>();
        WarriorCharacter warrior = new WarriorCharacter();
        warrior = warrior.AddItemInventory(AttackItemsAdders.Dagger) as WarriorCharacter;
        warrior = warrior.AddItemInventory(AttackItemsAdders.IronSword)  as WarriorCharacter;
        warrior = warrior.AddItemInventory(AtributteItemsAdders.Bread)  as WarriorCharacter;
        warrior = warrior.AddItemInventory(AtributteItemsAdders.HealthPotion)  as WarriorCharacter;

        NothingHappensScene finalScene = ForestScenesAdder.FinalSceneTreasureForest;
        List<Scene> currentScenes = new List<Scene>{finalScene};
        List<UserAction> currentUserAction = new List<UserAction>{UserAction.UseItem, UserAction.MoveForward};

        Game game1 = new Game(warrior, 10, finalScene, currentScenes, currentUserAction);


        gamesToAdd.Add(game1);


        games.AddRange(gamesToAdd);
    }
}