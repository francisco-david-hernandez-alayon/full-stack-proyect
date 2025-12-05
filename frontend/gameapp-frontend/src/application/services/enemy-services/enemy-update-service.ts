import { Enemy } from "../../../domain/entities/enemy";
import type { IEnemyUpdateUseCase } from "../../usecases/enemy-use-cases/enemy-update-use-case";
import type { IEnemyRepository } from "../../repositories/ienemy-repository";

export class EnemyUpdateService implements IEnemyUpdateUseCase {
    constructor(private enemyRepository: IEnemyRepository) {}

    async updateEnemy(id: string, enemy: Enemy): Promise<Enemy> {
        return await this.enemyRepository.update(id, enemy);
    }
}
