using GameApp.Domain.Enumerates;

namespace GameApp.Infrastructure.Models;

public class FinalSceneDocument
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Biome Biome { get; set; }
}
