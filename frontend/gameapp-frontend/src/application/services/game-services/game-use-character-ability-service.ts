import type { Enemy } from '../../../domain/entities/enemy';
import type { Game } from '../../../domain/entities/game';
import type { Item } from '../../../domain/entities/items/item';
import { ItemRarity } from '../../../domain/enumerates/item-rarity';
import { UserAction } from '../../../domain/enumerates/user-action';
import { BerserkerCharacter } from '../../../domain/value-objects/characters/berserker-character';
import { ExplorerCharacter } from '../../../domain/value-objects/characters/explorer-character';
import { WarriorCharacter } from '../../../domain/value-objects/characters/warrior-character';
import type { IItemRepository } from '../../repositories/iitem-repository';
import type { IGameUseCharacterAbilityUseCase } from '../../usecases/game-use-cases/game-use-character-ability-use-case';
import { addUserActions } from '../../Utils/UserActionsUtils';

export class GameUseCharacterAbilityService implements IGameUseCharacterAbilityUseCase {
  constructor(private itemRepository: IItemRepository) {}

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

      case game.character instanceof BerserkerCharacter:
        let berserker = game.character;

        // Check if can use ability
        if (berserker.canUseAbility()) {
          berserker = berserker.heal(berserker.getAbilityCure()) as BerserkerCharacter;
          berserker = berserker.resetKills();

          game = game.setCharacter(berserker);
        }
        break;
      
      case game.character instanceof ExplorerCharacter:
        let explorer = game.character;

        // Check if can use ability
        if (explorer.canUseAbility() && !explorer.isInventoryFull()) {
          const commonItems: Item[] = await this.itemRepository.fetchAllByFilter(undefined, ItemRarity.Common);
          const rareItems: Item[] = await this.itemRepository.fetchAllByFilter(undefined, ItemRarity.Rare);

          // chance to get a rare item
          const isRare = Math.random() < ExplorerCharacter.PROBABILITY_OF_RARE_ITEM / 100;
          const sourceList = isRare ? rareItems : commonItems;

          if (sourceList.length > 0) {
              const randomIndex = Math.floor(Math.random() * sourceList.length);
              const foundItem = sourceList[randomIndex];

              explorer = explorer.addItemInventory(foundItem) as ExplorerCharacter;
          }

          explorer = explorer.resetNothingHappensScenes();
          game = game.setCharacter(explorer);
        }
        break;

      default:
        break;
    }

    return game;
  }
}
