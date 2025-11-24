import { Item } from "../../../domain/value-objects/items/item";


export class ItemJsonRequest {
    constructor(item) {
        if (!item) throw new TypeError("item is required");
        if (!(item instanceof Item)) throw new TypeError("item must be an instance of Item");

        this.name = item._name;
        this.description = item._description;
        this.itemType = item._itemType;

        // opcionales dependiendo del tipo
        this.healthPointsReceived = item._healthPointsReceived ?? null;
        this.foodPointsReceived = item._foodPointsReceived ?? null;
        this.attackDamage = item._attackDamage ?? null;
        this.speedAttack = item._speedAttack ?? null;
        this.durability = item._durability ?? null;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
