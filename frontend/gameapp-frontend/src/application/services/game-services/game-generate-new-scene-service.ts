import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import type { IGameGenerateNewSceneUseCase } from "../../usecases/game-use-cases/game-generate-new-scene-use-case";

export class GameGenerateNewScene implements IGameGenerateNewSceneUseCase {
    constructor(private gameRepository: IGameRepository) {}

    async generateNewScenes(currentSceneSelectedId: string, game: Game): Promise<Game> {
        const updatedGame = await this.gameRepository.generateNewScene(currentSceneSelectedId, game);
        return updatedGame;
    }
}
