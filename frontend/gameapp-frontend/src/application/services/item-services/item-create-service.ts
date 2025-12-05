import type { IItemCreateUseCase } from "../../usecases/item-use-cases/item-create-use-case";
import type { IItemRepository } from "../../repositories/iitem-repository";
import { Item } from "../../../domain/entities/items/item";

export class ItemCreateService implements IItemCreateUseCase {
    constructor(private itemRepository: IItemRepository) {}

    async createItem(item: Item): Promise<Item> {
        const savedItem = await this.itemRepository.save(item);
        return savedItem;
    }
}
