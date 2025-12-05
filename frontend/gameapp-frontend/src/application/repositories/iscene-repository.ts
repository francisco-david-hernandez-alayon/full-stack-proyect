import { Scene } from '../../domain/entities/scenes/scene';
import { SceneName } from '../../domain/value-objects/scenes/scene-name';

export interface ISceneRepository {
    fetchById(id: string): Promise<Scene>;
    fetchByName(name: SceneName): Promise<Scene>;
    fetchAll(): Promise<Scene[]>;
    save(scene: Scene): Promise<Scene>;
    delete(id: string): Promise<Scene>;
    update(id: string, scene: Scene): Promise<Scene>;
}
