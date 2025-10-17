using Microsoft.EntityFrameworkCore;
using GameApp.Domain.Entities;

namespace GameApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public void SeedData()
    {
        // if (!Games.Any())
        // {
        //     Games.AddRange(
        //         new Game { Id = 1, Title = "partida 1" },
        //         new Game { Id = 2, Title = "partida 2" }
        //     );
        //     SaveChanges();
        // }
    }
}
