import type { Enemy } from '../../../domain/entities/enemy';
import type { Game } from '../../../domain/entities/game';
import { UserAction } from '../../../domain/enumerates/user-action';
import { WarriorCharacter } from '../../../domain/value-objects/characters/warrior-character';
import type { IGameUseCharacterAbilityUseCase } from '../../usecases/game-use-cases/game-use-character-ability-use-case';
import { addUserActions } from '../../Utils/UserActionsUtils';

export class GameUseCharacterAbilityService implements IGameUseCharacterAbilityUseCase {

  async useAbility(game: Game): Promise<Game> {


    switch (true) {
      case game.character instanceof WarriorCharacter:
        let warrior = game.character;

        // Check if can use ability
        if (warrior.canUseAbility() && game.currentEnemy != null) {

          // Character attack
          let enemy: Enemy | null = game.currentEnemy;
          enemy = enemy.receiveDamage(WarriorCharacter.ABILITY_DAMAGE);

          // Check if Enemy is dead
          if (enemy!.healthPoints <= 0) {
            warrior = warrior.earnMoney(enemy!.rewardMoney) as WarriorCharacter;
            enemy = null;
            game = game.setCurrentUserActions(
              addUserActions(game.currentUserActions, [UserAction.MOVE_FORWARD])
            );
          }
          warrior = warrior.resetHits();

          game = game.setCharacter(warrior);
          game = game.setCurrentEnemy(enemy);
        }
        break;

      default:
        break;
    }

    return game;
  }
}
