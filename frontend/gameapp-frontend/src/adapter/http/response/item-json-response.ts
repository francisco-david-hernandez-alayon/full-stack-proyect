import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";
import { ItemDescription } from "../../../domain/value-objects/items/item-description";
import { ItemName } from "../../../domain/value-objects/items/item-name";
import type { Item } from "../../../domain/entities/items/item";
import { ItemType } from "../../../application/enumerates/item-type";
import type { ItemRarity } from "../../../domain/enumerates/item-rarity";

export class ItemJsonResponse {
    id: string;
    rarity: ItemRarity;
    name: string;
    description: string;
    itemType: ItemType;
    tradePrice: number | null;

    attackDamage: number | null;
    speedAttack: number | null;
    durability: number | null;

    healthPointsReceived: number | null;
    foodPointsReceived: number | null;

    constructor(itemJson: any) {
        if (!itemJson) throw new TypeError("itemJson response is required");

        this.id = itemJson.id;
        this.rarity = itemJson.rarity;
        this.name = itemJson.name;
        this.description = itemJson.description;
        this.itemType = itemJson.itemType;
        this.tradePrice = itemJson.tradePrice ?? undefined;

        this.attackDamage = itemJson.attackDamage ?? undefined;
        this.speedAttack = itemJson.speedAttack ?? undefined;
        this.durability = itemJson.durability ?? undefined;

        this.healthPointsReceived = itemJson.healthPointsReceived ?? undefined;
        this.foodPointsReceived = itemJson.foodPointsReceived ?? undefined;
    }

    toItem(): Item {
        const name = new ItemName(this.name);
        const desc = new ItemDescription(this.description);

        switch (this.itemType) {
            case ItemType.Attribute:
                return new AttributeItem(
                    this.rarity,
                    name,
                    desc,
                    this.tradePrice!,
                    this.healthPointsReceived!,
                    this.foodPointsReceived!,
                    this.id
                );
            case ItemType.Attack:
                return new AttackItem(
                    this.rarity,
                    name,
                    desc,
                    this.tradePrice!,
                    this.attackDamage!,
                    this.speedAttack!,
                    this.durability!,
                    this.id
                );
            default:
                throw new TypeError(`Unknown ItemType: ${this.itemType}`);
        }
    }
}
