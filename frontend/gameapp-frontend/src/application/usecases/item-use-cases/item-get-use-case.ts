import { Item } from '../../../domain/entities/items/item';
import type { ItemName } from '../../../domain/value-objects/items/item-name';

export interface IItemGetUseCase {
  getItem(id: string): Promise<Item>;
  getItemByName(name: ItemName): Promise<Item>;
  getAllItems(): Promise<Item[]>;
}
