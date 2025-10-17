using GameApp.Domain.Entities;
using GameApp.Domain.Repositories;
using GameApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;
    public GameRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Game>> GetAllAsync() => await _context.Games.ToListAsync();
    public async Task<Game?> GetByIdAsync(int id) => await _context.Games.FindAsync(id);
    public async Task AddAsync(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
    }
}
