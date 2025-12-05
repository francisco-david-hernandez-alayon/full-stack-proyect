import { Enemy } from "../../../domain/entities/enemy";
import type { IEnemyCreateUseCase } from "../../usecases/enemy-use-cases/enemy-create-use-case";
import type { IEnemyRepository } from "../../repositories/ienemy-repository";

export class EnemyCreateService implements IEnemyCreateUseCase {
    constructor(private enemyRepository: IEnemyRepository) {}

    async createEnemy(enemy: Enemy): Promise<Enemy> {
        return await this.enemyRepository.save(enemy);
    }
}
