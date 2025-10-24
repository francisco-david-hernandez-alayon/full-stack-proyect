using System.Text.Json;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class CharacterPersistenceMapper
{
    public static CharacterPersistenceModel ToPersistenceModel(Character character)
    {
        return new CharacterPersistenceModel
        {
            Type = character switch
            {
                WarriorCharacter => "WarriorCharacter",
                _ => "Unknown"
            },
            CurrentHealthPoints = character.CurrentHealthPoints,
            CurrentFoodPoints = character.CurrentFoodPoints,
            CurrentMoney = character.CurrentMoney,
            InventoryJson = JsonSerializer.Serialize(
                character.InventoryList.Select(ItemPersistenceMapper.ToPersistenceModel).ToList()
            )
        };
    }

    public static Character ToDomain(CharacterPersistenceModel model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        var inventoryList = new List<Item>();
        if (!string.IsNullOrWhiteSpace(model.InventoryJson))
        {
            try
            {
                var items = JsonSerializer.Deserialize<List<ItemPersistenceModel>>(model.InventoryJson);
                if (items != null)
                    inventoryList = items.Select(ItemPersistenceMapper.ToDomain).ToList();
            }
            catch (JsonException)
            {
                inventoryList = new List<Item>();
            }
        }

        if (string.IsNullOrWhiteSpace(model.Type))
            throw new NotSupportedException("Character type is null or empty in DB");

        return model.Type switch
        {
            "WarriorCharacter" => new WarriorCharacter(
                currentHealthPoints: model.CurrentHealthPoints,
                currentFoodPoints: model.CurrentFoodPoints,
                currentMoney: model.CurrentMoney,
                inventoryList: inventoryList
            ),
            _ => throw new NotSupportedException($"Unsupported character type: {model.Type}")
        };
    }


}
