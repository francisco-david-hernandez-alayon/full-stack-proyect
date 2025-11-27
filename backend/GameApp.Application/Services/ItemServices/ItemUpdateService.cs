using GameApp.Application.UseCases.ItemUseCases;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.ItemServices;

public class ItemUpdateService : ItemUpdateUseCase
{
    private readonly IItemRepository _repo;

    public ItemUpdateService(IItemRepository repo) => _repo = repo;


    public async Task<Item?> UpdateItem(Guid id, Item item)
    {
        var existingItem = await _repo.FetchByIdAsync(id);
        if (existingItem is null)
        {
            Console.WriteLine($"Item to update with id {id} not found.");
            return null;
        }

        // If the item name is going to change
        if (!existingItem.GetName().Equals(item.GetName()))
        {
            var itemWithSameName = await _repo.FetchByName(item.GetName());
            if (itemWithSameName is not null)  // item name must be unique in the collection
            {
                Console.WriteLine($"Item with name '{item.GetName()}' already exists. Cannot update item");
                return null;
            }
        }

        return await _repo.UpdateAsync(id, item);
    }
}