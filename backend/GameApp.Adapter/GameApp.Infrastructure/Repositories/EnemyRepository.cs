using MongoDB.Driver;
using GameApp.Domain.Repositories;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Adapter.Infrastructure.Mappers;

using GameApp.Adapter.Infrastructure.DbDataInitializer.EnemysAdders;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Enemies;


namespace GameApp.Adapter.Infrastructure.Repositories;

public class EnemyRepository : IEnemyRepository
{
    private readonly IMongoCollection<EnemyDocument> _enemys;

    public EnemyRepository(IMongoDatabase database)
    {
        _enemys = database.GetCollection<EnemyDocument>("enemys");
    }

    public async Task<IEnumerable<Enemy>> FetchAllAsync()
    {
        var docs = await _enemys.Find(_ => true).ToListAsync();
        return docs.Select(EnemyDocumentMapper.ToDomain);
    }

    public async Task<Enemy?> FetchByIdAsync(Guid id)
    {
        var doc = await _enemys.Find(g => g.Id == id).FirstOrDefaultAsync();
        return doc is null ? null : EnemyDocumentMapper.ToDomain(doc);
    }

    public async Task<Enemy?> FetchByName(EnemyName name)
    {
        var doc = await _enemys.Find(g => g.Name == name.GetName()).FirstOrDefaultAsync();
        return doc is null ? null : EnemyDocumentMapper.ToDomain(doc);
    }

    public async Task<Enemy?> SaveAsync(Enemy Enemy)
    {
        var doc = EnemyDocumentMapper.ToDocument(Enemy);
        await _enemys.InsertOneAsync(doc);
        return Enemy;
    }

    public async Task<Enemy?> UpdateAsync(Guid id, Enemy enemy)
    {
        var doc = EnemyDocumentMapper.ToDocument(enemy);
        doc.Id = id;  // Keep original id
        var result = await _enemys.ReplaceOneAsync(g => g.Id == id, doc);
        return result.IsAcknowledged && result.ModifiedCount > 0 ? enemy : null;
    }

    public async Task<Enemy?> DeleteAsync(Guid id)
    {
        var doc = await _enemys.FindOneAndDeleteAsync(g => g.Id == id);
        return doc is null ? null : EnemyDocumentMapper.ToDomain(doc);
    }

    // SEED INITIAL DATA
    public async Task SeedAsync()
    {
        // Add all Enemys
        List<Enemy> Enemys = new List<Enemy>();

        EnemysAdder.AddEnemys(Enemys);

        // Insert Enemy only if not exist in db
        foreach (var Enemy in Enemys)
        {
            var existing = await FetchByName(Enemy.GetName());
            if (existing is not null)
                continue;

            await SaveAsync(Enemy);
        }
    }


}
