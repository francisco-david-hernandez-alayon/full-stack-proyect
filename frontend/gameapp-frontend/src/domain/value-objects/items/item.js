import { ItemName } from './item-name.js'
import { ItemDescription } from './item-description.js'

// Abstract base class Item
export class Item {
  constructor(name, description) {
    if (!(name instanceof ItemName)) throw new TypeError("name must be ItemName");
    if (!(description instanceof ItemDescription)) throw new TypeError("description must be ItemDescription");

    this._name = name;
    this._description = description;
  }

  // getter
  get name() {
    return this._name;
  }

  get description() {
    return this._description;
  }
}