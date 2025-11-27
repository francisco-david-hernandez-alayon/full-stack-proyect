using GameApp.Domain.Repositories;
using GameApp.Domain.Entities;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Adapter.Infrastructure.Mappers;
using MongoDB.Driver;

namespace GameApp.Adapter.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IMongoCollection<GameDocument> _games;
    private readonly IItemRepository _itemRepository;

    public GameRepository(IMongoDatabase database, IItemRepository itemRepository)
    {
        _games = database.GetCollection<GameDocument>("games");
        _itemRepository = itemRepository;
    }


    public async Task<IEnumerable<Game>> FetchAllAsync()
    {
        var docs = await _games.Find(_ => true).ToListAsync();

        var tasks = docs.Select(doc => GameDocumentMapper.ToDomainAsync(doc, _itemRepository));
        return await Task.WhenAll(tasks);
    }

    public async Task<Game?> FetchByIdAsync(Guid id)
    {
        var doc = await _games.Find(g => g.Id == id).FirstOrDefaultAsync();
        if (doc is null) return null;
        return await GameDocumentMapper.ToDomainAsync(doc, _itemRepository);
    }

    public async Task<Game?> SaveAsync(Game game)
    {
        var doc = GameDocumentMapper.ToDocument(game);
        await _games.InsertOneAsync(doc);
        return game;
    }

    public async Task<Game?> UpdateAsync(Guid id, Game game)
    {
        var doc = GameDocumentMapper.ToDocument(game);
        var result = await _games.ReplaceOneAsync(g => g.Id == id, doc);
        return result.IsAcknowledged && result.ModifiedCount > 0 ? game : null;
    }

    public async Task<Game?> DeleteAsync(Guid id)
    {
        var doc = await _games.FindOneAndDeleteAsync(g => g.Id == id);
        if (doc is null) return null;
        return await GameDocumentMapper.ToDomainAsync(doc, _itemRepository);
    }
}
