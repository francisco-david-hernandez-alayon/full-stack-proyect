using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Infrastructure.Data;
using GameApp.Infrastructure.Data.Models;
using GameApp.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Game>> FetchAllAsync()
    {
        var models = await _context.Games
            .Include(g => g.Character)
            .Include(g => g.FinalScene)
            .Include(g => g.CompletedScenes)
            .ToListAsync();

        return models
            .Where(m => m.Character != null && m.FinalScene != null) 
            .Select(GamePersistenceMapper.ToDomain);
    }

    public async Task<Game?> FetchByIdAsync(Guid id)
    {
        var model = await _context.Games
            .Include(g => g.Character)
            .Include(g => g.FinalScene)
            .Include(g => g.CompletedScenes)
            .FirstOrDefaultAsync(g => g.Id == id);

        return model is null || model.Character is null || model.FinalScene is null
            ? null
            : GamePersistenceMapper.ToDomain(model);
    }

    public async Task<Game?> SaveAsync(Game game)
    {
        var model = GamePersistenceMapper.ToPersistenceModel(game);

        
        if (model.Character == null)
            throw new InvalidOperationException("Character cannot be null when saving a game");

        if (model.FinalScene == null)
            throw new InvalidOperationException("FinalScene cannot be null when saving a game");

        _context.Games.Add(model);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> UpdateAsync(Game game)
    {
        var model = GamePersistenceMapper.ToPersistenceModel(game);

        if (model.Character == null || model.FinalScene == null)
            throw new InvalidOperationException("Cannot update a game with null Character or FinalScene");

        _context.Games.Update(model);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> DeleteAsync(Guid id)
    {
        var model = await _context.Games
            .Include(g => g.Character)
            .Include(g => g.FinalScene)
            .Include(g => g.CompletedScenes)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (model == null) return null;

        _context.Games.Remove(model);
        await _context.SaveChangesAsync();

        return model.Character != null && model.FinalScene != null
            ? GamePersistenceMapper.ToDomain(model)
            : null;
    }
}
