import { Item } from '../../../domain/entities/items/item';

export interface IItemCreateUseCase {
  createItem(item: Item): Promise<Item>;
}
