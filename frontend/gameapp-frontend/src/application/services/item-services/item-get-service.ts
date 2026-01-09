import type { IItemGetUseCase } from "../../usecases/item-use-cases/item-get-use-case";
import type { IItemRepository } from "../../repositories/iitem-repository";
import { Item } from "../../../domain/entities/items/item";
import type { ItemName } from "../../../domain/value-objects/items/item-name";
import type { ItemType } from "../../enumerates/item-type";
import type { ItemRarity } from "../../../domain/enumerates/item-rarity";

export class ItemGetService implements IItemGetUseCase {
    constructor(private itemRepository: IItemRepository) {}

    async getItem(id: string): Promise<Item> {
        return await this.itemRepository.fetchById(id);
    }

    async getItemByName(name: ItemName): Promise<Item> {
        return await this.itemRepository.fetchByName(name);
    }

    async getItemByFilter(type?: ItemType, rarity?: ItemRarity): Promise<Item[]> {
        return await this.itemRepository.fetchAllByFilter(type, rarity);
    }

    async getAllItems(): Promise<Item[]> {
        return await this.itemRepository.fetchAll();
    }
}
