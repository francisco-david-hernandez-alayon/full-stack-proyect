using GameApp.Domain.ValueObjects.Items;
using GameApp.Infrastructure.Data.Models;

namespace GameApp.Infrastructure.Mappers;

public static class ItemPersistenceMapper
{
    public static ItemPersistenceModel ToPersistenceModel(Item item)
    {
        var model = new ItemPersistenceModel
        {
            Name = item.Name.ToString(),
            Description = item.Description.ToString(),
            ItemType = item.GetType().Name
        };

        switch (item)
        {
            case AttackItem a:
                model.AttackDamage = a.AttackDamage;
                model.SpeedAttack = a.SpeedAttack;
                model.Durability = a.Durability;
                break;

            case AtributeItem attr:
                model.HealthPointsReceived = attr.HealthPointsReceived;
                model.FoodPointsReceived = attr.FoodPointsReceived;
                break;
        }

        return model;
    }

    public static Item ToDomain(ItemPersistenceModel model)
    {
        var name = new ItemName(model.Name);
        var description = new ItemDescription(model.Description);

        return model.ItemType switch
        {
            nameof(AttackItem) => new AttackItem(
                name,
                description,
                model.AttackDamage ?? throw new InvalidOperationException("AttackDamage is required for AttackItem"),
                model.SpeedAttack ?? throw new InvalidOperationException("SpeedAttack is required for AttackItem"),
                model.Durability ?? throw new InvalidOperationException("Durability is required for AttackItem")
            ),

            nameof(AtributeItem) => new AtributeItem(
                name,
                description,
                model.HealthPointsReceived ?? throw new InvalidOperationException("HealthPointsReceived is required for AtributeItem"),
                model.FoodPointsReceived ?? throw new InvalidOperationException("FoodPointsReceived is required for AtributeItem")
            ),

            _ => throw new NotSupportedException($"Unsupported item type: {model.ItemType}")
        };
    }
}
