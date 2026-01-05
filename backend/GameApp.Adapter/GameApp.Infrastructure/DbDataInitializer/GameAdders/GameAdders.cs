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
        ThiefCharacter thief = new ThiefCharacter();
        thief = thief.AddItemInventory(AttackItemsAdders.IronSword) as ThiefCharacter;
        thief = thief.AddItemInventory(AtributteItemsAdders.Bread) as ThiefCharacter;
        thief = thief.AddItemInventory(AtributteItemsAdders.HealthPotion) as ThiefCharacter;

        if (thief != null)
        {
            FinalScene finalScene = ForestScenesAdder.FinalScene;
            List<Scene> currentScenes = new List<Scene> { ForestScenesAdder.InitialScene };
            List<UserAction> currentUserAction = new List<UserAction> { UserAction.UseItem, UserAction.MoveForward };

            Game game1 = new Game(GameDifficulty.Normal, thief, 10, finalScene, currentScenes, currentUserAction);
            gamesToAdd.Add(game1);
            games.AddRange(gamesToAdd);

        }   else
        {
            Console.WriteLine("thief is null when game is creating: " + thief);
        }

    }
}