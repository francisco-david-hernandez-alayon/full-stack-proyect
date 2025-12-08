import type { IGameGetUseCase } from "../../usecases/game-use-cases/game-get-use-case";
import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";

export class GameGetService implements IGameGetUseCase {
    constructor(private readonly gameRepository: IGameRepository) {}

    async getGame(id: string): Promise<Game> {
        return await this.gameRepository.fetchById(id);
    }

    async getAllGames(): Promise<Game[]> {
        return await this.gameRepository.fetchAll();
    }
}
