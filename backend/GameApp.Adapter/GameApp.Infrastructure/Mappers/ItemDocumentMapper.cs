using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.Enumerates;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Items;
using GameApp.Application.Enumerates;
using GameApp.Domain.ValueObjects.Combat;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class ItemDocumentMapper
{
    public static ItemDocument ToDocument(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        var doc = new ItemDocument
        {
            Id = item.GetGuid(),
            Rarity = item.GetRarity(),
            Name = item.GetName().GetName(),
            Description = item.GetDescription().GetDescription(),
            TradePrice = item.GetTradePrice()
        };

        switch (item)
        {
            case AttackItem attack:
                doc.ItemType = ItemType.Attack;
                doc.AttackDamage = attack.GetAttackDamage();
                doc.SpeedAttack = attack.GetSpeedAttack();
                doc.Durability = attack.GetDurability();
                doc.CriticalDamage = CriticalDamageDocumentMapper.ToDocument(attack.GetCriticalDamage());
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
        int price = doc.TradePrice;

        return doc.ItemType switch
        {
            ItemType.Attack => new AttackItem(
                doc.Id,
                doc.Rarity,
                name,
                desc,
                price,
                doc.AttackDamage ?? throw new ArgumentNullException(nameof(doc.AttackDamage)),
                doc.SpeedAttack ?? throw new ArgumentNullException(nameof(doc.SpeedAttack)),
                doc.Durability ?? throw new ArgumentNullException(nameof(doc.Durability)),
                CriticalDamageDocumentMapper.ToDomain(doc.CriticalDamage ?? new CriticalDamageDocument())
            ),
            ItemType.Attribute => new AtributeItem(
                doc.Id,
                doc.Rarity,
                name,
                desc,
                price,
                doc.HealthPointsReceived ?? throw new ArgumentNullException(nameof(doc.HealthPointsReceived)),
                doc.FoodPointsReceived ?? throw new ArgumentNullException(nameof(doc.FoodPointsReceived))
            ),
            _ => throw new ArgumentException($"Unsupported ItemType: {doc.ItemType}")
        };
    }
}
