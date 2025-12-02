import { ItemName } from '../../value-objects/items/item-name.js'
import { ItemDescription } from '../../value-objects/items/item-description.js';
import { validateOrGenerateUUID } from '../../../utils/validate-or-generate-uuid.js';

// Abstract base class Item
export class Item {
  constructor(name, description, tradePrice, id = null) {
    if (!(name instanceof ItemName)) throw new TypeError("name must be ItemName");
    if (!(description instanceof ItemDescription)) throw new TypeError("description must be ItemDescription");
    this.#validateNumber(tradePrice, "tradePrice");
    this._id = validateOrGenerateUUID(id);

    this._name = name;  
    this._description = description;
    this._tradePrice = tradePrice;
  }

  #validateNumber(value, paramName) {
    if (typeof value !== "number" || !Number.isFinite(value)) {
      throw new TypeError(`Parameter '${paramName}' must be a finite number`);
    }
  }

  // getter
  get id() { return this._id; }

  get name() { return this._name; }

  get description() { return this._description; }

  get tradePrice() { return this.tradePrice; }
}