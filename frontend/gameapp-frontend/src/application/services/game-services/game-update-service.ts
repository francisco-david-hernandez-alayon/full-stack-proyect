import type { IGameUpdateUseCase } from "../../usecases/game-use-cases/game-update-use-case";
import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";

export class GameUpdateService implements IGameUpdateUseCase {
    constructor(private gameRepository: IGameRepository) {}

    async updateGame(
        id: string,
        character: any,
        numberScenesToFinish: number,
        finalScene: any,
        listCurrentScenes: any[],
        listCurrentUserActions: any[],
        completedScenes: any[],
        currentEnemy: any
    ): Promise<Game> {
        const updatedGame = new Game(
            character,
            numberScenesToFinish,
            finalScene,
            listCurrentScenes,
            listCurrentUserActions,
            completedScenes,
            currentEnemy,
            id
        );

        return await this.gameRepository.update(id, updatedGame);
    }
}
