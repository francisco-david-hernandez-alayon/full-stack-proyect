import { IGameCreateUseCase } from "../../usecases/game-use-cases/game-create-use-case";
import { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";

export class GameCreateService extends IGameCreateUseCase {
    constructor(gameRepository) {
        super();
        if (!(gameRepository instanceof IGameRepository)) throw new TypeError("gameRepository must be an instance of IGameRepository");
        this.gameRepository = gameRepository;
    }

    async createGame(character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions) {
        const game = new Game(character, numberScenesToFinish, finalScene, listCurrentScenes, listCurrentUserActions);
        const gameSaved = await this.gameRepository.save(game);
        return gameSaved;
    }
}