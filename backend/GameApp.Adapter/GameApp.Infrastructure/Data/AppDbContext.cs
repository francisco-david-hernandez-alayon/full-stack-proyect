using GameApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<GamePersistenceModel> Games { get; set; } = default!;

    public DbSet<CharacterPersistenceModel> Characters { get; set; } = default!;

    public DbSet<ScenePersistenceModel> Scenes{ get; set; } = default!;

    public DbSet<FinalScenePersistenceModel> FinalScenes{ get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GamePersistenceModel>()
            .HasOne(g => g.Character)
            .WithMany()
            .HasForeignKey(g => g.CharacterId);

        modelBuilder.Entity<GamePersistenceModel>()
            .HasOne(g => g.FinalScene)
            .WithMany()
            .HasForeignKey(g => g.FinalSceneId);
    }


}
