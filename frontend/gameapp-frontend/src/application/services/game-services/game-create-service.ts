import type { IGameCreateUseCase } from "../../usecases/game-use-cases/game-create-use-case";
import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";

export class GameCreateService implements IGameCreateUseCase {
    constructor(private gameRepository: IGameRepository) { }

    async createGame(
        character: any,
        numberScenesToFinish: number,
        finalScene: any,
        listCurrentScenes: any[],
        listCurrentUserActions: any[]
    ): Promise<Game> {
        const game = new Game(character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions);
        const gameSaved = await this.gameRepository.save(game);
        return gameSaved;
    }
}
