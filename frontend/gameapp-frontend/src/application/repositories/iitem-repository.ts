import { Item } from '../../domain/entities/items/item';
import { ItemName } from '../../domain/value-objects/items/item-name';

export interface IItemRepository {
    fetchById(id: string): Promise<Item>;
    fetchByName(name: ItemName): Promise<Item>;
    fetchAll(): Promise<Item[]>;
    save(item: Item): Promise<Item>;
    delete(id: string): Promise<Item>;
    update(id: string, item: Item): Promise<Item>;
}
