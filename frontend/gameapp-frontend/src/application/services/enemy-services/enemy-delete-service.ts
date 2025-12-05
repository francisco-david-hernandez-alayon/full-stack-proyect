import { Enemy } from "../../../domain/entities/enemy";
import type { IEnemyDeleteUseCase } from "../../usecases/enemy-use-cases/enemy-delete-use-case";
import type { IEnemyRepository } from "../../repositories/ienemy-repository";

export class EnemyDeleteService implements IEnemyDeleteUseCase {
    constructor(private enemyRepository: IEnemyRepository) {}

    async deleteEnemy(id: string): Promise<Enemy> {
        return await this.enemyRepository.delete(id);
    }
}
