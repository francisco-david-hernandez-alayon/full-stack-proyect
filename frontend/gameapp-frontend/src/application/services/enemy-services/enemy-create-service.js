import { IEnemyCreateUseCase } from "../../usecases/enemy-use-cases/enemy-create-use-case";
import { IenemyRepository } from "../../repositories/ienemy-repository";

export class EnemyCreateService extends IEnemyCreateUseCase {
    constructor(enemyRepository) {
        super();
        if (!(enemyRepository instanceof IenemyRepository)) {
            throw new TypeError("enemyRepository must be an instance of IenemyRepository");
        }
        this.enemyRepository = enemyRepository;
    }

    async createEnemy(enemy) {
        if (!enemy) throw new TypeError("Enemy is required");

        const savedEnemy = await this.enemyRepository.save(enemy);
        return savedEnemy;
    }
}
