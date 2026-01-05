import { addUserActions, removeUserActions } from "../../Utils/UserActionsUtils";
import type { Game } from "../../../domain/entities/game";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";
import type { Item } from "../../../domain/entities/items/item";
import { GameStatus } from "../../../domain/enumerates/game-status";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import type { IGameUseItemUseCase } from "../../usecases/game-use-cases/game-use-item-use-case";
import { GameManageItemService } from "./game-manage-item-service";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";

export class GameUseItemService implements IGameUseItemUseCase {

  constructor() { }

  private async attackEnemy(Damage: number, Speed: number, game: Game): Promise<Game> {
    let character = game.character;
    let enemy = game.currentEnemy;

    if (!enemy) return game;

    const userDamage = character.attackDamage + Damage;
    const userSpeed = character.attackSpeed + Speed;
    const enemyDamage = enemy.attackDamage;
    const enemySpeed = enemy.speedAttack;

    if (userSpeed >= enemySpeed) {
      // User attack first
      enemy = enemy.receiveDamage(userDamage);

      // Check if Enemy is dead
      if (enemy!.healthPoints <= 0) {
        character = character.earnMoney(enemy!.rewardMoney);
        enemy = null;
        game = game.setCurrentUserActions(
          addUserActions(game.currentUserActions, [UserAction.MOVE_FORWARD])
        );

      } else {
        // Enemy Attack second
        character = character.receiveDamage(enemyDamage);

        // Check if Player is dead
        if (character.currentHealthPoints <= 0) {
          game = game.setGameStatus(GameStatus.PLAYER_DEATH);
          game = game.setCharacter(character);
          game = game.setCurrentEnemy(enemy);
          return game;
        }
      }
    } else {
      // Enemy Attack first
      character = character.receiveDamage(enemyDamage);

      // Check if Player is dead
      if (character.currentHealthPoints <= 0) {
        game = game.setGameStatus(GameStatus.PLAYER_DEATH);
        game = game.setCharacter(character);
        game = game.setCurrentEnemy(enemy);
        return game;
      }

      // User Attack second
      enemy = enemy.receiveDamage(userDamage);

      //Check if Enemy is dead
      if (enemy!.healthPoints <= 0) {
        character = character.earnMoney(enemy!.rewardMoney);
        enemy = null;
        game = game.setCurrentUserActions(
          addUserActions(game.currentUserActions, [UserAction.MOVE_FORWARD])
        );
      }
    }

    if (character instanceof WarriorCharacter) {
      character = character.addHit();
    }

    if (character instanceof ThiefCharacter && enemy == null) {
      character = character.earnMoney(ThiefCharacter.EXTRA_MONEY_WHEN_KILL_ENEMY);
    }

    game = game.setCharacter(character);
    game = game.setCurrentEnemy(enemy);

    return game;
  }


  // Use any kind of item
  private async useItem(game: Game, item: Item, positionInventoryItemSelected?: number): Promise<Game> {
    const gameManageItemService = new GameManageItemService();

    // CHECK TYPE OF ITEM
    switch (true) {
      case item instanceof AttackItem:
        // 1- check if exist current enemy and can attack with item
        if (!game.currentEnemy) {
          return game;
        }
        if (!game.currentUserActions.find(userAction => userAction === UserAction.ATTACK_ENEMY_WITH_ITEM)) {
          return game;
        }

        // 2- attack enemy with item and check if player survive
        game = await this.attackEnemy(item.attackDamage, item.speedAttack, game);

        if (game.status == GameStatus.PLAYER_DEATH) {
          return game;
        }

        // 3- remove item(if item is in inventory): if durability <= 0, otherwise reduce it by 1
        var character = game.character;
        if (positionInventoryItemSelected !== undefined && positionInventoryItemSelected !== null) {
          if (item.durability - 1 <= 0) {
            game = await gameManageItemService.dropItem(positionInventoryItemSelected, game);

          } else {
            item = item.setDurability(item.durability - 1);
            character.inventoryList[positionInventoryItemSelected] = item;
            game = game.setCharacter(character);
          }
          
        }

        break;


      case item instanceof AttributeItem:
        var character = game.character;

        // 1- use atributte item
        character = character.eat(item.foodPointsReceived);
        character = character.heal(item.healthPointsReceived);
        game = game.setCharacter(character);

        // 2- remove item(if item is in inventory)
        if (positionInventoryItemSelected !== undefined && positionInventoryItemSelected !== null) {
          game = await gameManageItemService.dropItem(positionInventoryItemSelected, game);
        }

        break;

      default:
        break;

    }

    return game;
  }

  // Use an item from inventory
  async useInventoryItem(positionItemSelected: number, game: Game): Promise<Game> {

    // Check if item does NOT exist in inventory
    if (positionItemSelected < 0 || positionItemSelected >= game.character.inventoryList.length) {
      throw new Error(`Item in position ${positionItemSelected} does not exist in inventory position {positionItemSelected}`);
    }

    // Use item
    let item = game.character.inventoryList[positionItemSelected];
    let gameUpdated = await this.useItem(game, item, positionItemSelected);

    // Update user actions if inventory is empty
    if (gameUpdated.character.inventoryList.length == 0) {
      gameUpdated = gameUpdated.setCurrentUserActions(removeUserActions(gameUpdated.currentUserActions, [UserAction.USE_ITEM, UserAction.DROP_ITEM]));
    }

    return gameUpdated;
  }

  // Use an item from current Scene
  async useSceneItem(item: Item, game: Game): Promise<Game> {
    if (game.currentUserActions.includes(UserAction.USE_CURRENT_SCENE_ITEM)) {
      // Use item
      let gameUpdated = await this.useItem(game, item);

      // Update user actions removing item actions from scene
      gameUpdated = gameUpdated.setCurrentUserActions(removeUserActions(gameUpdated.currentUserActions, [UserAction.GET_ITEM, UserAction.USE_CURRENT_SCENE_ITEM]));
      return gameUpdated
    }

    return game;
  }

  // attack without item
  async attackWithoutItem(game: Game): Promise<Game> {
    if (game.currentUserActions.includes(UserAction.ATTACK_ENEMY_WITHOUT_ITEM)) {
      game = await this.attackEnemy(0, 0, game);
    }

    return game;
  }
}
