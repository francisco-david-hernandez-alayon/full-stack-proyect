import { Item } from '../../../domain/entities/items/item';

export interface IItemDeleteUseCase {
  deleteItem(id: string): Promise<Item>;
}
