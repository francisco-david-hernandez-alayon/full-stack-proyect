import type { Game } from "../../../domain/entities/game";

export interface IGameAdvanceSceneUseCase {
  advance(currentSceneSelectedId: string, game: Game): Promise<Game>;
}
