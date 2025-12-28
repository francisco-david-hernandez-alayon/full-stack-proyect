import type { Game } from "../../../domain/entities/game";

export interface IGameTradeUseCase {
  sellItems(itemInventoryPositionToSell: number, game: Game): Promise<Game>;

  buyItems(itemPositionToBuy: number, game: Game): Promise<Game>;
}
