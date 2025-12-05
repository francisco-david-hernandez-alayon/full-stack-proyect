import type { IItemDeleteUseCase } from "../../usecases/item-use-cases/item-delete-use-case";
import type { IItemRepository } from "../../repositories/iitem-repository";
import { Item } from "../../../domain/entities/items/item";

export class ItemDeleteService implements IItemDeleteUseCase {
    constructor(private itemRepository: IItemRepository) {}

    async deleteItem(id: string): Promise<Item> {
        const deletedItem = await this.itemRepository.delete(id);
        return deletedItem;
    }
}
