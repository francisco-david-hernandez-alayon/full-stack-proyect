import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";
import { ItemType } from "../enumerates/item-type";
import { ItemDescription } from "../../../domain/value-objects/items/item-description";
import { ItemName } from "../../../domain/value-objects/items/item-name";

export class ItemJsonResponse {
    constructor(itemJson) {
        if (!itemJson) throw new TypeError("itemJson response is required");

        this.id = itemJson.id;
        this.name = itemJson.name;
        this.description = itemJson.description;
        this.itemType = itemJson.itemType;
        this.tradePrice = itemJson.tradePrice ?? null;

        // attack item fields
        this.attackDamage = itemJson.attackDamage ?? null;
        this.speedAttack = itemJson.speedAttack ?? null;
        this.durability = itemJson.durability ?? null;

        // attribute item fields
        this.healthPointsReceived = itemJson.healthPointsReceived ?? null;
        this.foodPointsReceived = itemJson.foodPointsReceived ?? null;
    }

    toItem() {
        const name = new ItemName(this.name);
        const desc = new ItemDescription(this.description);

        switch (this.itemType) {
            case ItemType.Attribute:
                return new AttributeItem(
                    name,
                    desc,
                    this.tradePrice,
                    this.healthPointsReceived,
                    this.foodPointsReceived,
                    this.id
                );
            case ItemType.Attack:
                return new AttackItem(
                    name,
                    desc,
                    this.tradePrice,
                    this.attackDamage,
                    this.speedAttack,
                    this.durability,
                    this.id
                );
            default:
                throw new TypeError(`Unknown ItemType: ${this.itemType}`);
        }
    }
}
