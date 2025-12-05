import { Scene } from '../../../domain/entities/scenes/scene';

export interface ISceneUpdateUseCase {
  updateScene(id: string, scene: Scene): Promise<Scene>;
}
