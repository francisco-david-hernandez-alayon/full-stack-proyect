import { Enemy } from '../../domain/entities/enemy';
import { EnemyName } from '../../domain/value-objects/enemies/enemy-name';

export interface IEnemyRepository {
    fetchById(id: string): Promise<Enemy>;
    fetchByName(name: EnemyName): Promise<Enemy>;
    fetchAll(): Promise<Enemy[]>;
    save(enemy: Enemy): Promise<Enemy>;
    delete(id: string): Promise<Enemy>;
    update(id: string, enemy: Enemy): Promise<Enemy>;
}
