import { IEnemyDeleteUseCase } from "../../usecases/enemy-use-cases/enemy-delete-use-case";
import { IenemyRepository } from "../../repositories/ienemy-repository";

export class EnemyDeleteService extends IEnemyDeleteUseCase {
    constructor(enemyRepository) {
        super();
        if (!(enemyRepository instanceof IenemyRepository)) {
            throw new TypeError("enemyRepository must be an instance of IenemyRepository");
        }
        this.enemyRepository = enemyRepository;
    }

    async deleteEnemy(id) {
        if (!id) throw new TypeError("id is required");

        const deletedEnemy = await this.enemyRepository.delete(id);
        return deletedEnemy;
    }
}
