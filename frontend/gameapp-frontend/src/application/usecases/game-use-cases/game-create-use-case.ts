import { Character } from '../../../domain/value-objects/characters/character';
import { Scene } from '../../../domain/entities/scenes/scene';
import type { Game } from '../../../domain/entities/game';

export interface IGameCreateUseCase {
  createGame(
    character: Character,
    numberScenesToFinish: number,
    finalScene: Scene,
    listCurrentScenes: Scene[],
    listCurrentUserActions: string[]
  ): Promise<Game>;
}
