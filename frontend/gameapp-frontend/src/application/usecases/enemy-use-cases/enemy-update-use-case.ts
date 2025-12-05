import type { Enemy } from "../../../domain/entities/enemy";

export interface IEnemyUpdateUseCase {
    updateEnemy(id: string, enemy: Enemy): Promise<Enemy>;
}
