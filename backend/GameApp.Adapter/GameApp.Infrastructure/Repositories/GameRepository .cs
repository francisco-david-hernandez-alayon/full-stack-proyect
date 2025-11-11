using GameApp.Domain.Repositories;
using GameApp.Domain.Entities;
using GameApp.Infrastructure.Models;
using GameApp.Infrastructure.Mappers;
using MongoDB.Driver;

namespace GameApp.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IMongoCollection<GameDocument> _games;

    public GameRepository(IMongoDatabase database)
    {
        _games = database.GetCollection<GameDocument>("games");
    }

    public async Task<IEnumerable<Game>> FetchAllAsync()
    {
        var docs = await _games.Find(_ => true).ToListAsync();
        return docs.Select(GameDocumentMapper.ToDomain);
    }

    public async Task<Game?> FetchByIdAsync(Guid id)
    {
        var doc = await _games.Find(g => g.Id == id).FirstOrDefaultAsync();
        return doc is null ? null : GameDocumentMapper.ToDomain(doc);
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
        return doc is null ? null : GameDocumentMapper.ToDomain(doc);
    }
}
