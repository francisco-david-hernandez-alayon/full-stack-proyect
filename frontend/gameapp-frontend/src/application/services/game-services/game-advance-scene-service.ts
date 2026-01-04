import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import type { IGameAdvanceSceneUseCase } from "../../usecases/game-use-cases/game-advance-scene-use-case";

export class GameAdvanceSceneService implements IGameAdvanceSceneUseCase {
    constructor(private readonly gameRepository: IGameRepository) { }

    async advance(currentSceneSelectedId: string, game: Game): Promise<Game> {
        const updatedGame = await this.gameRepository.generateNewScene(currentSceneSelectedId, game);
        return updatedGame;
    }
}
