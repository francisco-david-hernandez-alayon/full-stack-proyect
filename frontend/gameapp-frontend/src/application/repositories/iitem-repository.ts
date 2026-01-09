import type { ItemType } from '../enumerates/item-type';
import { Item } from '../../domain/entities/items/item';
import { ItemName } from '../../domain/value-objects/items/item-name';
import type { ItemRarity } from '../../domain/enumerates/item-rarity';

export interface IItemRepository {
    fetchById(id: string): Promise<Item>;
    fetchByName(name: ItemName): Promise<Item>;
    fetchAll(): Promise<Item[]>;
    fetchAllByFilter(type?: ItemType, rarity?: ItemRarity): Promise<Item[]>;
    save(item: Item): Promise<Item>;
    delete(id: string): Promise<Item>;
    update(id: string, item: Item): Promise<Item>;
}
