import type { Game } from "../../../domain/entities/game";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";
import { GameStatus } from "../../../domain/enumerates/game-status";
import { UserAction } from "../../../domain/enumerates/user-action";
import type { IGameUseItemUseCase } from "../../usecases/game-use-cases/game-use-item-use-case";

export class GameUseItemService implements IGameUseItemUseCase {

  constructor() { }

  async useItem(positionItemSelected: number, game: Game): Promise<Game> {
    var character = game.character;

    // Check if item does NOT exist in inventory
    if (positionItemSelected < 0 || positionItemSelected >= character.inventoryList.length) {
      throw new Error(`Item in position ${positionItemSelected} does not exist in inventory position {positionItemSelected}`);
    }

    let item = character.inventoryList[positionItemSelected];


    // CHECK TYPE OF ITEM
    switch (true) {
      case item instanceof AttackItem:
        if (!game.currentUserActions.find(userAction => userAction === UserAction.ATTACK_ENEMY_WITH_ITEM)) {  // check if can attack with item
          return game;
        }

        // 1- check if exist current enemy
        if (!game.currentEnemy) {
          throw new Error(`Not exist current enemy to attack with attack item`);
        }
        const userSpeed = item.speedAttack;
        const enemySpeed = game.currentEnemy.speedAttack;

        // 2- attack with item (The one with the highest speed attacks first)
        if (userSpeed >= enemySpeed) {  // user attacks first

          game = game.setCurrentEnemy(game.currentEnemy.receiveDamage(item.attackDamage));

          // check if enemy is dead after being attacked
          if (game.currentEnemy!.healthPoints === 0) {
            character = character.earnMoney(game.currentEnemy!.rewardMoney);
            game = game.setCurrentEnemy(null);
            game = game.setCurrentUserActions([...game.currentUserActions, UserAction.MOVE_FORWARD])  // can pass scene

          } else { // enemy attacks back because it survived
            character = character.receiveDamage(game.currentEnemy!.attackDamage);

            // check if player is dead after enemy attack
            if (character.currentHealthPoints === 0) {
              game = game.setGameStatus(GameStatus.PLAYER_DEATH);
              return game;
            }

          }


        } else {  // enemy attacks first

          character = character.receiveDamage(game.currentEnemy.attackDamage);

          // check if player is dead after enemy attack
          if (character.currentHealthPoints === 0) {
            game = game.setGameStatus(GameStatus.PLAYER_DEATH);
            return game;
          }

          game = game.setCurrentEnemy(game.currentEnemy.receiveDamage(item.attackDamage));

          // check if enemy is dead after being attacked
          if (game.currentEnemy!.healthPoints === 0) {
            // check if enemys dead
            character = character.earnMoney(game.currentEnemy!.rewardMoney);
            game = game.setCurrentEnemy(null);
          }
        }

        // 3- remove item if durability <= 0, otherwise reduce it by 1
        if (item.durability - 1 <= 0) {
          character = character.removeItemInventory(positionItemSelected);

        } else {
          item = item.setDurability(item.durability - 1);
          character.inventoryList[positionItemSelected] = item;
        }

        // 4- update game character
        game = game.setCharacter(character);


        break;


      case item instanceof AttributeItem:
        // 1- use atributte item
        character = character.eat(item.foodPointsReceived);
        character = character.heal(item.healthPointsReceived);

        // 2- remove item
        character = character.removeItemInventory(positionItemSelected);
        
        // 3- update game character
        game = game.setCharacter(character);

        break;

      default:
        break;

    }

    return game;
  }
}
