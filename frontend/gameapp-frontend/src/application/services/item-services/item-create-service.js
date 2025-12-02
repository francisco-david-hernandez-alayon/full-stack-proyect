import { IItemCreateUseCase } from "../../usecases/item-use-cases/item-create-use-case";
import { IitemRepository } from "../../repositories/iitem-repository";

export class ItemCreateService extends IItemCreateUseCase {
    constructor(itemRepository) {
        super();
        if (!(itemRepository instanceof IitemRepository)) {
            throw new TypeError("itemRepository must be an instance of IitemRepository");
        }
        this.itemRepository = itemRepository;
    }

    async createItem(Item) {
        if (!Item) throw new TypeError("Item is required");

        const savedItem = await this.itemRepository.save(Item);
        return savedItem;
    }
}
