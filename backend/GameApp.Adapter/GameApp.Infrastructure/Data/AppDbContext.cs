using GameApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<GameDataModel> Games { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
