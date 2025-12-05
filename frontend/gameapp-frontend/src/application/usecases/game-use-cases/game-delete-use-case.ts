import type { Game } from "../../../domain/entities/game";

export interface IGameDeleteUseCase {
  deleteGame(id: string): Promise<Game>;
}
