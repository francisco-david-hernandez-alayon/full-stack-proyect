import type { Enemy } from "../../../domain/entities/enemy";
import type { EnemyName } from "../../../domain/value-objects/enemies/enemy-name";

export interface IEnemyGetUseCase {
    getEnemy(id: string): Promise<Enemy>;
    getEnemyByName(enemyName: EnemyName): Promise<Enemy>;
    getAllEnemys(): Promise<Enemy[]>;
}
