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
        var models = await _context.Games.ToListAsync();
        return models.Select(GameMapper.ToDomain);
    }

    public async Task<Game?> FetchByIdAsync(Guid id)
    {
        var model = await _context.Games.FindAsync(id);
        return model is null ? null : GameMapper.ToDomain(model);
    }

    public async Task<Game?> SaveAsync(Game game)
    {
        var model = GameMapper.ToDataModel(game);
        _context.Games.Add(model);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> UpdateAsync(Game game)
    {
        var model = GameMapper.ToDataModel(game);
        _context.Games.Update(model);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> DeleteAsync(Guid id)
    {
        var model = await _context.Games.FindAsync(id);
        if (model is null) return null;
        _context.Games.Remove(model);
        await _context.SaveChangesAsync();
        return GameMapper.ToDomain(model);
    }
}
