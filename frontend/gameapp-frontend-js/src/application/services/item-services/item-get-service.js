import { IItemGetUseCase } from "../../usecases/item-use-cases/item-get-use-case";
import { IitemRepository } from "../../repositories/iitem-repository";

export class ItemGetService extends IItemGetUseCase {
    constructor(itemRepository) {
        super();
        if (!(itemRepository instanceof IitemRepository)) {
            throw new TypeError("itemRepository must be an instance of IitemRepository");
        }
        this.itemRepository = itemRepository;
    }

    async getItem(id) {
        if (!id) throw new TypeError("id is required");
        return await this.itemRepository.fetchById(id);
    }

    async getItemByName(name) {
        if (!name) throw new TypeError("name is required");
        return await this.itemRepository.fetchByName(name);
    }

    async getAllItems() {
        return await this.itemRepository.fetchAll();
    }
}
