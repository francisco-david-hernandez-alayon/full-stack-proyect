using GameApp.Api.dtos;
using GameApp.Api.Enumerates;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Api.Mappers;

public static class CharacterDtoMapper
{
    public static Character ToDomain(CharacterDto dto)
    {
        // Check nullability
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        
        return dto.Type switch
        {
            CharacterType.Warrior => new WarriorCharacter(),

            _ => throw new ArgumentException($"Unsupported character type: {dto.Type}")
        };
    }


    public static CharacterDto ToDto(Character character)
    {
        return new CharacterDto
        {
            Type = character switch
            {
                WarriorCharacter => CharacterType.Warrior,
                _ => CharacterType.None
            }
        };
    }

}
