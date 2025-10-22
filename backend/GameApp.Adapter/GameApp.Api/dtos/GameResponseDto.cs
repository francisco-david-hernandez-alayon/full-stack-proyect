public class GameResponseDto
{
    public Guid Id { get; set; }
    public string CharacterType { get; set; } = default!;
    public List<string> CompletedScenes { get; set; } = new();
    public string FinalSceneName { get; set; } = default!;
}
