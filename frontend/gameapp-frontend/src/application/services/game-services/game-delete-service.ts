import type { IGameDeleteUseCase } from "../../usecases/game-use-cases/game-delete-use-case";
import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";

export class GameDeleteService implements IGameDeleteUseCase {
    constructor(private readonly gameRepository: IGameRepository) {}

    async deleteGame(id: string): Promise<Game> {
        const deletedGame = await this.gameRepository.delete(id);
        return deletedGame;
    }
}
