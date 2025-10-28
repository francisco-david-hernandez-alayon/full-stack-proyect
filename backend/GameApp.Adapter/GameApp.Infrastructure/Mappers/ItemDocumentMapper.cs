using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.Enumerates;
using GameApp.Infrastructure.Models;
using GameApp.Infrastructure.Enumerates;

namespace GameApp.Infrastructure.Mappers;

public static class ItemDocumentMapper
{
    public static ItemDocument ToDocument(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        var doc = new ItemDocument
        {
            Name = item.GetName().GetName(),
            Description = item.GetDescription().GetDescription()
        };

        switch (item)
        {
            case AttackItem attack:
                doc.ItemType = ItemType.Attack;
                doc.AttackDamage = attack.GetAttackDamage();
                doc.SpeedAttack = attack.GetSpeedAttack();
                doc.Durability = attack.GetDurability();
                break;

            case AtributeItem attr:
                doc.ItemType = ItemType.Attribute;
                doc.HealthPointsReceived = attr.GetHealthPointsReceived();
                doc.FoodPointsReceived = attr.GetFoodPointsReceived();
                break;

            default:
                doc.ItemType = ItemType.None;
                break;
        }

        return doc;
    }

    public static Item ToDomain(ItemDocument doc)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        ItemName name = new(doc.Name);
        ItemDescription desc = new(doc.Description);

        return doc.ItemType switch
        {
            ItemType.Attack => new AttackItem(
                name,
                desc,
                doc.AttackDamage ?? throw new ArgumentNullException(nameof(doc.AttackDamage)),
                doc.SpeedAttack ?? throw new ArgumentNullException(nameof(doc.SpeedAttack)),
                doc.Durability ?? throw new ArgumentNullException(nameof(doc.Durability))
            ),
            ItemType.Attribute => new AtributeItem(
                name,
                desc,
                doc.HealthPointsReceived ?? throw new ArgumentNullException(nameof(doc.HealthPointsReceived)),
                doc.FoodPointsReceived ?? throw new ArgumentNullException(nameof(doc.FoodPointsReceived))
            ),
            _ => throw new ArgumentException($"Unsupported ItemType: {doc.ItemType}")
        };
    }
}
