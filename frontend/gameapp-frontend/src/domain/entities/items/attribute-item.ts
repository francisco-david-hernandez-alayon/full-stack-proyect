import { Item } from './item';
import { ItemName } from '../../value-objects/items/item-name';
import { ItemDescription } from '../../value-objects/items/item-description';
import type { ItemRarity } from '../../enumerates/item-rarity';

export class AttributeItem extends Item {
    private _healthPointsReceived: number;
    private _foodPointsReceived: number;

    constructor(
        rarity: ItemRarity,
        name: ItemName,
        description: ItemDescription,
        tradePrice: number,
        healthPointsReceived: number,
        foodPointsReceived: number,
        id: string | null = null
    ) {
        super(rarity, name, description, tradePrice, id);
        this._healthPointsReceived = healthPointsReceived;
        this._foodPointsReceived = foodPointsReceived;
    }

    // getters
    get healthPointsReceived(): number { return this._healthPointsReceived; }
    get foodPointsReceived(): number { return this._foodPointsReceived; }

    // setters
    setHealthPointsReceived(newValue: number): AttributeItem {
        return new AttributeItem(this._rarity, this._name, this._description, this._tradePrice, newValue, this._foodPointsReceived, this._id);
    }

    setFoodPointsReceived(newValue: number): AttributeItem {
        return new AttributeItem(this._rarity, this._name, this._description, this._tradePrice, this._healthPointsReceived, newValue, this._id);
    }

    toString(): string {
        return `${this._name.toString()} attribute item(${this._id}, rarity=${this._rarity})), price=${this._tradePrice}: HealthPointsReceived=${this._healthPointsReceived}, FoodPointsReceived=${this._foodPointsReceived}`;
    }
}
