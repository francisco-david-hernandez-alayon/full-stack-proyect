import { Enemy } from "../../../domain/entities/enemy";
import type { IEnemyGetUseCase } from "../../usecases/enemy-use-cases/enemy-get-use-case";
import type { IEnemyRepository } from "../../repositories/ienemy-repository";
import type { EnemyName } from "../../../domain/value-objects/enemies/enemy-name";

export class EnemyGetService implements IEnemyGetUseCase {
    constructor(private enemyRepository: IEnemyRepository) {}

    async getEnemy(id: string): Promise<Enemy> {
        return await this.enemyRepository.fetchById(id);
    }

    async getEnemyByName(enemyName: EnemyName): Promise<Enemy> {
        return await this.enemyRepository.fetchByName(enemyName);
    }

    async getAllEnemys(): Promise<Enemy[]> {
        return await this.enemyRepository.fetchAll();
    }
}
