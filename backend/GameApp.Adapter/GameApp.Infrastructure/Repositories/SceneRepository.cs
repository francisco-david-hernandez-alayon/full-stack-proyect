using MongoDB.Driver;
using GameApp.Domain.Repositories;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Adapter.Infrastructure.Mappers;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Entities.Items;

namespace GameApp.Adapter.Infrastructure.Repositories;

public class SceneRepository : ISceneRepository
{
    private readonly IMongoCollection<SceneDocument> _scenes;
    private readonly IItemRepository _itemRepository;

    private readonly IEnemyRepository _enemyRepository;

    public SceneRepository(IMongoDatabase database, IItemRepository itemRepository, IEnemyRepository enemyRepository)
    {
        _scenes = database.GetCollection<SceneDocument>("scenes");
        _itemRepository = itemRepository;
        _enemyRepository = enemyRepository;
    }

    public async Task<IEnumerable<Scene>> FetchAllAsync()
    {
        var docs = await _scenes.Find(_ => true).ToListAsync();

        var scenes = await Task.WhenAll(docs.Select(doc => SceneDocumentMapper.ToDomainAsync(doc, _itemRepository, _enemyRepository)));

        return scenes;
    }


    public async Task<Scene?> FetchByIdAsync(Guid id)
    {
        var doc = await _scenes.Find(g => g.Id == id).FirstOrDefaultAsync();
        return doc is null ? null : await SceneDocumentMapper.ToDomainAsync(doc, _itemRepository, _enemyRepository);
    }

    public async Task<Scene?> FetchByName(SceneName name)
    {
        var doc = await _scenes.Find(g => g.Name == name.GetName()).FirstOrDefaultAsync();
        return doc is null ? null : await SceneDocumentMapper.ToDomainAsync(doc, _itemRepository, _enemyRepository);
    }

    public async Task<Scene?> SaveAsync(Scene Scene)
    {
        var doc = SceneDocumentMapper.ToDocument(Scene);
        await _scenes.InsertOneAsync(doc);
        return Scene;
    }

    public async Task<Scene?> UpdateAsync(Guid id, Scene scene)
    {
        var doc = SceneDocumentMapper.ToDocument(scene);
        doc.Id = id;  // Keep original id
        var result = await _scenes.ReplaceOneAsync(g => g.Id == id, doc);
        return result.IsAcknowledged && result.ModifiedCount > 0 ? scene : null;
    }


    public async Task<Scene?> DeleteAsync(Guid id)
    {
        var doc = await _scenes.FindOneAndDeleteAsync(g => g.Id == id);
        return doc is null ? null : await SceneDocumentMapper.ToDomainAsync(doc, _itemRepository, _enemyRepository);
    }

    // SEED INITIAL DATA
    public async Task SeedAsync()
    {
        // Add all scenes
        List<Scene> scenes = new List<Scene>();

        ChangeBiomesScenesAdder.AddScenes(scenes);
        ForestScenesAdder.AddScenes(scenes);
        DesertScenesAdder.AddScenes(scenes);
        SwampScenesAdder.AddScenes(scenes);
        CityScenesAdder.AddScenes(scenes);


        // Insert scene only if not exist in db
        foreach (var scene in scenes)
        {
            var existing = await FetchByName(scene.GetName());
            if (existing is not null)
                continue;

            await SaveAsync(scene);
        }
    }


}
