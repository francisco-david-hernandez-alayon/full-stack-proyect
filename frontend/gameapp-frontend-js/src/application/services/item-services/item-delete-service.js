import { IItemDeleteUseCase } from "../../usecases/item-use-cases/item-delete-use-case";
import { IitemRepository } from "../../repositories/iitem-repository";

export class ItemDeleteService extends IItemDeleteUseCase {
    constructor(itemRepository) {
        super();
        if (!(itemRepository instanceof IitemRepository)) {
            throw new TypeError("itemRepository must be an instance of IitemRepository");
        }
        this.itemRepository = itemRepository;
    }

    async deleteItem(id) {
        if (!id) throw new TypeError("id is required");

        const deletedItem = await this.itemRepository.delete(id);
        return deletedItem;
    }
}
