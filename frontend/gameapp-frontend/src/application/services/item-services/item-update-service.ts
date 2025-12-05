import type { IItemUpdateUseCase } from "../../usecases/item-use-cases/item-update-use-case";
import type { IItemRepository } from "../../repositories/iitem-repository";
import { Item } from "../../../domain/entities/items/item";

export class ItemUpdateService implements IItemUpdateUseCase {
    constructor(private itemRepository: IItemRepository) { }

    async updateItem(id: string, item: Item): Promise<Item> {
        const updatedItem = await this.itemRepository.update(id, item);
        return updatedItem;
    }
}
