namespace GameApp.Infrastructure.Data.Models;

public class FinalScenePersistenceModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Biome { get; set; } = default!;

}
