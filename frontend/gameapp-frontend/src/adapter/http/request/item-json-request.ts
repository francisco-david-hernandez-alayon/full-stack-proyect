import { Item } from "../../../domain/entities/items/item";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";
import { ItemType } from "../../../application/enumerates/item-type";
import type { ItemRarity } from "../../../domain/enumerates/item-rarity";
import { CriticalDamageJsonRequest } from "./ciritcal-damage-json-request";
import type { ItemIcon } from "../../../domain/enumerates/item-icon";

export class ItemJsonRequest {
    id: string;
    rarity: ItemRarity;
    name: string;
    description: string;
    itemType: ItemType;
    icon: ItemIcon;
    tradePrice: number;

    // Optional attributes
    healthPointsReceived?: number;
    foodPointsReceived?: number;
    attackDamage?: number;
    speedAttack?: number;
    durability?: number;
    criticalDamage?: CriticalDamageJsonRequest;

    constructor(item: Item) {
        this.id = item.id;
        this.rarity = item.rarity;
        this.name = item.name.name;
        this.description = item.description.description;
        this.icon = item.icon;
        this.tradePrice = item.tradePrice;

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
            this.criticalDamage = new CriticalDamageJsonRequest(item.criticalDamage) ?? null

        } else {
            this.itemType = ItemType.None;
        }
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
