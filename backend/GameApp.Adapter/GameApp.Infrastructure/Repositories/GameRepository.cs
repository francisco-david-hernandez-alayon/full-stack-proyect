using GameApp.Domain.Repositories;
using GameApp.Domain.Entities;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Adapter.Infrastructure.Mappers;
using MongoDB.Driver;
using GameApp.Adapter.Infrastructure.DbDataInitializer.GameAdders;

namespace GameApp.Adapter.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IMongoCollection<GameDocument> _games;
    private readonly IItemRepository _itemRepository;
    private readonly IEnemyRepository _enemyRepository;
    private readonly ISceneRepository _sceneRepository;

    public GameRepository(IMongoDatabase database, ISceneRepository sceneRepository, IItemRepository itemRepository, IEnemyRepository enemyRepository)
    {
        _games = database.GetCollection<GameDocument>("games");
        _itemRepository = itemRepository;
        _enemyRepository = enemyRepository;
        _sceneRepository = sceneRepository;
    }


    public async Task<IEnumerable<Game>> FetchAllAsync()
    {
        var docs = await _games.Find(_ => true).ToListAsync();

        var tasks = docs.Select(doc => GameDocumentMapper.ToDomainAsync(doc, _sceneRepository, _itemRepository, _enemyRepository));
        return await Task.WhenAll(tasks);
    }

    public async Task<Game?> FetchByIdAsync(Guid id)
    {
        var doc = await _games.Find(g => g.Id == id).FirstOrDefaultAsync();
        if (doc is null) return null;
        return await GameDocumentMapper.ToDomainAsync(doc, _sceneRepository, _itemRepository, _enemyRepository);
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
        return await GameDocumentMapper.ToDomainAsync(doc, _sceneRepository, _itemRepository, _enemyRepository);
    }

    // SEED INITIAL DATA
    public async Task SeedAsync()
    {
        // Add all Items
        List<Game> Games = new List<Game>();

        GameAdders.AddGames(Games);
    
        // Insert games in db
        foreach (var game in Games)
        {
            await SaveAsync(game);
        }
    }
}
