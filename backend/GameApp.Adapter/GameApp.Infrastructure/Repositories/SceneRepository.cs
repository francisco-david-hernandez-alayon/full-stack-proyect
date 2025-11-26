using MongoDB.Driver;
using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Infrastructure.Models;
using GameApp.Infrastructure.Mappers;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Host.scenes;

namespace GameAppApp.Infrastructure.Repositories;

public class SceneRepository : ISceneRepository
{
    private readonly IMongoCollection<SceneDocument> _Scenes;

    public SceneRepository(IMongoDatabase database)
    {
        _Scenes = database.GetCollection<SceneDocument>("Scenes");
    }

    public async Task<IEnumerable<Scene>> FetchAllAsync()
    {
        var docs = await _Scenes.Find(_ => true).ToListAsync();
        return docs.Select(SceneDocumentMapper.ToDomain);
    }

    public async Task<Scene?> FetchByIdAsync(Guid id)
    {
        var doc = await _Scenes.Find(g => g.Id == id).FirstOrDefaultAsync();
        return doc is null ? null : SceneDocumentMapper.ToDomain(doc);
    }

    public async Task<Scene?> FetchByName(SceneName name)
    {
        var doc = await _Scenes.Find(g => g.Name == name.GetName()).FirstOrDefaultAsync();
        return doc is null ? null : SceneDocumentMapper.ToDomain(doc);
    }

    public async Task<Scene?> SaveAsync(Scene Scene)
    {
        var doc = SceneDocumentMapper.ToDocument(Scene);
        await _Scenes.InsertOneAsync(doc);
        return Scene;
    }

    public async Task<Scene?> UpdateAsync(Guid id, Scene Scene)
    {
        var doc = SceneDocumentMapper.ToDocument(Scene);
        var result = await _Scenes.ReplaceOneAsync(g => g.Id == id, doc);
        return result.IsAcknowledged && result.ModifiedCount > 0 ? Scene : null;
    }

    public async Task<Scene?> DeleteAsync(Guid id)
    {
        var doc = await _Scenes.FindOneAndDeleteAsync(g => g.Id == id);
        return doc is null ? null : SceneDocumentMapper.ToDomain(doc);
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
