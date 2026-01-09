using MongoDB.Driver;
using GameApp.Domain.Repositories;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Adapter.Infrastructure.Mappers;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.Entities.Items;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ItemsAdders;
using GameApp.Application.Enumerates;
using GameApp.Domain.Enumerates;


namespace GameApp.Adapter.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly IMongoCollection<ItemDocument> _items;

    public ItemRepository(IMongoDatabase database)
    {
        _items = database.GetCollection<ItemDocument>("items");
    }

    public async Task<IEnumerable<Item>> FetchAllAsync()
    {
        var docs = await _items.Find(_ => true).ToListAsync();
        return docs.Select(ItemDocumentMapper.ToDomain);
    }

    public async Task<IEnumerable<Item>> FetchAllByFilterAsync(ItemType? type, ItemRarity? rarity)
    {
        var filter = Builders<ItemDocument>.Filter.Empty;

        if (type.HasValue)
            filter &= Builders<ItemDocument>.Filter.Eq(i => i.ItemType, type.Value);

        if (rarity.HasValue)
            filter &= Builders<ItemDocument>.Filter.Eq(i => i.Rarity, rarity.Value);

        var docs = await _items.Find(filter).ToListAsync();
        return docs.Select(ItemDocumentMapper.ToDomain);
    }


    public async Task<Item?> FetchByIdAsync(Guid id)
    {
        var doc = await _items.Find(g => g.Id == id).FirstOrDefaultAsync();
        return doc is null ? null : ItemDocumentMapper.ToDomain(doc);
    }

    public async Task<Item?> FetchByName(ItemName name)
    {
        var doc = await _items.Find(g => g.Name == name.GetName()).FirstOrDefaultAsync();
        return doc is null ? null : ItemDocumentMapper.ToDomain(doc);
    }

    public async Task<Item?> SaveAsync(Item Item)
    {
        var doc = ItemDocumentMapper.ToDocument(Item);
        await _items.InsertOneAsync(doc);
        return Item;
    }

    public async Task<Item?> UpdateAsync(Guid id, Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        var doc = ItemDocumentMapper.ToDocument(item);
        doc.Id = id;  // Keep original id
        var result = await _items.ReplaceOneAsync(g => g.Id == id, doc);
        return result.IsAcknowledged && result.ModifiedCount > 0 ? item : null;
    }


    public async Task<Item?> DeleteAsync(Guid id)
    {
        var doc = await _items.FindOneAndDeleteAsync(g => g.Id == id);
        return doc is null ? null : ItemDocumentMapper.ToDomain(doc);
    }

    // SEED INITIAL DATA
    public async Task SeedAsync()
    {
        // Add all Items
        List<Item> Items = new List<Item>();

        AttackItemsAdders.AddItems(Items);
        AtributteItemsAdders.AddItems(Items);


        // Insert Item only if not exist in db
        foreach (var item in Items)
        {
            var existing = await FetchByName(item.GetName());
            if (existing is not null)
                continue;

            await SaveAsync(item);
        }
    }


}
