using GameApp.Api.Enumerates;

namespace GameApp.Api.dtos;

public class CharacterDto
{
    public CharacterType Type { get; set; } = default!; 
}