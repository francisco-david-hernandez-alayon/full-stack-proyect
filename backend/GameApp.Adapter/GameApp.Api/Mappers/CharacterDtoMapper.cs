using GameApp.Api.dtos;
using GameApp.Api.Enumerates;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Api.Mappers;

public static class CharacterDtoMapper
{
    public static Character ToDomain(CharacterDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        Character character = dto.Type switch
        {
            CharacterType.Warrior => new WarriorCharacter(
                currentHealthPoints: dto.CurrentHealthPoints,
                currentFoodPoints: dto.CurrentFoodPoints,
                currentMoney: dto.CurrentMoney,
                inventoryList: dto.InventoryList.Select(ItemDtoMapper.ToDomain).ToList()
            ),

            _ => throw new ArgumentException($"Unsupported character type: {dto.Type}")
        };

        return character;
    }

    public static Character ToDomainFromType(CharacterType type)
    {
        if (type == CharacterType.Warrior)
        {
            return new WarriorCharacter();
        }   else
        {
            return new WarriorCharacter();
        }
    }

    public static CharacterDto ToDto(Character character)
    {
        return new CharacterDto
        {
            Type = character switch
            {
                WarriorCharacter => CharacterType.Warrior,
                _ => CharacterType.None
            },
            CurrentHealthPoints = character.GetCurrentHealthPoints(),
            CurrentFoodPoints = character.GetCurrentFoodPoints(),
            CurrentMoney = character.GetCurrentMoney(),
            InventoryList = character.GetInventoryList().Select(ItemDtoMapper.ToDto).ToList()
        };
    }
}
