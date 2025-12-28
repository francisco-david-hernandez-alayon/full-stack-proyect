import { Item } from './item';
import { ItemName } from '../../value-objects/items/item-name';
import { ItemDescription } from '../../value-objects/items/item-description';

export class AttributeItem extends Item {
    private _healthPointsReceived: number;
    private _foodPointsReceived: number;

    constructor(
        name: ItemName,
        description: ItemDescription,
        tradePrice: number,
        healthPointsReceived: number,
        foodPointsReceived: number,
        id: string | null = null
    ) {
        super(name, description, tradePrice, id);
        this._healthPointsReceived = healthPointsReceived;
        this._foodPointsReceived = foodPointsReceived;
    }

    // getters
    get healthPointsReceived(): number { return this._healthPointsReceived; }
    get foodPointsReceived(): number { return this._foodPointsReceived; }

    // setters
    setHealthPointsReceived(newValue: number): AttributeItem {
        return new AttributeItem(this._name, this._description, this._tradePrice, newValue, this._foodPointsReceived, this._id);
    }

    setFoodPointsReceived(newValue: number): AttributeItem {
        return new AttributeItem(this._name, this._description, this._tradePrice, this._healthPointsReceived, newValue, this._id);
    }

    toString(): string {
        return `${this._name.toString()} attribute item(${this._id}), price=${this._tradePrice}: HealthPointsReceived=${this._healthPointsReceived}, FoodPointsReceived=${this._foodPointsReceived}`;
    }
}
