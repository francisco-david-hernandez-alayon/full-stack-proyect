import { IGameDeleteUseCase } from "../../usecases/game-use-cases/game-delete-use-case";
import { IGameRepository } from "../../repositories/igame-repository";

export class GameDeleteService extends IGameDeleteUseCase {
    constructor(gameRepository) {
        super();
        if (!(gameRepository instanceof IGameRepository)) {
            throw new TypeError("gameRepository must be an instance of IGameRepository");
        }
        this.gameRepository = gameRepository;
    }

    async deleteGame(id) {
        if (!id) throw new TypeError("id is required");

        const deletedGame = await this.gameRepository.delete(id);
        return deletedGame;
    }
}
