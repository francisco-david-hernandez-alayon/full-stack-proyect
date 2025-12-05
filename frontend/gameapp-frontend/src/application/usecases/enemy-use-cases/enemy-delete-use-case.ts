import type { Enemy } from "../../../domain/entities/enemy";

export interface IEnemyDeleteUseCase {
    deleteEnemy(id: string): Promise<Enemy>;
}
