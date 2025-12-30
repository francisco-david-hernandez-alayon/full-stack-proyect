import type { FinalScene } from '../../../domain/entities/scenes/final-scene';
import { Scene } from '../../../domain/entities/scenes/scene';
import type { SceneName } from '../../../domain/value-objects/scenes/scene-name';

export interface ISceneGetUseCase {
  getScene(id: string): Promise<Scene>;
  getSceneByName(name: SceneName): Promise<Scene>;
  getAllScenes(): Promise<Scene[]>;
  getAllFinalScenes(): Promise<FinalScene[]>;
}
