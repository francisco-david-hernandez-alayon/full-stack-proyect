using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Application.UseCases.ItemUseCases;

public interface ItemGetUseCase
{
    public Task<Item?> GetItem(Guid id);

    public Task<Item?> GetItemByName(ItemName name);

    public Task<IEnumerable<Item>> GetAllItems();
}