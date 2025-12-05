import { Item } from "../../../domain/entities/items/item";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";
import { ItemType } from "../enumerates/item-type";

export class ItemJsonRequest {
    id: string;
    name: string;
    description: string;
    itemType: ItemType;
    // Optional attributes
    healthPointsReceived?: number | null;
    foodPointsReceived?: number | null;
    attackDamage?: number | null;
    speedAttack?: number | null;
    durability?: number | null;

    constructor(item: Item) {
        this.id = item.id;
        this.name = item.name.name;
        this.description = item.description.description;

        // Determinar tipo y asignar atributos según el tipo
        if (item instanceof AttributeItem) {
            this.itemType = ItemType.Attribute;
            this.healthPointsReceived = item.healthPointsReceived ?? null;
            this.foodPointsReceived = item.foodPointsReceived ?? null;
            
        } else if (item instanceof AttackItem) {
            this.itemType = ItemType.Attack;
            this.attackDamage = item.attackDamage ?? null;
            this.speedAttack = item.speedAttack ?? null;
            this.durability = item.durability ?? null;

        } else {
            this.itemType = ItemType.None;
        }
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
