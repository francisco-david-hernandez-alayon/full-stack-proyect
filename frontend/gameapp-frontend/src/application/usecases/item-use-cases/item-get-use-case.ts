import { Item } from '../../../domain/entities/items/item';
import type { ItemRarity } from '../../../domain/enumerates/item-rarity';
import type { ItemName } from '../../../domain/value-objects/items/item-name';
import type { ItemType } from '../../enumerates/item-type';

export interface IItemGetUseCase {
  getItem(id: string): Promise<Item>;
  getItemByName(name: ItemName): Promise<Item>;
  getItemByFilter(type?: ItemType, rarity?: ItemRarity): Promise<Item[]>;
  getAllItems(): Promise<Item[]>;
}
