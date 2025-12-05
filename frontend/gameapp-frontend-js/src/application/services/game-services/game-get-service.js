import { IGameGetUseCase } from "../../usecases/game-use-cases/game-get-use-case";
import { IGameRepository } from "../../repositories/igame-repository";

export class GameGetService extends IGameGetUseCase {
    constructor(gameRepository) {
        super();
        if (!(gameRepository instanceof IGameRepository)) {
            throw new TypeError("gameRepository must be an instance of IGameRepository");
        }
        this.gameRepository = gameRepository;
    }

    async getGame(id) {
        if (!id) throw new TypeError("id is required");

        return await this.gameRepository.fetchById(id);
    }

    async getAllGames() {
        return await this.gameRepository.fetchAll();
    }
}
