import { ItemName } from '../../value-objects/items/item-name';
import { ItemDescription } from '../../value-objects/items/item-description';
import { v4 as uuidv4, validate as uuidValidate } from 'uuid';

export abstract class Item {
  protected _id: string;
  protected _name: ItemName;
  protected _description: ItemDescription;
  protected _tradePrice: number;

  constructor(name: ItemName, description: ItemDescription, tradePrice: number, id: string | null = null) {
    if (id) {
      if (!uuidValidate(id)) {
        throw new TypeError(`Invalid UUID: ${id}`);
      }
      this._id = id;
    } else {
      this._id = uuidv4();
    }
    this._name = name;
    this._description = description;
    this._tradePrice = tradePrice;
  }

  // getters
  get id(): string { return this._id; }
  get name(): ItemName { return this._name; }
  get description(): ItemDescription { return this._description; }
  get tradePrice(): number { return this._tradePrice; }
}
