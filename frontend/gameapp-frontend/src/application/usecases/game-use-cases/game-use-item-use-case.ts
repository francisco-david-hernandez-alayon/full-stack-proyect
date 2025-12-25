import type { Game } from "../../../domain/entities/game";
import type { Item } from "../../../domain/entities/items/item";

export interface IGameUseItemUseCase {
  useInventoryItem(positionItemSelected: number, game: Game): Promise<Game>;
  useSceneItem(item: Item, game: Game): Promise<Game>;
  attackWithoutItem(game: Game): Promise<Game>;
}
