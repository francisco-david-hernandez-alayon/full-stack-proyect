import { Character } from '../../../domain/value-objects/characters/character';
import { Scene } from '../../../domain/entities/scenes/scene';
import type { Game } from '../../../domain/entities/game';
import type { FinalScene } from '../../../domain/entities/scenes/final-scene';
import type { GameDifficulty } from '../../../domain/enumerates/game-difficulty';

export interface IGameCreateUseCase {
  createGame(
    difficulty: GameDifficulty,
    character: Character,
    numberScenesToFinish: number,
    finalScene: FinalScene,
    listCurrentScenes: Scene[],
    listCurrentUserActions: string[]
  ): Promise<Game>;
}
