import type { Game } from "../../../domain/entities/game";

export interface IGameUseItemUseCase {
  useItem(positionItemSelected: number, game: Game): Promise<Game>;
}
