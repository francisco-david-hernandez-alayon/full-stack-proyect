using GameApp.Application.UseCases.ItemUseCases;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Application.Services.ItemServices;


public class ItemGetService : ItemGetUseCase
{
    private readonly IItemRepository _repo;

    public ItemGetService(IItemRepository repo) => _repo = repo;

    public async Task<Item?> GetItem(Guid id)
    {
        return await _repo.FetchByIdAsync(id);
    }

    public async Task<Item?> GetItemByName(ItemName name)
    {
        return await _repo.FetchByName(name);
    }

    public async Task<IEnumerable<Item>> GetAllItems()
    {
        return await _repo.FetchAllAsync();
    }
}