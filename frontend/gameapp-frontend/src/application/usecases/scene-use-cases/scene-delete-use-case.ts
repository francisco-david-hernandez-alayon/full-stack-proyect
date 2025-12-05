import { Scene } from '../../../domain/entities/scenes/scene';

export interface ISceneDeleteUseCase {
  deleteScene(id: string): Promise<Scene>;
}
