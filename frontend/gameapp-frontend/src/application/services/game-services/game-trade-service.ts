import type { Game } from "../../../domain/entities/game";
import type { Scene } from "../../../domain/entities/scenes/scene";
import { TradeScene } from "../../../domain/entities/scenes/trade-scene";
import { UserAction } from "../../../domain/enumerates/user-action";
import type { IGameTradeUseCase } from "../../usecases/game-use-cases/game-trade-use-case";
import { GameManageItemService } from "./game-manage-item-service";


export class GameTradeService implements IGameTradeUseCase {

    constructor() { }

    private currentSceneIsTradeScene(currentScenes: Scene[]): Boolean {
        if (currentScenes.length != 1) {
            return false;
        }

        if (!(currentScenes[0] instanceof TradeScene)) {
            return false;
        }

        return true;
    }

    async sellItems(itemInventoryPositionToSell: number, game: Game): Promise<Game> {
        if (game.currentUserActions.includes(UserAction.SELL_ITEMS)) {

            const gameManageItemService = new GameManageItemService();

            // check if character is in trade scene
            if (this.currentSceneIsTradeScene(game.currentScenes) == false) {
                return game;
            }

            let character = game.character;
            let tradeScene = game.currentScenes[0] as TradeScene;

            // check if item to sell exist in character inventory
            if (itemInventoryPositionToSell < 0 || itemInventoryPositionToSell >= character.inventoryList.length) {
                throw new Error("item to sell in position " + itemInventoryPositionToSell + " not exist in inventory");
            }
            const itemToSell = character.inventoryList[itemInventoryPositionToSell];

            // check if trader has enough money to buy
            if (tradeScene.merchantMoneyToSpent < itemToSell.tradePrice) {
                return game;
            }

            // sell item to trader
            character = character.earnMoney(itemToSell.tradePrice);
            tradeScene = tradeScene.setMerchantMoneyToSpent(tradeScene.merchantMoneyToSpent - itemToSell.tradePrice);

            let gameUpdated = game.setCurrentScenes([tradeScene]);
            gameUpdated = gameUpdated.setCharacter(character);
            gameUpdated = await gameManageItemService.dropItem(itemInventoryPositionToSell, gameUpdated);  // remove item
            return gameUpdated
        }

        return game;
    }


    async buyItems(itemPositionToBuy: number, game: Game): Promise<Game> {
        if (game.currentUserActions.includes(UserAction.BUY_ITEMS)) {
            const gameManageItemService = new GameManageItemService();

            // check if character is in trade scene
            if (this.currentSceneIsTradeScene(game.currentScenes) == false) {
                return game;
            }

            let character = game.character;
            let tradeScene = game.currentScenes[0] as TradeScene;

            // check if item to sell exist in trader inventory
            if (itemPositionToBuy < 0 || itemPositionToBuy >= tradeScene.merchantItemsOffer.length) {
                throw new Error(
                    "Item to buy in position " + itemPositionToBuy + " does not exist in trader inventory"
                );
            }
            const itemToBuy = tradeScene.merchantItemsOffer[itemPositionToBuy];
            const itemFinalPrice = itemToBuy.tradePrice + tradeScene.profitMerchantMargin;

            // check if character has enough money to buy
            if (character.currentMoney < itemFinalPrice) {
                return game;
            }

            // Check if character has inventory space
            if (character.isInventoryFull()) {
                return game;
            }

            // buy item to trader
            character = character.spendMoney(itemFinalPrice);
            tradeScene = tradeScene.setMerchantMoneyToSpent(tradeScene.merchantMoneyToSpent + itemFinalPrice);
            tradeScene = tradeScene.removeMerchantItem(itemPositionToBuy);

            let gameUpdated = game.setCurrentScenes([tradeScene]);
            gameUpdated = gameUpdated.setCharacter(character);
            gameUpdated = await gameManageItemService.getItem(itemToBuy, gameUpdated);  // get item
            return gameUpdated
        }

        return game;
    }
}