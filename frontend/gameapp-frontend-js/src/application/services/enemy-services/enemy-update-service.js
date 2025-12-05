import { IEnemyUpdateUseCase } from "../../usecases/enemy-use-cases/enemy-update-use-case";
import { IenemyRepository } from "../../repositories/ienemy-repository";

export class EnemyUpdateService extends IEnemyUpdateUseCase {
    constructor(enemyRepository) {
        super();
        if (!(enemyRepository instanceof IenemyRepository)) {
            throw new TypeError("enemyRepository must be an instance of IenemyRepository");
        }
        this.enemyRepository = enemyRepository;
    }

    async updateEnemy(id, Enemy) {
        if (!id) throw new TypeError("id is required");
        if (!Enemy) throw new TypeError("Enemy is required");

        const updatedEnemy = await this.enemyRepository.update(id, Enemy);
        return updatedEnemy;
    }
}
