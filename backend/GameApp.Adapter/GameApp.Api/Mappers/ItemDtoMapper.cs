using GameApp.Adapter.Api.dtos;
using GameApp.Adapter.Api.dtos.ItemsDto;
using GameApp.Application.Enumerates;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Api.Mappers;

public static class ItemDtoMapper
{
    public static Item ToDomain(ItemResponseDto dto)
    {
        // Check nullability
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));
        if (dto.Description == null)
            throw new ArgumentNullException(nameof(dto.Name));

        Guid id = dto.Id;
        ItemName itemName = new ItemName(dto.Name);
        ItemDescription itemDescription = new ItemDescription(dto.Description);
        int itemTradePrice = dto.TradePrice;

        return dto.ItemType switch
        {
            ItemType.Attack => new AttackItem(id, itemName, itemDescription, itemTradePrice,
                dto.AttackDamage ?? throw new ArgumentNullException(nameof(dto.AttackDamage),
                        "AttackDamage is required for AttackItem")
                 , dto.SpeedAttack ?? throw new ArgumentNullException(nameof(dto.SpeedAttack),
                        "SpeedAttack is required for AttackItem")
                , dto.Durability ?? throw new ArgumentNullException(nameof(dto.Durability),
                        "Durability is required for AttackItem")
                        ),

            ItemType.Attribute => new AtributeItem(id, itemName, itemDescription, itemTradePrice,
                dto.HealthPointsReceived ?? throw new ArgumentNullException(nameof(dto.HealthPointsReceived),
                        "HealthPointsReceived is required for AttributeItem"),
                dto.FoodPointsReceived ?? throw new ArgumentNullException(nameof(dto.FoodPointsReceived),
                        "FoodPointsReceived is required for AttributeItem")),

            _ => throw new ArgumentException($"Unsupported ItemType type: {dto.ItemType}")
        }
        ;
    }


    public static Item ToDomainFromCreateRequest(ItemCreateRequestDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));
        if (dto.Description == null)
            throw new ArgumentNullException(nameof(dto.Description));

        ItemName itemName = new ItemName(dto.Name);
        ItemDescription itemDescription = new ItemDescription(dto.Description);
        int tradePrice = dto.TradePrice;

        return dto.ItemType switch
        {
            ItemType.Attack => new AttackItem(
                itemName,
                itemDescription,
                tradePrice,
                dto.AttackDamage ?? throw new ArgumentNullException(nameof(dto.AttackDamage),
                    "AttackDamage is required for AttackItem"),
                dto.SpeedAttack ?? throw new ArgumentNullException(nameof(dto.SpeedAttack),
                    "SpeedAttack is required for AttackItem"),
                dto.Durability ?? 1 // por defecto 1 si no se especifica
            ),

            ItemType.Attribute => new AtributeItem(
                itemName,
                itemDescription,
                tradePrice,
                dto.HealthPointsReceived ?? throw new ArgumentNullException(nameof(dto.HealthPointsReceived),
                    "HealthPointsReceived is required for AttributeItem"),
                dto.FoodPointsReceived ?? throw new ArgumentNullException(nameof(dto.FoodPointsReceived),
                    "FoodPointsReceived is required for AttributeItem")
            ),

            _ => throw new ArgumentException($"Unsupported ItemType: {dto.ItemType}")
        };
    }

    public static Item ToDomainFromUpdateRequest(ItemUpdateRequestDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        if (dto.Name == null)
            throw new ArgumentNullException(nameof(dto.Name));
        if (dto.Description == null)
            throw new ArgumentNullException(nameof(dto.Description));

        ItemName itemName = new ItemName(dto.Name);
        ItemDescription itemDescription = new ItemDescription(dto.Description);
        int tradePrice = dto.TradePrice;

        return dto.ItemType switch
        {
            ItemType.Attack => new AttackItem(
                itemName,
                itemDescription,
                tradePrice,
                dto.AttackDamage ?? throw new ArgumentNullException(nameof(dto.AttackDamage),
                    "AttackDamage is required for AttackItem"),
                dto.SpeedAttack ?? throw new ArgumentNullException(nameof(dto.SpeedAttack),
                    "SpeedAttack is required for AttackItem"),
                dto.Durability ?? 1 // default
            ),

            ItemType.Attribute => new AtributeItem(
                itemName,
                itemDescription,
                tradePrice,
                dto.HealthPointsReceived ?? throw new ArgumentNullException(nameof(dto.HealthPointsReceived),
                    "HealthPointsReceived is required for AttributeItem"),
                dto.FoodPointsReceived ?? throw new ArgumentNullException(nameof(dto.FoodPointsReceived),
                    "FoodPointsReceived is required for AttributeItem")
            ),

            _ => throw new ArgumentException($"Unsupported ItemType: {dto.ItemType}")
        };
    }


    public static ItemResponseDto ToDto(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        ItemResponseDto dto = new ItemResponseDto
        {
            Id = item.GetGuid(),
            Name = item.GetName().GetName(),
            Description = item.GetDescription().GetDescription(),
            TradePrice = item.GetTradePrice()
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

    public static List<ItemResponseDto> ToDtoList(IEnumerable<Item> items)
    {
        return items.Select(ToDto).ToList();
    }

}
