import { Item } from './item.js'

// Specific class for attribute items
export class AttributeItem extends Item {
  constructor(name, description, healthPointsReceived, foodPointsReceived) {
    super(name, description);

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
    return new AttributeItem(this._name, this._description, newValue, this._foodPointsReceived);
  }

  setFoodPointsReceived(newValue) {
    return new AttributeItem(this._name, this._description, this._healthPointsReceived, newValue);
  }

  toString() {
    return `${this._name.toString()} atribute item: HealthPointsReceived=${this._healthPointsReceived}, FoodPointsReceived=${this._foodPointsReceived}`;
  }
}