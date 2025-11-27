using GameApp.Application.UseCases.ItemUseCases;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.ItemServices;


public class ItemCreateService : ItemCreateUseCase
{
    private readonly IItemRepository _repo;

    public ItemCreateService(IItemRepository repo) => _repo = repo;

    public async Task<Item?> CreateItem(Item item)
    {
        // item name must be unique in the collection
        var existingItem = await _repo.FetchByName(item.GetName());
        if (existingItem is not null)
        {
            Console.WriteLine($"Item name {item.GetName()} exist");
            return null;
        }
        return await _repo.SaveAsync(item);
    }
}