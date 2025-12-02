import { IEnemyGetUseCase } from "../../usecases/enemy-use-cases/enemy-get-use-case";
import { IenemyRepository } from "../../repositories/ienemy-repository";

export class EnemyGetService extends IEnemyGetUseCase {
    constructor(enemyRepository) {
        super();
        if (!(enemyRepository instanceof IenemyRepository)) {
            throw new TypeError("enemyRepository must be an instance of IenemyRepository");
        }
        this.enemyRepository = enemyRepository;
    }

    async getEnemy(id) {
        if (!id) throw new TypeError("id is required");
        return await this.enemyRepository.fetchById(id);
    }

    async getEnemyByName(name) {
        if (!name) throw new TypeError("name is required");
        return await this.enemyRepository.fetchByName(name);
    }

    async getAllEnemys() {
        return await this.enemyRepository.fetchAll();
    }
}
