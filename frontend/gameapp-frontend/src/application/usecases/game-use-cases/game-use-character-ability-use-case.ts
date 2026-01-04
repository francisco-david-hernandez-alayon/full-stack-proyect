import type { Game } from '../../../domain/entities/game';

export interface IGameUseCharacterAbilityUseCase {
  useAbility(game: Game): Promise<Game>;
}
