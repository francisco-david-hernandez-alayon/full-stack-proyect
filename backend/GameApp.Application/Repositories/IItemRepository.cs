using GameApp.Application.Enumerates;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Repositories;

public interface IItemRepository
{
    public abstract Task<IEnumerable<Item>> FetchAllAsync();

    public abstract Task<IEnumerable<Item>> FetchAllByFilterAsync(ItemType? type, ItemRarity? rarity);

    public abstract Task<Item?> FetchByIdAsync(Guid id);

    public abstract Task<Item?> FetchByName(ItemName name);

    public abstract Task<Item?> DeleteAsync(Guid id);
    
    public abstract Task<Item?> SaveAsync(Item Item);

    public abstract Task<Item?> UpdateAsync(Guid id, Item Item);

    public abstract Task SeedAsync();
}
