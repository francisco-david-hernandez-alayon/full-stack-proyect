import { Scene } from '../../../domain/entities/scenes/scene';

export interface ISceneCreateUseCase {
  createScene(scene: Scene): Promise<Scene>;
}
