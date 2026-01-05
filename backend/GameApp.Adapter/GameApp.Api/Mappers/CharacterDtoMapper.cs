using GameApp.Adapter.Api.dtos;
using GameApp.Adapter.Api.dtos.OthersDto;
using GameApp.Application.Enumerates;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Adapter.Api.Mappers;

public static class CharacterDtoMapper
{
    public static Character ToDomain(CharacterResponseDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        Character character = dto.Type switch
        {
            CharacterType.Warrior => new WarriorCharacter(
                currentHealthPoints: dto.CurrentHealthPoints,
                currentFoodPoints: dto.CurrentFoodPoints,
                currentMoney: dto.CurrentMoney,
                inventoryList: dto.InventoryList.Select(ItemDtoMapper.ToDomain).ToList(),
                currentHits: dto.CurrentHits ?? 0  // 0 by default
            ),

            CharacterType.Thief => new ThiefCharacter(
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
        switch (type)
        {
            case CharacterType.Warrior:
                return new WarriorCharacter();

            case CharacterType.Thief:
                return new ThiefCharacter();

            default:
                throw new ArgumentException($"Unsupported character type: {type}");
        }
    }


    public static CharacterResponseDto ToDto(Character character)
    {

        // Get character atributes
        int? currentHits = null;
        if (character is WarriorCharacter warrior)
        {
            currentHits = warrior.GetHits();
        }

        return new CharacterResponseDto
        {
            Type = character switch
            {
                WarriorCharacter => CharacterType.Warrior,
                ThiefCharacter => CharacterType.Thief,
                _ => CharacterType.None
            },
            CurrentHealthPoints = character.GetCurrentHealthPoints(),
            CurrentFoodPoints = character.GetCurrentFoodPoints(),
            CurrentMoney = character.GetCurrentMoney(),
            InventoryList = character.GetInventoryList().Select(ItemDtoMapper.ToDto).ToList(),

            // optional atributes
            CurrentHits = currentHits,
        };
    }
}
