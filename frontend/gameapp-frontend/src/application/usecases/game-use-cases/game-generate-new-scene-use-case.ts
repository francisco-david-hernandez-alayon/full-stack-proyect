import type { Game } from "../../../domain/entities/game";

export interface IGameGenerateNewSceneUseCase {
  generateNewScenes(currentSceneSelectedId: string, game: Game): Promise<Game>;
}
