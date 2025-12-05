import { Item } from './item.js'

// Specific class for attribute items
export class AttributeItem extends Item {
  constructor(name, description, tradePrice, healthPointsReceived, foodPointsReceived, id = null) {
    super(name, description, tradePrice, id);

    this.#validateNumber(healthPointsReceived, "healthPointsReceived");
    this.#validateNumber(foodPointsReceived, "foodPointsReceived");

    this._healthPointsReceived = healthPointsReceived;
    this._foodPointsReceived = foodPointsReceived;
  }

  #validateNumber(value, paramName) {
    if (typeof value !== "number" || !Number.isFinite(value)) {
      throw new TypeError(`Parameter '${paramName}' must be a finite number`);
    }
  }

  // getter
  get healthPointsReceived() {
    return this._healthPointsReceived;
  }

  get foodPointsReceived() {
    return this._foodPointsReceived;
  }

  // setter
  setHealthPointsReceived(newValue) {
    return new AttributeItem(this._name, this._description, this._tradePrice, newValue, this._foodPointsReceived, this._id);
  }

  setFoodPointsReceived(newValue) {
    return new AttributeItem(this._name, this._description, this._tradePrice, this._healthPointsReceived, newValue, this._id);
  }

  toString() {
    return `${this._name.toString()} atribute item(${this._id}), price=${this._tradePrice}: HealthPointsReceived=${this._healthPointsReceived}, FoodPointsReceived=${this._foodPointsReceived}`;
  }
}