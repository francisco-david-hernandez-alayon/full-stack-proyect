using GameApp.Domain.ValueObjects.Characters;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Adapter.Infrastructure.Enumerates;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class CharacterDocumentMapper
{
    public static CharacterDocument ToDocument(Character character)
    {
        return new CharacterDocument
        {
            Type = character switch
            {
                WarriorCharacter => CharacterType.Warrior,
                _ => CharacterType.None
            },
            CurrentHealthPoints = character.GetCurrentHealthPoints(),
            CurrentFoodPoints = character.GetCurrentFoodPoints(),
            CurrentMoney = character.GetCurrentMoney(),
            InventoryList = character.GetInventoryList().Select(ItemDocumentMapper.ToDocument).ToList()
        };
    }

    public static Character ToDomain(CharacterDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        return doc.Type switch
        {
            CharacterType.Warrior => new WarriorCharacter(
                currentHealthPoints: doc.CurrentHealthPoints,
                currentFoodPoints: doc.CurrentFoodPoints,
                currentMoney: doc.CurrentMoney,
                inventoryList: doc.InventoryList.Select(ItemDocumentMapper.ToDomain).ToList()
            ),
            _ => throw new ArgumentException($"Unsupported character type: {doc.Type}")
        };
    }
}
