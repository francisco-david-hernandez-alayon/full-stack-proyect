import type { Enemy } from "../../../domain/entities/enemy";

export interface IEnemyCreateUseCase {
    createEnemy(enemy: Enemy): Promise<Enemy>;
}
