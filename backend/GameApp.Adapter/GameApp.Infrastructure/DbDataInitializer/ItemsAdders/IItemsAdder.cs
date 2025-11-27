using GameApp.Domain.Entities.Items;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;

// Interface for items adder to feed initial db
public interface IItemsAdder
{
    static abstract void AddItems(List<Item> items);
}