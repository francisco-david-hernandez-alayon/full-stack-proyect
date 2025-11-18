import { IGameUpdateUseCase } from "../../usecases/game-use-cases/game-update-use-case";
import { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";

export class GameUpdateService extends IGameUpdateUseCase {
    constructor(gameRepository) {
        super();
        if (!(gameRepository instanceof IGameRepository)) {
            throw new TypeError("gameRepository must be an instance of IGameRepository");
        }
        this.gameRepository = gameRepository;
    }

    async updateGame(id, character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions, completedScenes, currentEnemy) {
        if (!id) throw new TypeError("id is required");

        const updatedGame = new Game(character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions, completedScenes, currentEnemy, id);

        await this.gameRepository.update(id, updatedGame);

        return updatedGame;
    }
}
