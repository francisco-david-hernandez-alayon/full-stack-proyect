using GameApp.Api.dtos;
using GameApp.Api.Enumerates;
using GameApp.Domain.ValueObjects;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Api.Mappers;

public static class ItemDtoMapper
{
    public static Item ToDomain(ItemDto dto)
    {
        // Check nullability
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));
        if (dto.Description == null)
            throw new ArgumentNullException(nameof(dto.Name));

        ItemName itemName = new ItemName(dto.Name);
        ItemDescription itemDescription = new ItemDescription(dto.Description);

        return dto.ItemType switch
        {
            ItemType.Attack => new AttackItem(itemName, itemDescription,
                dto.AttackDamage ?? throw new ArgumentNullException(nameof(dto.AttackDamage),
                        "AttackDamage is required for AttackItem")
                 , dto.SpeedAttack ?? throw new ArgumentNullException(nameof(dto.SpeedAttack),
                        "SpeedAttack is required for AttackItem")
                , dto.Durability ?? throw new ArgumentNullException(nameof(dto.Durability),
                        "Durability is required for AttackItem")
                        ),

            ItemType.Attribute => new AtributeItem(itemName, itemDescription,
                dto.HealthPointsReceived ?? throw new ArgumentNullException(nameof(dto.HealthPointsReceived),
                        "HealthPointsReceived is required for AttributeItem"),
                dto.FoodPointsReceived ?? throw new ArgumentNullException(nameof(dto.FoodPointsReceived),
                        "FoodPointsReceived is required for AttributeItem")),

            _ => throw new ArgumentException($"Unsupported ItemType type: {dto.ItemType}")
        }
        ;
    }


    public static ItemDto ToDto(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        ItemDto dto = new ItemDto
        {
            Name = item.GetName().GetName(),
            Description = item.GetDescription().GetDescription()
        };

        switch (item)
        {
            case AttackItem attack:
                dto.ItemType = ItemType.Attack;
                dto.AttackDamage = attack.GetAttackDamage();
                dto.SpeedAttack = attack.GetSpeedAttack();
                dto.Durability = attack.GetDurability();
                break;

            case AtributeItem attr:
                dto.ItemType = ItemType.Attribute;
                dto.HealthPointsReceived = attr.GetHealthPointsReceived();
                dto.FoodPointsReceived = attr.GetFoodPointsReceived();
                break;

            default:
                dto.ItemType = ItemType.None;
                break;
        }

        return dto;
    }

}
