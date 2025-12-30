import { Character } from '../../../domain/value-objects/characters/character';
import { Scene } from '../../../domain/entities/scenes/scene';
import { Enemy } from '../../../domain/entities/enemy';
import { Game } from '../../../domain/entities/game';
import type { GameStatus } from '../../../domain/enumerates/game-status';
import type { FinalScene } from '../../../domain/entities/scenes/final-scene';

export interface IGameUpdateUseCase {
    updateGame(
        id: string,
        character: Character,
        numberScenesToFinish: number,
        finalScene: FinalScene,
        listCurrentScenes: Scene[],
        listCurrentUserActions: string[],
        completedScenes: Scene[],
        status: GameStatus,
        currentEnemy: Enemy | null
    ): Promise<Game>;
}
