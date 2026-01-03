import type { IGameUpdateUseCase } from "../../usecases/game-use-cases/game-update-use-case";
import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import type { GameStatus } from "../../../domain/enumerates/game-status";
import type { FinalScene } from "../../../domain/entities/scenes/final-scene";
import type { Character } from "../../../domain/value-objects/characters/character";
import type { Scene } from "../../../domain/entities/scenes/scene";
import type { UserAction } from "../../../domain/enumerates/user-action";
import type { Enemy } from "../../../domain/entities/enemy";
import type { GameDifficulty } from "../../../domain/enumerates/game-difficulty";

export class GameUpdateService implements IGameUpdateUseCase {
    constructor(private readonly gameRepository: IGameRepository) {}

    async updateGame(
        id: string,
        difficulty: GameDifficulty,
        character: Character,
        numberScenesToFinish: number,
        finalScene: FinalScene,
        listCurrentScenes: Scene[],
        listCurrentUserActions: UserAction[],
        completedScenes: Scene[],
        status: GameStatus,
        currentEnemy: Enemy | null
    ): Promise<Game> {
        const updatedGame = new Game(
            difficulty,
            character,
            numberScenesToFinish,
            finalScene,
            listCurrentScenes,
            listCurrentUserActions,
            completedScenes,
            status,
            currentEnemy,
            id
        );

        return await this.gameRepository.update(id, updatedGame);
    }
}
