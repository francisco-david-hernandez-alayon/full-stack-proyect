using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Infrastructure.Data;
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
        return await _context.Games.ToListAsync();
    }

    public async Task<Game?> FetchByIdAsync(Guid id)
    {
        return await _context.Games.FindAsync(id);
    }

    public async Task<Game?> DeleteAsync(Guid id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game is null) return null;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> SaveAsync(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game?> UpdateAsync(Game game)
    {
        var existing = await _context.Games.FindAsync(game.GetGuid());
        if (existing is null) return null;

        _context.Entry(existing).CurrentValues.SetValues(game);
        await _context.SaveChangesAsync();
        return game;
    }
}
