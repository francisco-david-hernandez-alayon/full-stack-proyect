
import { Game } from "../../../domain/entities/game";
import type { IGameManageItemUseCase } from "../../usecases/game-use-cases/game-manage-item-use-case";
import type { Item } from "../../../domain/entities/items/item";
import { UserAction } from "../../../domain/enumerates/user-action";
import { addUserActions, removeUserActions } from "../../../adapter/react/utils/UserActionsUtils";

export class GameManageItemService implements IGameManageItemUseCase {
    constructor() { }

    async getItem(item: Item, game: Game): Promise<Game> {
        if (game.currentUserActions.includes(UserAction.GET_ITEM)) {
            let character = game.character;

            // The character doesnt have a full inventory and can get item
            if (character.inventoryList.length < character.maxInventorySlots) {
                if (game.currentUserActions.includes(UserAction.GET_ITEM)) {
                    character = character.addItemInventory(item);
                    game = game.setCharacter(character);

                    game = game.setCurrentUserActions(removeUserActions(game.currentUserActions, [UserAction.GET_ITEM, UserAction.USE_CURRENT_SCENE_ITEM]));
                    game = game.setCurrentUserActions(addUserActions(game.currentUserActions, [UserAction.USE_ITEM, UserAction.DROP_ITEM]));


                }
            }

        }
        return game;

    }

    async dropItem(positionItemSelected: number, game: Game): Promise<Game> {
        let character = game.character;

        // The selected slot in the character's inventory position is occupied and may drop items.
        if (character.inventoryList.length >= positionItemSelected) {
            if (game.currentUserActions.includes(UserAction.DROP_ITEM)) {
                character = character.removeItemInventory(positionItemSelected);
                game = game.setCharacter(character);

                // Update user actions if inventory is empty
                if (game.character.inventoryList.length == 0) {
                    game = game.setCurrentUserActions(removeUserActions(game.currentUserActions, [UserAction.USE_ITEM, UserAction.DROP_ITEM]));

                }

            }
        }
        return game;

    }
}
