import { IItemUpdateUseCase } from "../../usecases/item-use-cases/item-update-use-case";
import { IitemRepository } from "../../repositories/iitem-repository";

export class ItemUpdateService extends IItemUpdateUseCase {
    constructor(itemRepository) {
        super();
        if (!(itemRepository instanceof IitemRepository)) {
            throw new TypeError("itemRepository must be an instance of IitemRepository");
        }
        this.itemRepository = itemRepository;
    }

    async updateItem(id, Item) {
        if (!id) throw new TypeError("id is required");
        if (!Item) throw new TypeError("Item is required");

        const updatedItem = await this.itemRepository.update(id, Item);
        return updatedItem;
    }
}
