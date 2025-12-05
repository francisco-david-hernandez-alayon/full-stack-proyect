import { Character } from '../../../domain/value-objects/characters/character';
import { Scene } from '../../../domain/entities/scenes/scene';
import { Enemy } from '../../../domain/entities/enemy';
import { Game } from '../../../domain/entities/game';

export interface IGameUpdateUseCase {
    updateGame(
        id: string,
        character: Character,
        numberScenesToFinish: number,
        finalScene: Scene,
        listCurrentScenes: Scene[],
        listCurrentUserActions: string[],
        completedScenes: Scene[],
        currentEnemy: Enemy | null
    ): Promise<Game>;
}
