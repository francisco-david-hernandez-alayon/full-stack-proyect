import type { IItemGetUseCase } from "../../usecases/item-use-cases/item-get-use-case";
import type { IItemRepository } from "../../repositories/iitem-repository";
import { Item } from "../../../domain/entities/items/item";
import type { ItemName } from "../../../domain/value-objects/items/item-name";
import type { ItemType } from "../../enumerates/item-type";

export class ItemGetService implements IItemGetUseCase {
    constructor(private itemRepository: IItemRepository) {}

    async getItem(id: string): Promise<Item> {
        return await this.itemRepository.fetchById(id);
    }

    async getItemByName(name: ItemName): Promise<Item> {
        return await this.itemRepository.fetchByName(name);
    }

    async getItemByType(type: ItemType): Promise<Item[]> {
        return await this.itemRepository.fetchAllByType(type);
    }

    async getAllItems(): Promise<Item[]> {
        return await this.itemRepository.fetchAll();
    }
}
