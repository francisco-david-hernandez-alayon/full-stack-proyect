namespace GameApp.Api.dtos;

public class FinalSceneDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Biome { get; set; } = default!; 

    // final scene always will be a NothingHappensScene 
}