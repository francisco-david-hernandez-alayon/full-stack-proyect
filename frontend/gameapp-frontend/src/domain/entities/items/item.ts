import { ItemName } from '../../value-objects/items/item-name';
import { ItemDescription } from '../../value-objects/items/item-description';
import { v4 as uuidv4, validate as uuidValidate } from 'uuid';
import type { ItemRarity } from '../../enumerates/item-rarity';
import type { ItemIcon } from '../../enumerates/item-icon';

export abstract class Item {
  protected _id: string;
  protected _rarity: ItemRarity;
  protected _name: ItemName;
  protected _description: ItemDescription;
  protected _icon: ItemIcon;
  protected _tradePrice: number;

  constructor(rarity: ItemRarity, name: ItemName, description: ItemDescription, icon: ItemIcon, tradePrice: number, id: string | null = null) {
    if (id) {
      if (!uuidValidate(id)) {
        throw new TypeError(`Invalid UUID: ${id}`);
      }
      this._id = id;
    } else {
      this._id = uuidv4();
    }
    this._rarity = rarity;
    this._name = name;
    this._description = description;
    this._icon = icon;
    this._tradePrice = tradePrice;
  }

  // getters
  get id(): string { return this._id; }
  get rarity(): ItemRarity { return this._rarity; }
  get name(): ItemName { return this._name; }
  get description(): ItemDescription { return this._description; }
  get icon(): ItemIcon { return this._icon; }
  get tradePrice(): number { return this._tradePrice; }
}
