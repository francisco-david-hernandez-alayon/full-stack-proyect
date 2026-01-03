import type { IGameCreateUseCase } from "../../usecases/game-use-cases/game-create-use-case";
import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import type { FinalScene } from "../../../domain/entities/scenes/final-scene";
import type { Character } from "../../../domain/value-objects/characters/character";
import type { Scene } from "../../../domain/entities/scenes/scene";
import type { UserAction } from "../../../domain/enumerates/user-action";
import type { GameDifficulty } from "../../../domain/enumerates/game-difficulty";

export class GameCreateService implements IGameCreateUseCase {
    constructor(private readonly gameRepository: IGameRepository) { }

    async createGame(
        difficulty: GameDifficulty,
        character: Character,
        numberScenesToFinish: number,
        finalScene: FinalScene,
        listCurrentScenes: Scene[],
        listCurrentUserActions: UserAction[]
    ): Promise<Game> {
        const game = new Game(difficulty, character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions);
        const gameSaved = await this.gameRepository.save(game);
        return gameSaved;
    }
}
