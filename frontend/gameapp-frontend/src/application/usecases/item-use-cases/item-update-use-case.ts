import { Item } from '../../../domain/entities/items/item';

export interface IItemUpdateUseCase {
  updateItem(id: string, item: Item): Promise<Item>;
}
