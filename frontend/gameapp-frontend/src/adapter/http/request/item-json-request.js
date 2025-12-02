import { Item } from "../../../domain/entities/items/item";


export class ItemJsonRequest {
    constructor(item) {
        if (!item) throw new TypeError("item is required");
        if (!(item instanceof Item)) throw new TypeError("item must be an instance of Item");

        this.id = item.id;
        this.name = item.name.name;
        this.description = item.description.description;
        this.itemType = item.itemType;

        // optional atributtes
        this.healthPointsReceived = item.healthPointsReceived ?? null;
        this.foodPointsReceived = item.foodPointsReceived ?? null;
        this.attackDamage = item.attackDamage ?? null;
        this.speedAttack = item.speedAttack ?? null;
        this.durability = item.durability ?? null;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
