using GameApp.Application.UseCases.GameUseCases;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Application.Services.GameServices;

public class GameCreateService : GameCreateUseCase
{
    private readonly IGameRepository _gameRepo;
    private readonly IItemRepository _itemRepo;

    public GameCreateService(IGameRepository gameRepository, IItemRepository itemRepository)
    {
        _gameRepo = gameRepository;  
        _itemRepo = itemRepository;
    } 

    public async Task<Game?> CreateGame(GameDifficulty difficulty, Character character, int numberScenesToFinish, FinalScene finalScene, List<Scene> listCurrentScenes, List<UserAction> listCurrentUserActions)
    {
        var commonItems = await _itemRepo.FetchAllByFilterAsync(null, ItemRarity.Common);

        if ( !(commonItems == null || commonItems.Count() == 0)) {
            var random = new Random();
            List<Item> listCommonItems = (await _itemRepo.FetchAllByFilterAsync(null, ItemRarity.Common)).ToList();
            Item randomItem = listCommonItems[random.Next(commonItems.Count())];
            character = character.AddItemInventory(randomItem);
        }
        
        var game = new Game(difficulty, character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions);
        return await _gameRepo.SaveAsync(game);
    }
}