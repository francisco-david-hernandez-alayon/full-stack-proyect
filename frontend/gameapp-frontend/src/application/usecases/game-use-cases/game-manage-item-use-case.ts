import type { Game } from "../../../domain/entities/game";
import type { Item } from "../../../domain/entities/items/item";

export interface IGameManageItemUseCase {
  getItem(item: Item, game: Game): Promise<Game>;

  dropItem(positionItemSelected: number, game: Game): Promise<Game>;
}
